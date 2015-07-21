using UnityEngine;
using System.Collections;

public class Monster {
	private float hunger = 35; // percent
	private bool hungry = false;

	//private int sleepThisLong = 8; // hours
	//private float sleepiness = 100; // percent
	//private bool sleepy = false;
	//private bool asleep = false;

	public void Update(){
		hunger -= Time.deltaTime;
		UIController.instance.UpdatePetStats(hunger);
		if(!hungry && hunger/100 < .3){
			hungry = true;
			UIController.instance.Alert("I'm hungry!");
		}
	}

	public void EatFood(){
		hunger = 100;
		hungry = false;
		UIController.instance.Alert("Yumm!!");
	}
}
