using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameData {
	public static Monster activeMonster;
	public static List<Monster> monsters;
	public static List<Item> inventory = new List<Item>();
	public static List<Item> envInventory = new List<Item>();

	public static void TestInventory(){
		inventory.Add(new Item("Toy"));
		inventory.Add(new Item("Toy"));
		inventory.Add(new Item("Toy"));
	}
}
