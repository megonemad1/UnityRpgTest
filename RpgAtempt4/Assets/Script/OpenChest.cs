using UnityEngine;
using System.Collections;
using System;

public class OpenChest : MonoBehaviour, UseAction {

    Animator anim;
    BoxCollider2D colider;

    public UseAction Activate(GameObject sender)
    {

        anim.SetBool("Is_Open", true);
        colider.enabled = false;
        return this;
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        colider = GetComponent<BoxCollider2D>();
    }
	
	
}
