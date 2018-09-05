using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_throw : MonoBehaviour {

	GameObject mc;
	float timer;

	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (mc != null){
			Vector3 targetPosition = mc.transform.position;
			Vector3 currentPosition = this.transform.position;
			Vector3 travelDirection = targetPosition - currentPosition;
			
			this.transform.Translate(
				(travelDirection.x * 3 * Time.deltaTime),
				(travelDirection.y * 3 * Time.deltaTime),
				(travelDirection.z * 3 * Time.deltaTime),
				Space.World);

			timer += Time.deltaTime;
			if(timer >= 2){
				Destroy(this.gameObject);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player"){
			Destroy(this.gameObject);
		}
	}
	public void getMCPosition(GameObject mainChar){

		mc = mainChar;		
	}
}
