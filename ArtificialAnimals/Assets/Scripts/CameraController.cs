using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target1;
    public float scale = 4f;

    private Transform t1;
    private Camera cam;
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;



    // Use this for initialization
    void Start()
    {   
        cam = GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
         
        if (Input.GetMouseButton(1)) {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
        }
        if (Input.GetMouseButton(0)){
            
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Collider2D clicked = Physics2D.OverlapPoint(mousePosition);
            Debug.Log(mousePosition);
            Debug.Log(clicked);

            if (clicked != null){
                target1 = clicked.gameObject;
            }


        }


    }
 
}