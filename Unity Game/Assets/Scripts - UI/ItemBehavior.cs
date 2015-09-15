using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemBehavior : MonoBehaviour {

	private Item item;
	private bool followMouse = false;
	private GameObject inventoryButton;
	private SpriteRenderer trash;
	private SpriteRenderer spriteRenderer;
	private InventoryController inventoryController;

	/// <summary>
	/// Initializes various variables for later access
	/// </summary>
//	void Start(){
//		inventoryButton = GameObject.FindGameObjectWithTag("InventoryButton");
//		trash = GameObject.FindGameObjectWithTag("Trash").GetComponent<SpriteRenderer>();
//		inventoryController = GameObject.Find("InventoryController").GetComponent<InventoryController>();
//		spriteRenderer = GetComponent<SpriteRenderer>();
//	}

	/// <summary>
	/// This should be called every time a new ItemBehavior is instantiated so
	/// that it is linked to an Item object and associated with GameData.inventory
	/// </summary>
	/// <param name="pItem">pItem.</param>
	public void SetUp(Item pItem){
		item = pItem;
		spriteRenderer.sprite = Resources.Load<Sprite>("Textures/" + pItem.textureName);
		inventoryButton = GameObject.FindGameObjectWithTag("InventoryButton");
		trash = GameObject.FindGameObjectWithTag("Trash").GetComponent<SpriteRenderer>();
		inventoryController = GameObject.Find("InventoryController").GetComponent<InventoryController>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnMouseDown(){
		followMouse = true;
	}

	/// <summary>
	/// Stops following the mouse.
	/// If mouse is over trash, destroy item.
	/// If mouse is over inventory, returns item to inventory.
	/// </summary>
	void OnMouseUp(){
		followMouse = false;
		
		Vector3 p = this.transform.position;
		
		if(Ease.IsPointWithinSprite(p + new Vector3(0, 2.1f, 0), trash)){
			print ("Trash item");
			Destroy (this.gameObject);
		}

		p = Camera.main.WorldToScreenPoint(p);
		p.y += 30;
		
		if(Ease.IsPointWithinRect(p, inventoryButton)){
			print ("Put item away");
			inventoryController.TakeItem(item);
			Destroy (this.gameObject);
		}
	}

	void Update(){
		if(followMouse){
			Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			newPos.z = this.transform.position.z;
			newPos.y -= 6.5f;
			this.transform.position = newPos;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}
}
