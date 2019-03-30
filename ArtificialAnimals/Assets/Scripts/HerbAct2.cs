using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbAct2 : MonoBehaviour {

	public float speed = 1; //Animal speed
    public float angle; //Current angle of the animals body (an angle of zero means it's facing towards the top of the screen)

	[SerializeField]
	private GameObject posFocus; //Current focus of interest
	[SerializeField]
	private GameObject negFocus; //Current focus of fear
    
	private Rigidbody2D rb2d;   //Corresponds to the rigidbody2d of the animal. Stores physics info (e.g. velocity)
	private HerbController controller; //Controller for the animal
	private float turn;             //'turn' is used to control the change in 'angle', a positive 'turn' means clockwise rotation.
                                    // the larger the 'turn' the larger the angle is changed every frame (AKA larger turn = faster but more jittery rotation)
    [SerializeField]
    private List<GameObject> group; //Stores a list of gameobjects that are of the same type (Deer)
    [SerializeField]
    private List<GameObject> threats; //Stores a list of gameobjects that are threats (Wolf)
    [SerializeField]
    private List<GameObject> interests; //Stores a list of gameobjects that are of interest (Flower). I hope to expand this to water as well


	// Initialization initilaizes it's components (connects to its controller, rigidbody2d)
    //'angle' is set to random so they don't all start the same way
    //InvokeRepeating invokes "Perceive" every half second. I guess this is technically it's reaction time, maybe we'll make it a variable later
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		controller = GetComponent<HerbController>();
		angle = Random.Range(0, 360);
		//InvokeRepeating("TurnTowards", 0.0f, 0.1f);
		InvokeRepeating("Perceive", 0.0f, 0.5f);
		
	}
	
	// Update is called once per frame
    //Actions taken depend on it's current state
    //Speed is changed back to 1 here, in case it was changed in "HuntedState". I'll likely change this later because it's sloppy
	void Update () {

        if (controller.state == 2){
			HuntedState(negFocus);
		}
		else if (controller.state == 1){
			speed = 1;
            Pursue(posFocus);
		}
		else if (controller.state == 0){
            Wander();
		    speed = 1;
        }
		
		
	}
    //Note: a Vector2 is a 2-tuple. It can indicate position (x,y), velocity, etc.
    //'TurnTowards' takes the current direction of the animal 'transform.up' and a given velocity (still a Vector2) parameter, 
    //and finds the angle between them. It uses this angle to align the animals direction with the input velocity by turning it.
    void TurnTowards(Vector2 vel){
        
        if (Vector2.SignedAngle(vel, transform.up) <= 0){
            turn = 1;
        }
        if (Vector2.SignedAngle(vel, transform.up) > 0){
            turn = -1;
        }
        
    }
    //Perceive records all the physics colliders (which are on objects) within a given radius 'controller.vision' and stores them in an array
	void Perceive(){
		Collider2D[] seen = Physics2D.OverlapCircleAll(this.transform.position, controller.vision);
        //Below we clear all arrays and focuses before 'updating' them in this function
		group = new List<GameObject>();
		threats = new List<GameObject>();
		interests = new List<GameObject>();
        posFocus = null;
        negFocus = null;

        //Here we sort the percieved objects into three categories
		for (int i = 0; i < seen.Length; i++) {

            //This bit of code here checks if the object is within a certain angle (think of it as it only seeing things in front of it)
            //This way, it only "sees" things within its viewAngle, otherwise it goes unseen
            //Right now, controller.viewAngle is 180 degrees (both left and right) so it can see everything around it. This can be changed for more realism
            float xdif = seen[i].transform.position.x - transform.position.x;
            float ydif = seen[i].transform.position.y - transform.position.y;
            Vector2 toObj = new Vector2(xdif, ydif);
            float ang = Vector2.SignedAngle(toObj, transform.up);

            if  ((ang < controller.viewAngle) && (ang > -controller.viewAngle)){
                Debug.Log("I see " + seen[i]);

                if (seen[i].tag == "Flower" && controller.fullness < 50) {
                    interests.Add(seen[i].gameObject);
                }
                if (seen[i].tag == "Deer") {
                    group.Add(seen[i].gameObject);
                }
                if (seen[i].tag == "Wolf") {
                    threats.Add(seen[i].gameObject);
                }
            }
            else {
                
            }

			
		}
        //After perceiving, it prioritizes with new information
		Prioritize(threats, interests, group);
	}

    //Prioritize sets the state of the animal depending on its perceptions. Highest to lowest priority is: Nearby predator, nearby food, everything else
	void Prioritize(List<GameObject> threats, List<GameObject> interests, List<GameObject> group){
		if (threats.Count != 0) {
			negFocus = threats[0];
			controller.state = 2;  //If aware of threats, change state to hunted, avoid first threat
                                   //We'll need a way to manage more than one threat, hopefully we can implement it
		}
		else if (interests.Count != 0) {
			posFocus = interests[0]; //If no threats and interested, persue first interest
			controller.state = 1; //State changed to interested
		}
		else {			
			controller.state = 0;//If no threats or interests, wander with group
             
		}
	}
		
    //Wander will have the animal move with its nearby neighbors (group). If there are none, turn acts randomly
	void Wander(){
        if (group.Count > 1){
            TurnTowards(GroupVelocity(group));
        }
        else {
            turn = Random.Range(-2.0f, 2.0f);
            Debug.Log("Where are my homies?");
            Debug.Log(name);
        }
        //This is how rotation works. The angle is the current angle, turn is added to change it slightly. Modulo is just to keep angle within 360 degrees
        angle += 1 * turn;
        angle = angle % 360;
        //angle is then used to update the rotation. Rotation is set to 'angle' degrees counterclockwise around the 'Vector3.forward' axis (AKA the z-axis)
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //Set the velocity of the animal to where ever it's looking, multiplied by the speed
        rb2d.velocity = (transform.up * speed);
	}
    //If there is a interest, move towards it
    void Pursue(GameObject posFocus){
        if (posFocus == null){
            controller.state = 0;
        }
        //Find the direction vector towards the interest from the animals position
        Vector2 focusDirection = new Vector2 (posFocus.transform.position.x - transform.position.x, posFocus.transform.position.y - transform.position.y);
        //Align the animals rotation with the direction vector
        TurnTowards(focusDirection);
        //Compute distance from interest. If close enough, eat it
		float distance = Mathf.Sqrt(Mathf.Pow(posFocus.transform.position.x - transform.position.x, 2) + Mathf.Pow(posFocus.transform.position.y - transform.position.y,2));

		if (distance < 0.5) {
			Consume(posFocus);
		}
        //Turn and move. Details above in "Wander"
        angle += 1 * turn;
        angle = angle % 360;
        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb2d.velocity = (transform.up * speed);
	}
    //If a threat is near, avoid it
    void HuntedState(GameObject negFocus) {
		//Expend energy to increase speed for a short while
		if (controller.energy > 10 ){
			speed = 10;
			controller.energy -= 0.5f;
		} else {
			speed = 1;
		}
        //Same thing as in 'Pursue' but we use the negative direction as a parameter for 'TurnTowards' so that it turns in the opposite direction
        Vector2 focusDirection = new Vector2 (negFocus.transform.position.x - transform.position.x, negFocus.transform.position.y - transform.position.y);
        TurnTowards(-focusDirection);
        //Turn and move. Details above in "Wander"
        angle += 2 * turn;
        angle = angle % 360;
        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb2d.velocity = (transform.up * speed);
	}
    //Eat the object of interest, increase fullness
    void Consume(GameObject item){
		Destroy(item);
		controller.fullness += 20;
	}

    //Take your velocity and add the velocities of animals in your group. Divide by the group size. Velocities are normalized so that direction shared but speed is individual
    //Returns the new velocity vector
	Vector2 GroupVelocity(List<GameObject> group){
		Vector2 currVel = rb2d.velocity;
		int total = 0;
		for (int peer = 1; peer < group.Count; peer++){
			currVel += group[peer].GetComponent<Rigidbody2D>().velocity.normalized;
			total++;
		}
		if (total > 0) {
			currVel /= group.Count;
		}
		return currVel;
	}



}

