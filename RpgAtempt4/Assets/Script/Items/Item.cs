using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class Item :MonoBehaviour{


    public abstract void UseItem(GameObject sender);

    public abstract List<ItemType> GetItemTypes();
    
   
}
public enum ItemType
{
    Buff,
    Debuf,
    Ammo,
    weppon
}

