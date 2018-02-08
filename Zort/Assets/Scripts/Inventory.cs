using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> inventory = new List<Item>();
    private ItemDatabase database;

    // Use this for initialization
    void Start() {
        database = this.GetComponent<ItemDatabase>();
        inventory.Add(database.itemList[0]);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            print("The following items are in inventory... ");
            for (int i = 0; i < inventory.Count; i++)
            {
                print(inventory[i].itemName);
            }
        }
    }
}
