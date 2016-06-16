using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rbody;
    Animator anim;
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
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        bool moving = movement != Vector2.zero;
        if (moving)
        {
            anim.SetFloat("Input_x", movement.x);
            anim.SetFloat("Input_y", movement.y);
            facing = movement;
        }
        anim.SetBool("Is_Walking", moving);
        rbody.MovePosition(rbody.position + movement * Time.deltaTime);


    }
}
