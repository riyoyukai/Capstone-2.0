using UnityEngine;
using System.Collections;

public class Item {
	private string path = "Images/";
	public string name;
	public string textureName;
	public bool inInventory = true;

	public Item(string itemName){
		name = itemName;
		textureName = path;
		switch(name){
			case "Toy":
			textureName += "lightswitch1";
			break;
		}
	}
}