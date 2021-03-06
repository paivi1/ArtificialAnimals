﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour {


	public float fullness = 100;
	public float hydration = 100;
	public float health = 100;
	public string diet = "producer";
	public GameObject env;
	private EnvironmentalController envCon;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Metabolize", 1.0f, 1.0f);
		env = GameObject.Find("Environment");
		envCon = env.GetComponent<EnvironmentalController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Metabolize(){
		if (fullness > 0) {
			fullness -= 2;
		}
		else {
			health -= 0.5f;
		}
		if (hydration > 0) {
			hydration -= 0.5f;
		}
		else {
			health -= 2;
		}
		if (health <= 0) {
			Destroy(this.gameObject);
			Debug.Log("<color=yellow>" + this.gameObject.name + "'s health fell to zero and died" +  "!</color>");
		}

		if(envCon.rain == true){
			hydration += 5;
		}
	}

	public float GetFullness(){
		return fullness;
	}

	public void SetFullness(float num) {
		fullness += num;
	}
	public float GetHydration(){
		return hydration;
	}

	public void SetHydration(float num) {
		hydration += num;
	}
	public float GetHealth(){
		return health;
	
	}
	public void SetHealth(float num){
		health += num;
	}
}
