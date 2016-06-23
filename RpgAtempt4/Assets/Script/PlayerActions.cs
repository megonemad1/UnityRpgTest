using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour
{
    PlayerMovement movementControler;
    CircleCollider2D colideroffset;
    Transform player;
    public float PlayerReach;
    InventoryManager inventoryManager;
    public int uicooldown = 0;
    public int CoolDownStep = 10;
    // Use this for initialization
    void Start()
    {
        movementControler = GetComponent<PlayerMovement>();
        player = GetComponent<Transform>();
        colideroffset = GetComponent<CircleCollider2D>();
        inventoryManager = GetComponent<InventoryManager>();
        inventoryManager.InventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        InventoryManagerold inventory = GetComponent<InventoryManagerold>();
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetAxisRaw((i + 1) + "Select") == 1)
                Debug.Log((i + 1) + " Down");
            // inventory.SelectedItem = i;
        }


        if (Input.GetAxisRaw("Submit") == 1)
        {
            Debug.Log(player.position.ToString() + "-" + (player.position + new Vector3(movementControler.Facing.normalized.x, movementControler.Facing.normalized.y) * PlayerReach).ToString());
            Vector3 Start = player.position + new Vector3(colideroffset.offset.x, colideroffset.offset.y, 0);
            Vector3 End = Start + new Vector3(movementControler.Facing.normalized.x, movementControler.Facing.normalized.y) * PlayerReach;
            Debug.DrawLine(Start, End);
            RaycastHit2D hit = Physics2D.Raycast(Start, movementControler.Facing, PlayerReach);

            if (hit && hit.collider.tag == "Actionable")
            {
                Debug.Log("action!");
                UseAction action = hit.transform.gameObject.GetComponent<UseAction>();
                if (action != null)
                    action.Activate(this.gameObject);


            }

        }
        if (Input.GetAxisRaw("Fire1") == 1)
        {

        }
        if (Input.GetAxisRaw("Cancel") == 1 && uicooldown <= 0)
        {
            uicooldown = CoolDownStep;
            inventoryManager.InventoryPanel.SetActive(false);
        }
        if (Input.GetAxisRaw("Inventory") == 1 && uicooldown <= 0)
        {
            uicooldown = CoolDownStep;
            inventoryManager.InventoryPanel.SetActive(!inventoryManager.InventoryPanel.activeSelf);
        }
        if (uicooldown > 0)
            uicooldown--;


    }
}
