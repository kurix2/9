using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
    public static ItemDatabase Instance { get; set; }

    public List<Item> itemList = new List<Item>();
    //[HideInInspector] public Item itemStock;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else { Instance = this; }
    }

    // Use this for initialization
    void Start () {
        itemList.Add(new Item("Empty", "", 0, 0, 0));
        itemList.Add(new Item("Omega Axe", "It`s Oh So Mega!", Item.ItemType.Weapon, 0, 3));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*public void StockItem(Item stockItem)
    {
        itemStock = stockItem;
    }

    public void ClearStock()
    {
        itemStock = null;
    }*/
}
