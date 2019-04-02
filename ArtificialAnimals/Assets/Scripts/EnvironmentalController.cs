using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalController : MonoBehaviour
{
    public bool rain = false;
    public Camera cam;
    private Color rainColor = new Color(0.3133395f,0.4528302f,0.1986472f);
    private Color regColor = new Color(0.4089143f,0.5849056f,0.2621039f);
    private float t,s = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckRain", 10.0f, 10.0f);
    }

    void CheckRain()
    {
        // Gets a random number from 0.1 - 1.0
        float num = Random.Range(0.1f, 1.0f);

        // If the number is greater than 0.5 then flip the boolean
        if (num > 0.5)
        {
            rain = true;
        }
        else {
            rain = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (rain == true)
        {
            s = 0f;
            cam.backgroundColor = Color.Lerp(regColor, rainColor, t);
            t += 0.05f;
        }
        else if (rain == false)
        {
            t = 0f;
            cam.backgroundColor = Color.Lerp(rainColor, regColor, s);
            s += 0.05f;
        }
    }
}
