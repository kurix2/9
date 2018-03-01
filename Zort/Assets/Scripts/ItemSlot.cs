using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item slottedItem;
    private Item emptyItem;
    private Color emptyColor;

    // Use this for initialization
    void Start()
    {
        emptyItem = slottedItem;
        emptyColor = new Color(0.25F, 0.36f, 0.36f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SlotItem(Item itemToSlot)
    {
        slottedItem = itemToSlot;
        this.GetComponent<Image>().sprite = slottedItem.itemIcon;
        if (itemToSlot.itemType==Item.ItemType.Empty)
        {
            this.GetComponent<Image>().color = emptyColor;
        }
        else
        {
        this.GetComponent<Image>().color = Color.white;

        }
    }

    public void UnslotItem()
    {
        slottedItem = emptyItem;
        this.GetComponent<Image>().sprite = slottedItem.itemIcon;
        this.GetComponent<Image>().color = emptyColor;
    }
}
