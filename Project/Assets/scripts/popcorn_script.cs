﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popcorn_script : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			global_script.popcornCount += 1;
			Destroy (gameObject);

		}
	}

	

}
