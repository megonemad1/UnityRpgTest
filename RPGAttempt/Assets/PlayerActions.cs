using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour
{
    PlayerMovement movementControler;
    CircleCollider2D colideroffset;
    Transform player;
    public float PlayerReach;
    // Use this for initialization
    void Start()
    {
        movementControler = GetComponent<PlayerMovement>();
        player = GetComponent<Transform>();
        colideroffset = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Submit")==1)
        {
            Debug.Log(player.position.ToString() + "-" + (player.position + new Vector3(movementControler.Facing.normalized.x, movementControler.Facing.normalized.y) * PlayerReach).ToString());
            Vector3 Start = player.position + new Vector3(colideroffset.offset.x, colideroffset.offset.y, 0);
            Vector3 End = Start + new Vector3(movementControler.Facing.normalized.x, movementControler.Facing.normalized.y) * PlayerReach;
            Debug.DrawLine(Start, End);
            RaycastHit2D hit = Physics2D.Raycast(Start, movementControler.Facing, PlayerReach, LayerMask.NameToLayer("Passive"), float.MinValue, float.MaxValue);
            if (hit)
            {
                Debug.Log("hit");
                if (hit.collider.tag == "Actionable")
                {

                    Debug.Log("action!");
                    UseAction action = hit.transform.gameObject.GetComponent<UseAction>();
                    if (action != null)
                        action.Activate(this.gameObject);
                }
                else
                    Debug.Log(hit.collider.tag);
            }
        }
    }
}
