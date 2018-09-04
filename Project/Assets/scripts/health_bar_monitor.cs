using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_bar_monitor : MonoBehaviour {
	public Sprite damagedTeddy;
	public Sprite almostDeadTeddy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (global_script.healthBar < 75 && global_script.healthBar > 35) {
			GetComponent<SpriteRenderer> ().sprite = damagedTeddy;

		}
		if (global_script.healthBar < 35 && global_script.healthBar > 0) {
			GetComponent<SpriteRenderer> ().sprite = almostDeadTeddy;
		}
	}
}
