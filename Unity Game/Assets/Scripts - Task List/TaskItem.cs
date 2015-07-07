using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// this gets connected to the Panel that holds the task item and options panel
public class TaskItem : MonoBehaviour {

	public GameObject taskItemPanelPrefab;
	public Button actionButton;
	public Text actionButtonText;
	public InputField inputField;
	public Text text;
	public GameObject optionsPanel;
	
	public bool plus = true;
	public bool check = false;
	public bool delete = false;

	public void Awake(){

	}

	// user tapped + or check.
	public void ActionButtonPressed(){
		if (plus) {
			inputField.gameObject.SetActive (true);
			inputField.Select();
			actionButtonText.text = ((char)0x2713).ToString ();
			plus = false;
			check = true;
			delete = false;
		}
		else if(check){
			text.text = inputField.text;
			inputField.gameObject.SetActive (false);
			text.gameObject.SetActive(true);
			actionButtonText.text = "x";
			plus = false;
			check = false;
			delete = true;

			// add new 'new task' task item panel
		}
		else if (delete) {
			plus = false;
			check = false;
			delete = false;
			text.gameObject.SetActive(false);
		}
	}

	// called by event trigger on Main Task Panel
	public void OpenTask(){
		if (!plus && !check) {
			print ("Open task");
			optionsPanel.SetActive (true);
		}
	}
}
