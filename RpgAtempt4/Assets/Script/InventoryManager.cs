using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public GameObject InventoryPanel, InventorySlot, InventoryItem;
    GameObject SlotPanel;
    ItemDataBase itemdatabase;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    public int SlotAmount = 54;
    // Use this for initialization
    void Start()
    {

        SlotPanel = InventoryPanel.transform.FindChild("Slot Panel").gameObject;
        itemdatabase = GetComponent<ItemDataBase>();
        for (int i = 0; i < SlotAmount; i++)
        {
            GameObject inventorySlot = Instantiate(InventorySlot);
            InventorySlotData inventorySlotData = inventorySlot.GetComponent<InventorySlotData>();
            inventorySlotData.inventoryObj = this.gameObject;
            inventorySlotData.slotnumber = i;
            inventorySlot.name = "slot" + inventorySlotData.slotnumber;
            inventorySlot.transform.SetParent(SlotPanel.transform);
            Item item = new Item();
            items.Add(item);
            slots.Add(inventorySlot);
        }

        AddItem("bow");

        AddItem("coin_copper",50);

    }
    public bool AddItem(string id)
    {
        return AddItem(id, 1);
    }
    public bool AddItem(string id, int SlotAmountToAdd)
    {

        Item item = itemdatabase.getItemByID(id);
        if (item.stackable)
        {
            int prexsistingindex = items.FindIndex((Item i) => { return i.id == item.id; });
            if (prexsistingindex > -1)
            {
                ItemData data = slots[prexsistingindex].transform.GetChild(0).GetComponent<ItemData>();
                data.amount += SlotAmountToAdd;
                Text StackAmoutText = data.transform.GetChild(0).GetComponent<Text>();
                StackAmoutText.text = (data.amount > 1) ? data.amount.ToString() : "";
                return true;
            }
        }
        int index = items.FindIndex((Item i) => { return i.id == ""; });
        if (index > -1)
        {
            items[index] = item;
           
            GameObject itemObj = Instantiate(InventoryItem);
            ItemData data = itemObj.GetComponent<ItemData>();
            data.amount += SlotAmountToAdd;
            data.item = item;
            data.slotnumber = index;
            data.inventory = this.gameObject;
            data.tooltipManager = GetComponent<ToolTipManager>();
            Text StackAmoutText = data.transform.GetChild(0).GetComponent<Text>();
            StackAmoutText.text = (data.amount>1)?data.amount.ToString():"";
            itemObj.transform.SetParent(slots[index].transform);
            itemObj.transform.position = Vector2.zero;
            itemObj.GetComponent<Image>().sprite = item.sprite;
            itemObj.GetComponent<ItemData>().amount = SlotAmountToAdd;

            itemObj.name = item.title;
            return true;
        }
        else
            return false;
    }
    public bool RemoveItemById(string id)
    {
        return RemoveItemById(id, 1);
    }
    public bool RemoveItemById(string id, int ItemAmountToRemove)
    {
        int index = items.FindIndex((Item i) => { return i.id == id; });
        return RemoveItemByIndex(index, ItemAmountToRemove);
    }
    public bool RemoveItemByIndex(int index)
    {
       return RemoveItemByIndex(index, 1);
    }
        bool RemoveItemByIndex(int index, int ItemAmountToRemove)
    {
        if (index > -1)
        {
            if (items[index].stackable)
            {
                ItemData data = slots[index].transform.GetChild(0).GetComponent<ItemData>();
                data.amount -= ItemAmountToRemove;
                if (data.amount > 0)
                {
                    Text StackAmoutText = data.transform.GetChild(0).GetComponent<Text>();
                    StackAmoutText.text = data.amount.ToString();
                    return true;
                }
            }
            GameObject item = slots[index].transform.GetChild(0).gameObject;
            slots[index].transform.DetachChildren();
            Destroy(item);
            items[index] = new Item();

        }
        return false;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
