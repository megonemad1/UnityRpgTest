using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InventoryUiManager : MonoBehaviour
{
    public bool isInventoryVisible = true;
    public int cooldowndelay = 100;
    public int cooldown = 0;
    // Use this for initialization
    void Start()
    {
        this.gameObject.SetActive(isInventoryVisible);
    }

    // Update is called once per frame
    void Update()
    {
        if (!(Input.GetAxisRaw("Cancel") == 1) && cooldown <= 0)
        {
            isInventoryVisible = false;
        }
        if (Input.GetAxisRaw("Inventory") == 1 && cooldown<=0)
        {
            isInventoryVisible = !isInventoryVisible;
        }
        if (cooldown > 0)
            cooldown--;
        this.gameObject.SetActive(isInventoryVisible);
    }


}
