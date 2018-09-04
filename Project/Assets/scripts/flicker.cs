using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flicker : MonoBehaviour {

	float flickerSpeedMin = 0.1f;
	float flickerSpeedMax = 1f;
	float timer;
	float stopFlickerMin = 4f;
	float stopFlickerMax = 6f;
	float randTimer;
	// Use this for initialization
	void Start () {
		timer = 0f;
		randTimer = 2f;
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if(timer > randTimer){
			StartCoroutine(flickerElement());
			randTimer = Random.Range(stopFlickerMin, stopFlickerMax);
		}
	}

	IEnumerator flickerElement(){
		gameObject.GetComponent<Text>().enabled = false;
		yield return new WaitForSeconds(Random.Range(flickerSpeedMin,flickerSpeedMax));
		gameObject.GetComponent<Text>().enabled = true;
		yield return new WaitForSeconds(Random.Range(flickerSpeedMin,flickerSpeedMax));
		timer = 0f;
	}
}
