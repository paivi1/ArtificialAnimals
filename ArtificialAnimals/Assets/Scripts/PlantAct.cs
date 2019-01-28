using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAct : MonoBehaviour {

	private Rigidbody2D rb2d;
	private PlantController controller;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		controller = GetComponent<PlantController>();
		InvokeRepeating("PhotoSyn", 5.0f, 5.0f);
		InvokeRepeating("Reproduce", 10.0f, 15.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PhotoSyn(){
		if (controller.GetFullness() < 80 && controller.GetHydration() >= 10) {
			controller.SetFullness(20);
			controller.SetHydration(-10);
			
		}
	}

	void Reproduce(){
		if (controller.GetHealth() > 30) {
			float x = this.transform.position.x + Random.Range(-2.0f, 2.0f);
			float y = this.transform.position.y + Random.Range(-2.0f, 2.0f);
			Vector2 birthplace = new Vector2(x,y);
			Instantiate(this.transform, birthplace, Quaternion.identity);
		}
	}
}
