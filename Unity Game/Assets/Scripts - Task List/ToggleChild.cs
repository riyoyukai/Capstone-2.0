using UnityEngine;
using System.Collections;

public class ToggleChild : MonoBehaviour {

	public GameObject child;

	public void _ToggleChild(){
		child.SetActive (!child.activeSelf);
	}
}
