using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIItemDraggable : MonoBehaviour {

	private Item item;
	private Vector3 anchor;
	public UIItemDock currentDock;
	
	/// <summary>
	/// This should be called every time a new ItemBehavior is instantiated so
	/// that it is linked to an Item object and associated with GameData.inventory
	/// </summary>
	/// <param name="pItem">pItem.</param>
	public void SetUp(Item pItem){
		item = pItem;
		GetComponent<Image>().sprite = Resources.Load<Sprite>(item.textureName);
	}

	/// <summary>
	/// Sets the anchor position.
	/// </summary>
	/// <param name="newPos">New position.</param>
	public void SetAnchor (Vector2 newPos){
		anchor = newPos;
		this.transform.position = newPos;
	}

	/// <summary>
	/// Returns position to anchor.
	/// </summary>
	public void SnapToAnchor(){
		this.transform.position = anchor;
	}
}
