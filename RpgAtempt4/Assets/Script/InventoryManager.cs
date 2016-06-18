using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor;

public class InventoryManager : MonoBehaviour
{

    HandManager hand;
    public int InventoryWidth = 9;
    public int InventoryHight = 6;
    public Item[] inventory;
    [HideInInspector]
    [SerializeField]
    int selected_item;
    [ExposeProperty]
    public int SelectedItem
    {
        get
        {
            return selected_item;
        }
        set
        {

            if (value < InventoryHight * InventoryWidth && value >= -1)
            {
                selected_item = value;
            }

            else
            {
                Debug.Log("invalid inventory slot: " + value);
                selected_item = -1;
            }

        }
    }
    public Item[] GetAllItemsOfType(ItemType itemtype)
    {

        return Array.FindAll(inventory, (Item item) => { return item.GetItemTypes().Contains(itemtype); });
    }
    public bool addItem(Item item)
    {
        int index = Array.FindIndex(inventory, (Item i) => { return i == null; });
        if (index > -1)
        {
            SetInventoryPosition(index, item);
            return true;
        }
        return false;
    }
    public Item GetSelected()
    {
        if (selected_item > -1)
            return GetInventoryPosition(selected_item);
        else
            return null;
    }

    public InventoryManager SwapItems(int InventorySlotA, int InventorySlotB)
    {
        Item tempA = GetInventoryPosition(InventorySlotA);
        Item tempB = GetInventoryPosition(InventorySlotB);

        SetInventoryPosition(InventorySlotA, tempB);
        SetInventoryPosition(InventorySlotB, tempA);
        return this;
    }
    public InventoryManager SetInventoryPosition(int InventorySlotX, int InventorySlotY, Item item)
    {

        return SetInventoryPosition(InventorySlotX * InventoryWidth + InventorySlotY, item);
    }
    public InventoryManager SetInventoryPosition(int InventorySlot, Item item)
    {
        if (InventorySlot < inventory.Length && InventorySlot >= 0)
        {
            inventory[InventorySlot] = item;
        }
        else
        {
            Debug.Log("invalid set inventory slot: " + InventorySlot + "on item " + item);
        }
        return this;
    }
    public Item GetInventoryPosition(int InventorySlotX, int InventorySlotY)
    {
        return GetInventoryPosition(InventorySlotX * InventoryWidth + InventorySlotY);
    }
    public Item GetInventoryPosition(int InventorySlot)
    {
        if (InventorySlot < inventory.Length && InventorySlot >= 0)
        {
            return inventory[InventorySlot];
        }
        else
        {
            Debug.Log("invalid set inventory slot: " + InventorySlot);
            return null;
        }
    }
    // Use this for initialization
    void Start()
    {
        inventory = new Item[InventoryWidth * InventoryHight];
        SelectedItem = -1;

        hand = GetComponent<HandManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
[CustomEditor(typeof(InventoryManager))]
public class InventoryManagerEditor : Editor
{


    InventoryManager m_Instance;
    PropertyField[] m_fields;


    public void OnEnable()
    {
        m_Instance = target as InventoryManager;
        m_fields = ExposeProperties.GetProperties(m_Instance);
    }

    public override void OnInspectorGUI()
    {

        if (m_Instance == null)
            return;

        this.DrawDefaultInspector();

        ExposeProperties.Expose(m_fields);

    }
}
