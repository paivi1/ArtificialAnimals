using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoofScript : MonoBehaviour
{
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Drop", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Drop(){
		Instantiate(this.transform, this.transform.position, Quaternion.identity);
    }
}
