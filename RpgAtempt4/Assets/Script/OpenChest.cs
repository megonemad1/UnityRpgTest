using UnityEngine;
using System.Collections;
using System;

public class OpenChest : MonoBehaviour, UseAction
{

    Animator anim;
    BoxCollider2D colider;
    public GameObject ItemType;
    public string item = "coin_copper";
    public int amount = 50;
    ItemDataBase itemdatabase;
    public UseAction Activate(GameObject sender)
    {

        anim.SetBool("Is_Open", true);
        colider.enabled = false;
        InventoryManager inventory = sender.GetComponent<InventoryManager>();
       
        if (inventory && inventory.AddItem(item, this.amount))
            return this;

        Item lootItem = itemdatabase.getItemByID(item);
        GameObject itemObj = Instantiate(this.ItemType);
        ItemData data = itemObj.GetComponent<ItemData>();
        data.amount = this.amount;
        data.item = lootItem;
        itemObj.transform.position = this.transform.position;
        itemObj.GetComponent<SpriteRenderer>().sprite = lootItem.sprite;
        return this;
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        colider = GetComponent<BoxCollider2D>();

        itemdatabase = GameObject.FindGameObjectWithTag("ItemDataBase").GetComponent<ItemDataBase>();
    }


}
