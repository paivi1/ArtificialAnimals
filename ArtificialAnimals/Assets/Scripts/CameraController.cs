using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target1;
    public float scale = 4f;

    private Transform t1;
    private Camera cam;


    // Use this for initialization
    void Start()
    {   
        cam = GetComponent<Camera>();
        t1 = target1.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target1 != null)
        {
            transform.position = new Vector3(t1.position.x, t1.position.y, -10);
            cam.orthographicSize = 25;
            
        }
    }
}