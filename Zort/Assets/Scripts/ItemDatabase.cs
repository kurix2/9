using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
    public List<Item> itemList = new List<Item>();

	// Use this for initialization
	void Start () {
        itemList.Add(new Item("Omega Axe", "It`s Oh So Mega!", 0, 0, 3));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
