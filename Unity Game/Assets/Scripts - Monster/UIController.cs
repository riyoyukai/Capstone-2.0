using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	private static UIController _instance;
	public static UIController instance{
		get{
			if(!_instance){
				_instance = (UIController) GameObject.FindObjectOfType(typeof(UIController));
				if(!_instance){
					GameObject container = new GameObject();
					container.name = "UIController";
					_instance = (UIController) container.AddComponent(typeof(UIController));
				}
			}

			return _instance;
		}
	}

	public Text alertText;
	public Text hungerText;

	private float alertTimer = 0;
	private float alertTimerMax = 5; // seconds

	public void Alert(string msg){
		alertText.text = msg;
		alertTimer = alertTimerMax;
		alertText.gameObject.SetActive(true);
	}

	public void UpdatePetStats(float hunger){
		string hungerDec = hunger.ToString (".#");
		if(hungerDec.Length < 3) hungerDec += ".0";
		hungerText.text = "Hunger: "+hungerDec+"/100";
	}

	void Awake(){
		alertText.gameObject.SetActive(false);
	}

	void Update(){
		if(alertTimer > 0) alertTimer-= Time.deltaTime;
		if(alertTimer < 0){
			alertTimer = 0;
			alertText.gameObject.SetActive(false);
		}
	}
}
