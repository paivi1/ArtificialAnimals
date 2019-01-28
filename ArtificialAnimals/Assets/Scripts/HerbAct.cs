﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbAct : MonoBehaviour {

	public float speed = 10;
	private GameObject focus;
	private Vector2 direction;


	private Rigidbody2D rb2d;
	private HerbController controller;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		controller = GetComponent<HerbController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.hunted){

		}
		else{
			
			Wander();
			
		}
		
	}

	void Wander(){
			Vector2 bias = new Vector2(0,0);
			float xMove = Random.Range(-10.0f, 10.0f);
			float yMove = Random.Range(-10.0f, 10.0f);

			direction = Vector3.Normalize(new Vector2(xMove, yMove));

		if (focus == null){
			Perceive();
		} 
		else {
			

			Vector2 newPos = focus.transform.position;
			Vector2 currentPos = this.transform.position;
			float distance = Mathf.Sqrt(Mathf.Pow(newPos.x - currentPos.x, 2) + Mathf.Pow(newPos.y - currentPos.y,2));

			if (distance < 0.5) {
				Consume(focus);
			}
			else {
				bias = Vector3.Normalize(new Vector2(newPos.x - currentPos.x, newPos.y - currentPos.y));
			}

			 
		}

		direction += bias*0.3f;
		rb2d.AddForce(direction * speed);
	}

	void Perceive(){
		Collider2D[] seen = Physics2D.OverlapCircleAll(this.transform.position, controller.vision);
		
		
		
		for (int i = 0; i < seen.Length; i++) {
			if (seen[i].tag == "Leafy" && controller.fullness < 80) {
				focus = seen[i].gameObject;
				
			}
			else {
				continue;
			}
		}
		
	}

	void Consume(GameObject item){
		Destroy(item);
		controller.fullness += 20;
	}
}
