using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public HerbController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = transform.parent.GetComponent<HerbController>();
    }

    // Update is called once per frame
    void Update()
    {
       // var dir = WorldPos - transform.position;
        //var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
