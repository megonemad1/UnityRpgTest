using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class InventorySlotData : MonoBehaviour, IDropHandler
{
    public GameObject inventoryObj;
    public int slotnumber;
    public void OnDrop(PointerEventData eventData)
    {
        InventoryManager inventory = this.inventoryObj.GetComponent<InventoryManager>();

        ItemData dropeditem = eventData.pointerDrag.GetComponent<ItemData>();
        if (dropeditem)
        {
            if (inventory.items[slotnumber].id == "")
            {
                inventory.items[dropeditem.slotnumber] = new Item();
                inventory.items[slotnumber] = dropeditem.item;
                dropeditem.slotnumber = slotnumber;
            }
            else
            {
                Transform currentItem = this.transform.GetChild(0);
                ItemData currentItemData = currentItem.GetComponent<ItemData>();
                currentItemData.slotnumber = dropeditem.slotnumber;
                currentItem.transform.SetParent(inventory.slots[dropeditem.slotnumber].transform);

                dropeditem.slotnumber = slotnumber;
                dropeditem.transform.SetParent(this.transform);

                inventory.items[dropeditem.slotnumber] = currentItemData.item;
                inventory.items[this.slotnumber] = dropeditem.item;
            }
        }


    }

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
}
