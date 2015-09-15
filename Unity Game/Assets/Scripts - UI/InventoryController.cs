using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Inventory controller. This is attached to the Panel-Inventory object
/// in the hierarchy, which holds the item docks and inventory.
/// </summary>
public class InventoryController : MonoBehaviour {

	public Button inventoryButton;
	public UIItemDock[] itemDocks;
	public Image dockedItemsPanel;
	public Image heldItemPanel;
	private RectTransform rt;
	private CanvasGroup cg;
	public Transform newItemBehavior;
	public Transform newUIItemDraggable;

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive(true);
		rt = GetComponent<RectTransform>();
		cg = GetComponent<CanvasGroup>();
		GameData.TestInventory();
		PopulateInventory();
		CloseInventory();
	}
	
	public void OpenInventory(){
		cg.alpha = 1;
		cg.blocksRaycasts = true;
	}
	
	public void CloseInventory(){
		cg.alpha = 0;
		cg.blocksRaycasts = false;
	}

	/// <summary>
	/// Iterates through item docks as long as index i exists in GameData.inventory
	/// </summary>
	public void PopulateInventory(){
		for(int i = 0; i < itemDocks.Length && GameData.inventory.Count > i; i++){
			if(GameData.inventory[i] != null){
				Vector3 newPos = itemDocks[i].transform.position;
				GameObject newItem = Instantiate(newUIItemDraggable, newPos, newUIItemDraggable.rotation) as GameObject;
//				print ("Blarg. null? " + (newItem == null));
				// TODO: 
//				UIItemDraggable newItemDraggable = newItem.GetComponent<UIItemDraggable>();
//				newItemDraggable.SetUp(GameData.inventory[i]);
//				PutItemInDock(newItemDraggable, itemDocks[i]);
			}
		}
	}

	/// <summary>
	/// Returns an ItemBehavior's item to the inventory
	/// </summary>
	/// <param name="pItem">P item.</param>
	public void TakeItem(Item pItem){
		//TODO: GameData.inventory
	}

	private void PutItemInDock(UIItemDraggable item1, UIItemDock dock2){
		// if dock is not holding item
		if(dock2.heldItem == null){
			if(item1.currentDock) item1.currentDock.heldItem = null;
			dock2.heldItem = item1;
			item1.currentDock = dock2;
			dock2.AnchorItem();
			print ("Dock 2 was not holding an item");
		}else{ // else, swap items
			UIItemDock dock1 = item1.currentDock;
			UIItemDraggable item2 = dock2.heldItem;

			dock2.heldItem = item1;
			item1.currentDock = dock2;
			dock2.AnchorItem();

			dock1.heldItem = item2;
			item2.currentDock = dock1;
			dock1.AnchorItem();
			print ("Swapped items");
		}
	}

	public void E_DownOnUIItem(UIItemDraggable item){
		item.transform.SetParent(heldItemPanel.transform);
	}
	
	public void E_DragUIItem(GameObject pItem){		
		pItem.transform.position = Input.mousePosition;

		// if inventory is open
		if (cg.alpha == 1){
//			print ("Item position y: " + pItem.transform.position.y);
//			print ("Top of Inventory position: " + this.transform.position.y + rt.rect.height / 2);
			// if item is above the inventory top line, closeinventory
			if(pItem.transform.position.y > this.transform.position.y + rt.rect.height / 2) {
				CloseInventory();
			}
		// if inventory is closed
		}else{
			// if mouse over the inventory button, open inventory
			if(Ease.IsPointWithinRect(pItem.transform.position, inventoryButton.gameObject)) OpenInventory();
		}
	}

	public void E_UpOnUIItem(UIItemDraggable item){
		// if inventory is still open
		if(cg.alpha == 1){
			bool upOnDock = false;
			for (int i = 0; i < itemDocks.Length; i++) {
				if(Ease.IsPointWithinRect(item.transform.position, itemDocks[i].gameObject)){
					print ("iteration: " + i);	
					if(item.currentDock == itemDocks[i]) break;
					upOnDock = true;
					PutItemInDock(item, itemDocks[i]);
				}
			}
			if(!upOnDock) item.SnapToAnchor();
			item.transform.SetParent(dockedItemsPanel.transform);
		// if inventory is closed
		}else{
			// destroy 'item', instantiate gameobject outside of canvas
			Vector3 newZ = item.transform.position;
			newZ.z = 24;
			Vector3 itemWS = Camera.main.ScreenToWorldPoint(newZ);
			Vector3 newPos = new Vector3(itemWS.x, itemWS.y, newItemBehavior.position.z);
			Instantiate(newItemBehavior, newPos, newItemBehavior.rotation);

			print ("CREATE ITEM");
			print ("Mouse y: " + Input.mousePosition.y);
			print ("newPos y: " + newPos.y);

			item.currentDock.heldItem = null;
			Destroy (item.gameObject);
		}
	}
	
	public void E_ToggleInventory(){
		if(cg.alpha == 1) CloseInventory();
		else OpenInventory();
	}


}
