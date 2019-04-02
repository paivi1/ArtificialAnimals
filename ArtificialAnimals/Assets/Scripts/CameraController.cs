using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target1;
    public GameObject spr;
    public float scale = 4f;
    public float moveSpeed = 0.1f;
    private Transform t1;
    private Camera cam;
    private Vector3 mousePosition;
    private Vector3 setPos;
    private bool following;




    // Use this for initialization
    void Start()
    {   
        cam = GetComponent<Camera>();
        following = false;
        setPos = new Vector3 (0,-20,-10);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (following) {
            transform.position = new Vector3 (target1.transform.position.x, target1.transform.position.y, -10);
        }
        else {
            if (Input.GetKey("up")){
             setPos = setPos + Vector3.up;
            }
            if (Input.GetKey("down")){
             setPos = setPos + Vector3.down;
            }
            if (Input.GetKey("left")){
             setPos = setPos + Vector3.left;
            }
            if (Input.GetKey("right")){
             setPos = setPos + Vector3.right;
            }
            transform.position = setPos;
        
        }
        if (Input.GetKey("a")){
            cam.orthographicSize += 1;
        }
        if (Input.GetKey("s") && cam.orthographicSize > 5){
            cam.orthographicSize -= 1;
        }
         
        if (Input.GetMouseButton(1)) {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
            setPos = mousePosition;
        }
        if (Input.GetMouseButton(0)){
            
            mousePosition = (Input.mousePosition - setPos + new Vector3 (-5,27, 0));
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Collider2D clicked = Physics2D.OverlapCircle(mousePosition, 1.0f);
            Debug.Log(mousePosition);
            Debug.Log(clicked);
            Instantiate(spr, mousePosition, Quaternion.identity);

            if (clicked != null){
                target1 = clicked.gameObject;
            }


        }

        

        if(Input.GetKeyDown("f")){
            if (following) {
                following = false;
                setPos = new Vector3 (0,-20,-10);
                cam.orthographicSize = 25;
            }
            else {
                following = true;
            }
        }


    }
 
}