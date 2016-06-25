using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour
{
    CircleCollider2D colideroffset;
    Transform player;
    public float PlayerReach;
    InventoryManager inventoryManager;
    public int uicooldown = 0;
    public int CoolDownStep = 10;
    public bool flighting;
    public bool Drawn;
    public bool arrowReady;
    public GameObject arrow;
    public GameObject hand;
    LivingStatsManager stats;
    Rigidbody2D rbody;
    Animator anim;
    public Camera camra;
    public Vector2 Facing
    {
        get
        {
            return facing;
        }
    }

    public Vector2 facing;
    // Use this for initialization
    void Start()
    {
     
        player = GetComponent<Transform>();
        colideroffset = GetComponent<CircleCollider2D>();
        inventoryManager = GetComponent<InventoryManager>();
        inventoryManager.InventoryPanel.SetActive(false);
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        stats = GetComponent<LivingStatsManager>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousepos = camra.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetAxisRaw("Fire1") == 1 && !inventoryManager.InventoryPanel.activeSelf)
        {
            flighting = true;

            anim.SetFloat("Aim_x", mousepos.x-this.transform.position.x);
            anim.SetFloat("Aim_y", mousepos.y - this.transform.position.y);
        }
        else
        {
            flighting = false;
        }
        float Speed = stats.WalkingSpeed;
        if (Input.GetAxisRaw("Fire3") == 1)
        {
            Speed *= stats.runningModifyer;
        }
        anim.SetFloat("Speed", Speed);
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        bool moving = movement != Vector2.zero;
        anim.SetBool("Is_Walking", moving);
        rbody.MovePosition(rbody.position + movement * Speed * Time.deltaTime);
        if (moving)
        {
            anim.SetFloat("Input_x", movement.x);
            anim.SetFloat("Input_y", movement.y);
            facing = movement;
            flighting = false;
        }
        //if arrow drawn && not flighting 
        //create arrow and fire it, then drawn arrow = false;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ArrowDrawn")&&!flighting)
        {
            arrowReady = true;
        }
        if (arrowReady && !anim.GetCurrentAnimatorStateInfo(0).IsName("ArrowDrawn"))
        {
            arrowReady = false;
            Debug.Log("fire");
            flighting = false;
            GameObject arrowObj = Instantiate(arrow);
            Rigidbody2D arrowrbody = arrowObj.GetComponent<Rigidbody2D>();
            //get hand of player
            arrowObj.transform.position = this.transform.position+(Vector3)facing*PlayerReach;


            Vector2 difference = mousepos-(Vector2)transform.position;
            float AngleRad = Mathf.Atan2(difference.y, difference.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            arrowObj.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
            //      Vector2 mousePos = Input.mousePosition;

            //float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            //  arrowrbody.rotation = rotationZ;
            // arrowObj.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
            // arrowObj.transform.rotation.

            arrowrbody.AddForce(difference.normalized * 1000);
        }

        anim.SetBool("FlightingArrow",flighting);
        InventoryManagerold inventory = GetComponent<InventoryManagerold>();
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetAxisRaw((i + 1) + "Select") == 1)
                Debug.Log((i + 1) + " Down");
            // inventory.SelectedItem = i;
        }


        if (Input.GetAxisRaw("Submit") == 1)
        {
            Debug.Log(player.position.ToString() + "-" + (player.position + new Vector3(Facing.normalized.x, Facing.normalized.y) * PlayerReach).ToString());
            Vector3 Start = player.position + new Vector3(colideroffset.offset.x, colideroffset.offset.y, 0);
            Vector3 End = Start + new Vector3(Facing.normalized.x, Facing.normalized.y) * PlayerReach;
            Debug.DrawLine(Start, End);
            RaycastHit2D hit = Physics2D.Raycast(Start, Facing, PlayerReach);

            if (hit && hit.collider.tag == "Actionable")
            {
                Debug.Log("action!");
                UseAction action = hit.transform.gameObject.GetComponent<UseAction>();
                if (action != null)
                    action.Activate(this.gameObject);


            }

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
