﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbController : MonoBehaviour {

	public float vision;
	public float viewAngle;
	public float fullness;
	public float hydration;
	public float health;
	public int age;
	public float energy;
	public string diet;
	public int state;

	// Use this for initialization
	void Start () {
		viewAngle = 180;
		fullness = 100;
		hydration = 40;
		health = 100;
		energy = 100;
		age = 0;
		state = 0;
		vision = 5;
		diet = "herbivore";
		InvokeRepeating("Metabolize", 1.0f, 1.0f);
		Growth();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Metabolize(){
		if (fullness > 0) {
			fullness -= 2;
			if (health < 100){
				health += 1;
			}
			if (energy < 100) {
				energy += 1;
			}
		}
		else {
			health -= 3f;
		}
		if (hydration > 0) {
			hydration -= 0.5f;
			if( health < 100){
				health += 1;
			}
			if (energy < 100) {
				energy += 2;
			}
		}
		else {
			health -= 3;
		}
		if (health <= 0) {
			Destroy(this.gameObject);
			Debug.Log("<color=yellow>" + this.gameObject.name + "'s health fell to zero and died" +  "!</color>");
		}
		age++;
		Growth();
	}
	void Growth(){
		if (age < 60){
			transform.localScale = new Vector3(1.5f + (float)age / 30, 1.5f + (float)age / 30, 0);
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
