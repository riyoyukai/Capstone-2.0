using UnityEngine;
using System.Collections;

public class MonsterBehavior : MonoBehaviour {

	private Monster monster = new Monster();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		monster.Update ();
	}

	public void EatFood(/*Food foodite*/){
		// TODO: 
		monster.EatFood ();
	}
}
