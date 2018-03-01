using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory Instance { get; set; }

    public List<Item> inventory = new List<Item>();
    public Item eqpedHelm, eqpedArmor, eqpedWeapon, eqpedShield;
    public ItemSlot headSlot, bodySlot, leftSlot, rightSlot;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else { Instance = this; }
    }

    // Use this for initialization
    void Start() {
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

    public void AddItem(Item newItem)
    {
        //Equip if Better
        if (BetterThanEquipped(newItem))
        {
            EquipItem(newItem);
        }
        else
        {
        inventory.Add(newItem);

        }
    }

    #region Equipped Inventory

    public void EquipItem(Item newItem)
    {
        switch (newItem.itemType)
        {
            case Item.ItemType.Shield:
                eqpedShield = newItem;
                leftSlot.SlotItem(newItem);
                break;
            case Item.ItemType.Weapon:
                eqpedWeapon = newItem;
                rightSlot.SlotItem(newItem);
                print("equipped weapon");
                break;
            case Item.ItemType.Armor:
                eqpedArmor = newItem;
                bodySlot.SlotItem(newItem);
                break;
            case Item.ItemType.Helmet:
                eqpedHelm = newItem;
                headSlot.SlotItem(newItem);
                break;
            default:
                print("undefined equip type");
                break;
        }
        BattleManager.Instance.playerAtk += newItem.atkBonus;
        BattleManager.Instance.playerMxHp += newItem.hpBonus;
        BattleManager.Instance.playerHp += newItem.hpBonus;
        BattleManager.Instance.hpHearts.GetComponent<HeartHp>().CalculateHp();
    }

    public void UnequipItem(Item oldItem)
    {
        switch (oldItem.itemType)
        {
            case Item.ItemType.Shield:
                eqpedShield = new Item("_emptyLeft", "", Item.ItemType.Empty, 0, 0);
                leftSlot.SlotItem(eqpedShield);
                break;
            case Item.ItemType.Weapon:
                eqpedWeapon = new Item("_emptyRight", "", Item.ItemType.Empty, 0, 0);
                rightSlot.SlotItem(eqpedWeapon);
                print("equipped weapon");
                break;
            case Item.ItemType.Armor:
                eqpedArmor = new Item("_emptyBody", "", Item.ItemType.Empty, 0, 0);
                bodySlot.SlotItem(eqpedArmor);
                break;
            case Item.ItemType.Helmet:
                eqpedHelm = new Item("_emptyHead", "", Item.ItemType.Empty, 0, 0);
                headSlot.SlotItem(eqpedHelm);
                break;
            default:
                print("undefined equip type");
                break;
        }
        BattleManager.Instance.playerAtk -= oldItem.atkBonus;
        BattleManager.Instance.playerMxHp -= oldItem.hpBonus;
        BattleManager.Instance.playerHp -= oldItem.hpBonus;
        BattleManager.Instance.hpHearts.GetComponent<HeartHp>().CalculateHp();
    }

    #endregion

    public bool CheckItem(string item)
    {
        bool result = false;

        Item[] equipped = { eqpedHelm, eqpedArmor, eqpedWeapon, eqpedShield };
        for (int i = 0; i < equipped.Length; i++)
        {
            if (equipped[i].itemName == item)
            {
                result = true;
                break;
            }
        }
        if (result == false)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if(inventory[i].itemName == item)
                {
                    result = true;
                    break;
                }
            }
        }

        return result;
        
    }


    public void DeleteItem(string item)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == item)
            {
                inventory[i] = new Item("Empty", "", 0, 0, 0);
                break;
            }
        }
    }

    bool BetterThanEquipped(Item item)
    {
        bool result = false;

        switch (item.itemType)
        {
            case Item.ItemType.Shield:
                if (item.hpBonus>eqpedShield.hpBonus)
                {
                    result = true;
                }
                break;
            case Item.ItemType.Weapon:
                if (item.atkBonus>eqpedWeapon.atkBonus)
                {
                    result = true;
                }
                break;
            case Item.ItemType.Armor:
                if (item.hpBonus>eqpedArmor.hpBonus)
                {
                    result = true;
                }
                break;
            case Item.ItemType.Helmet:
                if (item.hpBonus>eqpedHelm.hpBonus)
                {
                    result = true;
                }
                break;
            default:
                break;
        }

        return result;
    }


    public void DebugTest()
    {
        UnequipItem(eqpedWeapon);
    }
}
