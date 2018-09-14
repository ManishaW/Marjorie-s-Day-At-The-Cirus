using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_controller : MonoBehaviour {

	public GameObject mainCharLocation;
	public Vector3 pos;
	Renderer ren;
	// Use this for initialization
	void Start () {


	}
	
	void Update () {
		pos = transform.position;

		mainCharLocation = GameObject.FindGameObjectWithTag("Player");
		float mcDistanceAway = mainCharLocation.transform.position.x - pos.x;

		// if in range, shoot at main character
		if((mcDistanceAway < 5f) && (mcDistanceAway > -5f)){
			if(GameObject.Find("throwable(Clone)") == null){
				spawnThrow();
			}
		}


	}

	void spawnThrow(){
		GameObject gameObj = (GameObject)Instantiate(Resources.Load("throwable"), pos, Quaternion.identity);
		boss_throw newThrowObj = gameObj.GetComponent<boss_throw>();
		newThrowObj.getMCPosition(mainCharLocation);
	}
}