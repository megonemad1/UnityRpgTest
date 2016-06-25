using UnityEngine;
using System.Collections;

public class InWorldItemManager : MonoBehaviour
{
    ItemData itemData;
    // Use this for initialization
    void Start()
    {
        itemData = this.GetComponent<ItemData>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("item");
        InventoryManager inventory = coll.gameObject.GetComponent<InventoryManager>();

        if (inventory)
            if (inventory.AddItem(itemData.item.id, itemData.amount))
                Destroy(this.gameObject);
    }
}
