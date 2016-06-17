using UnityEngine;
using System.Collections;

public class CamraFollow : MonoBehaviour
{

    public Transform target;
    public float scailfactor = 4f;
    Camera cam;
    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        if (target)
        {
            transform.position = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

        cam.orthographicSize = (Screen.height / 100f) / scailfactor;
        if (target)
        {
            transform.position = Vector3.Lerp(cam.transform.position, target.transform.position, 0.1f) + Vector3.back * 10;
        }


    }
}
