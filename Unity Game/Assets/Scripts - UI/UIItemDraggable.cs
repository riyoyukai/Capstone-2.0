using UnityEngine;
using System.Collections;

public class UIItemDraggable : MonoBehaviour {

	private Vector3 anchor;
	public UIItemDock currentDock;

	/// <summary>
	/// Sets the anchor position.
	/// </summary>
	/// <param name="newPos">New position.</param>
	public void SetAnchor (Vector2 newPos){
		anchor = newPos;
		this.transform.position = newPos;
	}

	/// <summary>
	/// Returns card position to anchor.
	/// </summary>
	public void SnapToAnchor(){
		this.transform.position = anchor;
	}
}
