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
    public UseAction Activate(GameObject sender)
    {

        anim.SetBool("Is_Open", true);
        colider.enabled = false;
        InventoryManager inventory = sender.GetComponent<InventoryManager>();
        ItemDataBase database = sender.GetComponent<ItemDataBase>();
        if (inventory)
        {
            //oldItem newloot = Instantiate<oldItem>(loot);
            if (!inventory.AddItem(item, this.amount))
            {
                Item lootItem = database.getItemByID(item);
                GameObject itemObj = Instantiate(this.ItemType);
                ItemData data = itemObj.GetComponent<ItemData>();
                data.amount = this.amount;
                data.item = lootItem;
                itemObj.transform.position = this.transform.position;
                itemObj.GetComponent<SpriteRenderer>().sprite=lootItem.sprite;
            }
        }
        return this;
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        colider = GetComponent<BoxCollider2D>();
    }


}
