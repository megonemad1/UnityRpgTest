using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using UnityEngine.UI;

public class ItemData : MonoBehaviour,  IBeginDragHandler,IDragHandler, IEndDragHandler , IPointerEnterHandler, IPointerExitHandler {

    public Item item;
    public int slotnumber;
    public int amount=1;
    Vector2 ofset;
    public GameObject inventory;
    public ToolTipManager tooltipManager;
    void start()
    {
    }
    void Update()
    {
        if (ofset != Vector2.zero)
        {
            Vector2 newofset = Vector2.Lerp(ofset, Vector2.zero, 0.1f);
            Vector2 ofsetdiff = newofset-ofset;
            this.transform.position -=(Vector3) ofsetdiff;
            ofset = newofset;
        }

    }
  
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(item);
        if (item != null)
        {
            ofset = eventData.position -(Vector2) this.transform.position;
            //layout.ignoreLayout = true;
            gameObject.transform.SetParent(this.transform.parent.parent.parent);
            this.transform.position = eventData.position-ofset;

            GetComponent<CanvasGroup>().blocksRaycasts = false;


        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position-ofset;
            
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            //layout.ignoreLayout = false;
            this.transform.position = Vector2.zero;
            Debug.Log("slotnumvber: " + slotnumber);
            Debug.Log("inventory? " + (inventory!=null));
            Debug.Log("boop: " + inventory.GetComponent<InventoryManager>().items[slotnumber]);
            this.transform.SetParent(inventory.GetComponent<InventoryManager>().slots[slotnumber].transform);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipManager.Activate(this.item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipManager.Deactivate();
    }
}
