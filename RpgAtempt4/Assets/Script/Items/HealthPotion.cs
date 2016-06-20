using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class HealthPotion : oldItem {
    public List<ItemType> ItemTypes;
    public override List<ItemType> GetItemTypes()
    {
        return ItemTypes;
    }

    public override void UseItem(GameObject sender)
    {
        LivingStatsManager stats = sender.GetComponent<LivingStatsManager>();
        if (stats)
        {
            stats.Health += 20;
        }
    }

    // Use this for initialization
    void Start () {
        ItemTypes = new List<ItemType>();
        ItemTypes.Add(ItemType.useable);
        ItemTypes.Add(ItemType.Buff);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
