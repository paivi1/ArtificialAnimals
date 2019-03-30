using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreActuator : MonoBehaviour
{
    public float speed = 10;
	[SerializeField]
    private GameObject posFocus;
	private GameObject negFocus;
	private Vector2 direction;


	private Rigidbody2D rb2d;
	private CarnivoreController controller;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		controller = GetComponent<CarnivoreController>();
		
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
            Vector2 currentPos = this.transform.position;
			float xMove = Random.Range(-10.0f, 10.0f);
			float yMove = Random.Range(-10.0f, 10.0f);

			direction = Vector3.Normalize(new Vector2(xMove, yMove));

		if (posFocus == null){
			Perceive();
            Vector2 newPos = new Vector2(20, 11);
            bias = Vector3.Normalize(new Vector2(newPos.x - currentPos.x, newPos.y - currentPos.y));
		} 
		else {
			

			Vector2 newPos = posFocus.transform.position;
			float distance = Mathf.Sqrt(Mathf.Pow(newPos.x - currentPos.x, 2) + Mathf.Pow(newPos.y - currentPos.y,2));

			if (distance < 1.5) {
				Consume(posFocus);
			}
			else {
				bias = Vector3.Normalize(new Vector2(newPos.x - currentPos.x, newPos.y - currentPos.y));
			}

			 
		}

		direction += bias*1.0f;
		rb2d.AddForce(direction * speed);
	}

	void Perceive(){

		Collider2D[] seen = Physics2D.OverlapCircleAll(this.transform.position, controller.vision);
		//Collider2D[] pushs;
		//Collider2D[] pulls;
		
		for (int i = 0; i < seen.Length; i++) {
			if (seen[i].tag == "Deer" && controller.fullness < 80) {
				posFocus = seen[i].gameObject;
			}
			else {
				continue;
			}
		}
		
	}

	void Consume(GameObject item){
        Debug.Log("<color=red>" + "EATEN: " + item.name + "!</color>");
		Destroy(item);
		controller.fullness += 20;
	}
}
