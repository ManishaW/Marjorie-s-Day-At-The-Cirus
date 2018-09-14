using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyUpdown : MonoBehaviour {
//	Vector3 _startingPos;
//	Transform _trans;
//	void Start() {
//		_trans = GetComponent<Transform>();
//		_startingPos = _trans.position;
//	}
//	void Update() {
//		_trans.position = new Vector3(_startingPos.x, _startingPos.y + Mathf.PingPong(Time.time, 3), _startingPos.z);
//	}
//
	int direction = 1; //int direction where 0 is stay, 1 up, -1 down    
	float top;
	float bottom;

	float speed = 3;
	Renderer ren;
	void Start()
	{
		top = 5 + transform.position.y;
		bottom = -5 + transform.position.y;
		ren = GetComponent<Renderer> ();
	}

	void Update () 
	{
		
		if (global_script.isScreaming) {
			if (ren.isVisible) {
				Destroy (gameObject);
			}
		}

		if (transform.position.y >=  top) {
			direction = -1;
			GetComponent<SpriteRenderer> ().flipX = true;
		}
		if (transform.position.y <= bottom) {
			direction = 1;
			GetComponent<SpriteRenderer> ().flipX = false;
		}
		transform.Translate(0, speed * direction * Time.deltaTime, 0);
	}
}
