using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideToSide : MonoBehaviour {
	Renderer ren;
	//
	int direction = 1; //int direction where 0 is stay, 1 up, -1 down    
	float top;
	float bottom;

	float speed = 3;

	void Start()
	{
		top = 5 + transform.position.x;
		bottom = -5 + transform.position.x;
		ren = GetComponent<Renderer> ();

	}

	void Update () 
	{

		if (global_script.isScreaming) {
			if (ren.isVisible) {
				Destroy (gameObject);
			}
		}
		if (transform.position.x >=  top) {
			direction = -1;
			GetComponent<SpriteRenderer> ().flipX = true;
		}
		if (transform.position.x <= bottom) {
			direction = 1;
			GetComponent<SpriteRenderer> ().flipX = false;
		}
		transform.Translate(speed * direction * Time.deltaTime,0, 0);
	

	
	
	}
}
