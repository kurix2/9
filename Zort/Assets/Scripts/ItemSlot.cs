using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public Item slottedItem;
    private Item emptyItem;
    private Color emptyColor;

    // Use this for initialization
    void Start()
    {
        emptyItem = slottedItem;
        emptyColor = new Color32(117, 142, 142, 255);
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

    public void OnPointerClick(PointerEventData eventData)
    {
        
        {
            print("hit");
            GetComponent<Image>().color = Color.white;
        }
    }
}
