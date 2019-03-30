﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoreController : MonoBehaviour
{
    public float vision = 20;
	public bool hunted = false;
	public float fullness = 100;
	public float hydration = 100;
	public float health = 100;
	public float age = 1;
	public string diet = "carnivore";

	// Use this for initialization
	void Start () {
		InvokeRepeating("Metabolize", 1.0f, 1.0f);
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
		age++;
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
