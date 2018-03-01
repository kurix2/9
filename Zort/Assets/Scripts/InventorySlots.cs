using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour {
    private List<GameObject> slotsList = new List<GameObject>();
    private List<Item> inventoryList = new List<Item>();

    private void Awake()
    {
        inventoryList = GameObject.Find("GameManager").GetComponent<Inventory>().inventory;
        GetChildren();
        SynchSlots();
    }

    private void GetChildren()
    {
        foreach (Transform child in transform)
        {
            slotsList.Add(child.gameObject);
        }
    }

    public void SynchSlots()
    {
        //Half assed attempt to avoid inventory overflow TODO make a way to increase inventory space if necessary
        int slotMax;
        if(inventoryList.Count <= slotsList.Count)
        {
            slotMax = inventoryList.Count;
        }
        else
        {
            slotMax = slotsList.Count;
        }

        for (int i = 0; i < inventoryList.Count; i++)
        {
            Transform child = slotsList[i].transform.GetChild(0);
            child.GetComponent<Image>().sprite = inventoryList[i].itemIcon;
            child.GetComponent<Image>().color = Color.white;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
