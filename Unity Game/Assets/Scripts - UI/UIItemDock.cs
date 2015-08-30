using UnityEngine;
using System.Collections;

public class UIItemDock : MonoBehaviour {

	public UIItemDraggable heldItem;

	void Start () {
	}
	
	public void AnchorItem(){
		print ("Dock Position: " + this.transform.position);
		if(heldItem){
			heldItem.SetAnchor(this.transform.position);
		}
	}
}
