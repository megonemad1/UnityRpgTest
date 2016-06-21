using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MoveInventory : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 ofset;
    void start()
    {

    }
    void Update()
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        ofset = eventData.position - (Vector2)this.transform.parent.transform.position;
        Vector2 target = eventData.position;
        this.transform.parent.transform.position = target - ofset;
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 target = eventData.position;
        this.transform.parent.transform.position = target - ofset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
