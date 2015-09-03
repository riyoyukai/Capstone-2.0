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
	private UIItemDraggable heldItem;
	private RectTransform rt;
	private CanvasGroup cg;
	public Transform TestItem;

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive(true);
		rt = GetComponent<RectTransform>();
		cg = GetComponent<CanvasGroup>();
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

	private void PutItemInDock(UIItemDraggable item, UIItemDock dock){
		// if dock is not holding item
		dock.heldItem = item;
		item.currentDock = dock;
		dock.AnchorItem();

		// else, swap items
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
			if(Ease.IsPointWithinBounds(pItem.transform.position, inventoryButton.gameObject)) OpenInventory();
		}
	}

	public void E_UpOnUIItem(UIItemDraggable item){
		// if inventory is still open
		if(cg.alpha == 1){
			bool upOnDock = false;
			for (int i = 0; i < itemDocks.Length; i++) {
				if(Ease.IsPointWithinBounds(item.transform.position, itemDocks[i].gameObject)){
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
			Vector3 newPos = new Vector3(itemWS.x, itemWS.y, TestItem.position.z);
			Instantiate(TestItem, newPos, TestItem.rotation);

			print ("CREATE ITEM");
			print ("Mouse y: " + Input.mousePosition.y);
			print ("newPos y: " + newPos.y);

			Destroy (item.gameObject);
		}
	}
	
	public void E_ToggleInventory(){
		if(cg.alpha == 1) CloseInventory();
		else OpenInventory();
	}


}
