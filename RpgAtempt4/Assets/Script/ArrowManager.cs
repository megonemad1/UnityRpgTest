using UnityEngine;
using System.Collections;

public class ArrowManager : MonoBehaviour
{
    Rigidbody2D rbody;
    public float minVelocity = 1;
    public int MaxLifeTime = 10;
    int alivetime = 0;
    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (rbody.velocity.magnitude < minVelocity && alivetime > 5)
        {
            Destroy(this.gameObject);
        }
        else
        {


            Vector2 difference = rbody.velocity;
            float AngleRad = Mathf.Atan2(difference.y, difference.x);
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            this.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(rbody.rotation, AngleDeg, 0.1f));
        }
        if (alivetime > MaxLifeTime)
        {
            Destroy(this.gameObject);
        }
        alivetime++;

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("hit");
       if ( coll.collider.tag == "Actionable")
       {
            Debug.Log("action!");
            UseAction action = coll.gameObject.GetComponent<UseAction>();
            if (action != null)
                action.Activate(this.gameObject);
       }
        LivingStatsManager stats = coll.gameObject.GetComponent<LivingStatsManager>();
        if (stats)
        {
            stats.Health--;
            Destroy(this.gameObject);
        }
    }
}
