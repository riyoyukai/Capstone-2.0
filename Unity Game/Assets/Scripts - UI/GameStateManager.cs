using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {
	
	public void GSM_SwitchToTaskList(){
		Application.LoadLevel ("TaskList");
	}
	
	public void GSM_SwitchToPlay(){
		Application.LoadLevel ("Play");
	}
	
	public void GSM_SwitchToPetProfile(){
		Application.LoadLevel ("PetProfile");
	}
}
