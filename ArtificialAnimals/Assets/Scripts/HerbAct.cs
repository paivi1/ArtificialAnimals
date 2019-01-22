using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbAct : MonoBehaviour {

	public float speed = 1;
	public GameObject focus;
	public Vector2 direction;
	public Vector2 bias;

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
			float xMove = Random.Range(-10.0f, 10.0f);
			float yMove = Random.Range(-10.0f, 10.0f);

			direction = Vector3.Normalize(new Vector2(xMove, yMove));

		if (focus == null){
			Perceive();
		} 
		else {
			Vector2 newPos = focus.transform.position;
			Vector2 currentPos = this.transform.position;

			bias = Vector3.Normalize(new Vector2(newPos.x - currentPos.x, newPos.y - currentPos.y)); 
		}

		direction += bias*0.1f;
		rb2d.AddForce(direction * speed);
	}

	void Perceive(){
		Collider2D[] seen = Physics2D.OverlapCircleAll(this.transform.position, controller.vision);
		
		
		
		for (int i = 0; i < seen.Length; i++) {
			//Debug.Log(seen[i]);
			//Debug.Log(seen[i].tag);
			if (seen[i].tag == "Grass") {
				focus = seen[i].gameObject;
				Debug.Log(focus);
				
			}
			else {
				continue;
			}
		}
		
	}

}
