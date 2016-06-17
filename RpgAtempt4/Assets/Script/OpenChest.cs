using UnityEngine;
using System.Collections;
using System;

public class OpenChest : MonoBehaviour, UseAction
{

    Animator anim;
    BoxCollider2D colider;
    public Item loot;

    public UseAction Activate(GameObject sender)
    {

        anim.SetBool("Is_Open", true);
        colider.enabled = false;
        InventoryManager inventory = sender.GetComponent<InventoryManager>();
        if (inventory)
        {
            if (!inventory.addItem(loot))
            {
                Item newloot = Instantiate<Item>(loot);
                newloot.transform.position = this.transform.position;
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
