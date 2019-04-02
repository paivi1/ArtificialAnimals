using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject target;
    public Camera cam;
    [SerializeField]
    public Text txt1;
    public Text txt2;
    public Text txt3;
    public Text txt4;
    public Text txt5;
    public Text txt6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = cam.GetComponent<CameraController>().target1;
        if (target.GetComponent<HerbController>() != null){
            txt1.text = target.name.ToString();
            txt2.text = target.GetComponent<HerbController>().fullness.ToString();
            txt3.text = target.GetComponent<HerbController>().hydration.ToString();
            txt4.text = target.GetComponent<HerbController>().health.ToString();
            txt5.text = target.GetComponent<HerbController>().energy.ToString();
            //txt6.text = target.GetComponent<HerbController>().state.ToString();
            switch(target.GetComponent<HerbController>().state){
                case 0:
                    txt6.text = "Wandering";
                    break;
                case 1:
                    txt6.text = "Interested";
                    break;
                case 2:
                    txt6.text = "Scared";
                    break;
                default:
                    break;

            }
        }
        else if (target.GetComponent<CarnivoreController>() != null){
            txt1.text = target.name.ToString();
            txt2.text = target.GetComponent<CarnivoreController>().fullness.ToString();
            txt3.text = target.GetComponent<CarnivoreController>().hydration.ToString();
            txt4.text = target.GetComponent<CarnivoreController>().health.ToString();
            txt5.text = target.GetComponent<CarnivoreController>().energy.ToString();
            //txt6.text = target.GetComponent<HerbController>().state.ToString();
            switch(target.GetComponent<CarnivoreController>().state){
                case 0:
                    txt6.text = "Wandering";
                    break;
                case 1:
                    txt6.text = "Interested";
                    break;
                case 2:
                    txt6.text = "Scared";
                    break;
                default:
                    break;
            }

        }
        else if(target.GetComponent<PlantController>() != null){
            txt1.text = target.name.ToString();
            txt2.text = target.GetComponent<PlantController>().fullness.ToString();
            txt3.text = target.GetComponent<PlantController>().hydration.ToString();
            txt4.text = target.GetComponent<PlantController>().health.ToString();
            txt5.text = "N/A";
            txt6.text = "N/A";
        }
        
    }
}
