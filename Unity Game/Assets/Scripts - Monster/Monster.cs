using UnityEngine;
using System.Collections;

public class Monster {
	private float hunger = 35; // percent
	private bool hungry = false;
	private int xp;
	private int level;
	private int xpToNextLevel;
	private int totalXP;

	//private int sleepThisLong = 8; // hours
	//private float sleepiness = 100; // percent
	//private bool sleepy = false;
	//private bool asleep = false;

	void Awake(){
		xp = 0;
		level = 1;
		xpToNextLevel = 100;
	}

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

	public void AddXP(int xpToAdd){
		if (xp + xpToAdd > xpToNextLevel) {
			level++;
			xp = xp + xpToAdd - xpToNextLevel;
			xpToNextLevel = level * 100;
		} else {
			xp += xpToAdd;
		}
	}
}
