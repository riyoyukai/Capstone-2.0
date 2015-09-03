using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemBehavior : MonoBehaviour {

	private bool followMouse = false;

	void OnMouseDown(){
		followMouse = true;
	}

	void OnMouseUp(){
		followMouse = false;
		
		Vector3 p = this.transform.position;
		p = Camera.main.WorldToScreenPoint(p);
		p.y += 30;

		GameObject inventoryButton = GameObject.FindGameObjectWithTag("InventoryButton");

		if(Ease.IsPointWithinBounds(p, inventoryButton)){
			print ("Put item away");
			Destroy (this.gameObject);
		}else{
//			transform.position = new Vector3(transform.position.x, transform.position.y + 3.5f, transform.position.z);
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
