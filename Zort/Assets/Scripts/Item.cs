using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int itemID;
    public string itemName;
    public string itemInfo;
    public Sprite itemIcon;
    public ItemType itemType;
    public int hpBonus;
    public int atkBonus;


    public enum ItemType {
        Empty,
        Shield,
        Weapon,
        Armor,
        Helmet,
        Consumable,
        Key
    }

	public Item (string name, string info, ItemType type, int health, int attack) {
        itemName = name;
        itemInfo = info;
        itemIcon = Resources.Load<Sprite>("Item Icons/" + name);
        itemType = type;
        hpBonus = health;
        atkBonus = attack;
	}
}
