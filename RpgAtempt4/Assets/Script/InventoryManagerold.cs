using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor;

public class InventoryManagerold : MonoBehaviour
{
    public GameObject InventoryPanel, SlotPanel, InventorySlot, InventoryItem;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        
    }

}
//    HandManager hand;
//    public int InventoryWidth = 9;
//    public int InventoryHight = 6;
//    public oldItem[] inventory;
//    [HideInInspector]
//    [SerializeField]
//    int selected_item;
//    [ExposeProperty]
//    public int SelectedItem
//    {
//        get
//        {
//            return selected_item;
//        }
//        set
//        {

//            if (value < InventoryHight * InventoryWidth && value >= -1)
//            {
//                selected_item = value;
//            }

//            else
//            {
//                Debug.Log("invalid inventory slot: " + value);
//                selected_item = -1;
//            }

//        }
//    }
//    public oldItem[] GetAllItemsOfType(ItemType itemtype)
//    {

//        return Array.FindAll(inventory, (oldItem item) => { return item.GetItemTypes().Contains(itemtype); });
//    }
//    public bool addItem(oldItem item)
//    {
//        int index = Array.FindIndex(inventory, (oldItem i) => { return i == null; });
//        if (index > -1)
//        {
//            SetInventoryPosition(index, item);
//            return true;
//        }
//        return false;
//    }
//    public oldItem GetSelected()
//    {
//        if (selected_item > -1)
//            return GetInventoryPosition(selected_item);
//        else
//            return null;
//    }

//    public InventoryManager SwapItems(int InventorySlotA, int InventorySlotB)
//    {
//        oldItem tempA = GetInventoryPosition(InventorySlotA);
//        oldItem tempB = GetInventoryPosition(InventorySlotB);

//        SetInventoryPosition(InventorySlotA, tempB);
//        SetInventoryPosition(InventorySlotB, tempA);
//        return this;
//    }
//    public InventoryManager SetInventoryPosition(int InventorySlotX, int InventorySlotY, oldItem item)
//    {

//        return SetInventoryPosition(InventorySlotX * InventoryWidth + InventorySlotY, item);
//    }
//    public InventoryManager SetInventoryPosition(int InventorySlot, oldItem item)
//    {
//        if (InventorySlot < inventory.Length && InventorySlot >= 0)
//        {
//            inventory[InventorySlot] = item;
//        }
//        else
//        {
//            Debug.Log("invalid set inventory slot: " + InventorySlot + "on item " + item);
//        }
//        return this;
//    }
//    public oldItem GetInventoryPosition(int InventorySlotX, int InventorySlotY)
//    {
//        return GetInventoryPosition(InventorySlotX * InventoryWidth + InventorySlotY);
//    }
//    public oldItem GetInventoryPosition(int InventorySlot)
//    {
//        if (InventorySlot < inventory.Length && InventorySlot >= 0)
//        {
//            return inventory[InventorySlot];
//        }
//        else
//        {
//            Debug.Log("invalid set inventory slot: " + InventorySlot);
//            return null;
//        }
//    }
//    // Use this for initialization
//    void Start()
//    {
//        inventory = new oldItem[InventoryWidth * InventoryHight];
//        SelectedItem = -1;

//        hand = GetComponent<HandManager>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
//[CustomEditor(typeof(InventoryManager))]
//public class InventoryManagerEditor : Editor
//{


//    InventoryManager m_Instance;
//    PropertyField[] m_fields;


//    public void OnEnable()
//    {
//        m_Instance = target as InventoryManager;
//        m_fields = ExposeProperties.GetProperties(m_Instance);
//    }

//    public override void OnInspectorGUI()
//    {

//        if (m_Instance == null)
//            return;

//        this.DrawDefaultInspector();

//        ExposeProperties.Expose(m_fields);

//    }
//}
