using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class Item : MonoBehaviour
{


    SpriteRenderer render;
    Collider[] coliders;

    public abstract void UseItem(GameObject sender);


    public abstract List<ItemType> GetItemTypes();

    public void setVisible(bool visible)
    {
        if (render)
            render.enabled = visible;
        if (coliders != null)
            foreach (Collider c in coliders)
                c.enabled = visible;
    }
    void Start()
    {
        coliders = GetComponents<Collider>();
        render = GetComponent<SpriteRenderer>();
    }
}
public enum ItemType
{
    Buff,
    Debuf,
    Ammo,
    weppon,
    useable
}

