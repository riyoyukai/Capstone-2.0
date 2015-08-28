using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Popup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void E_ClosePopup(Button closeButton){
		closeButton.interactable = false;
		ClosePopup ();
	}

	public void ClosePopup(){
		this.gameObject.SetActive (false);
	}

	public void LevelUp(int startXP, int xpToAdd, int level, int xpToNextLevel){

	}
}
