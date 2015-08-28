using UnityEngine;
using System.Collections;

public class UIItemDraggable : MonoBehaviour {

	public void E_Drag(){
		
		Vector3 pos = this.transform.position;

		pos.x = Input.mousePosition.x;
		pos.y = Input.mousePosition.y;

		this.transform.position = pos;
	}
}
