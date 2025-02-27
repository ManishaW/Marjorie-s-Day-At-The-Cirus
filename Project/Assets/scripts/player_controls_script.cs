﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class player_controls_script : MonoBehaviour {
	public float panSpeed = 20f;
	public float speed = 4f;
	float timer;
	float holdDur = 1f;
	public GameObject [] popcornToCollect = new GameObject[5];
	public GameObject mainCam;
	private Animator mcAnim;
	private bool running;
	private bool grounded;
	private bool attacking;
	private bool scream;
	private bool crouching;
	AudioSource [] audioData;
	public GameObject marjHead;
	Animator animHeadBobble;
	public bool yop;
	// Use this for initialization
	void Start () {
		global_script.popcornCount = 0;
		global_script.allowScream = false;
		global_script.healthBar = 100;
		mcAnim = gameObject.GetComponent<Animator>();
		running = false;
		grounded = true;
		attacking = false;
		scream = false;
		crouching = false;
		audioData = GetComponents<AudioSource> ();
		animHeadBobble = marjHead.GetComponent<Animator> ();

	}

	void FixedUpdate () {
//		for (int i = 0;i < 20; i++) {
//			if(Input.GetKeyDown("joystick 1 button "+i)){
//				print("joystick 1 button "+i);
//			}
//		}
		float moveLR = Input.GetAxisRaw ("Horizontal") * speed;
		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;
		Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D> ();
		
		mcAnim.SetBool("running", running);
		mcAnim.SetBool("isGrounded", grounded);
		mcAnim.SetBool("attack", attacking);
		mcAnim.SetBool("screaming", scream);

		if (Input.GetKeyDown ("joystick 1 button 0") && grounded == true) {
			Debug.Log  ("A pressed");
			//jump
				rb2d.velocity = new Vector2 (0, 0);
				rb2d.AddForce (new Vector2 (0, 8), ForceMode2D.Impulse);		
		}

		if ((Input.GetKey (KeyCode.UpArrow)) && grounded == true) {
			string[] names = Input.GetJoystickNames ();
			if ((names.Length < 1) && (grounded == true))  {
				rb2d.velocity = new Vector2 (0, 0);
				rb2d.AddForce (new Vector2 (0, 8), ForceMode2D.Impulse);
			}
			if (names.Length > 0) {
				if (names[0] == "" && grounded == true){
					rb2d.velocity = new Vector2 (0, 0);
					rb2d.AddForce (new Vector2 (0, 8), ForceMode2D.Impulse);
				}
			}
		}
	
		if (Input.GetKeyDown ("joystick 1 button 2") || Input.GetKeyDown("space")) {
			//whip
			attacking = true;
			audioData[2].Play ();
			StartCoroutine (attack());

		} else {
			//not whippin
			attacking = false;
		}
		if (Input.GetKeyDown ("joystick 1 button 4")) {
//			Debug.Log ("pressed B or enter");


			///ummmm
		}


		if (Input.GetKeyDown ("joystick 1 button 3") || Input.GetKeyDown ("s")) {
			timer = Time.time;
		
		
		} else if (Input.GetKey ("joystick 1 button 3") || Input.GetKey("s")) {
			//scream

			if (Time.time - timer > holdDur) {
				if (global_script.allowScream == true) {

					scream = true;

					global_script.isScreaming = true;

					StartCoroutine (vibrateOneSec ());
					StartCoroutine(mainCam.GetComponent<CameraShake> ().Shake());
					global_script.popcornCount = 0;
					global_script.allowScream = false;
					for (int x = 0; x < 5; x++) {
						popcornToCollect [x].GetComponent<SpriteRenderer> ().color = Color.black;
					}
					audioData[0].Play ();
					animHeadBobble.enabled = false;
					StartCoroutine (turnOffScream());
				}

			}
		}

		//move side to side
		if (moveLR > 0.5f || moveLR < -0.5f) {
			if ((Mathf.Round (Input.GetAxisRaw ("Crouch")) < 0) || (Input.GetKey (KeyCode.LeftControl))) {
				pos.x += moveLR / 50;
				crouching = true;

			} else {

				pos.x += moveLR / 25;

				//face right
				if(moveLR > 0.5f){
					transform.rotation = Quaternion.identity;
				}
				//face left
				else if(moveLR < -0.5f){
					transform.rotation = Quaternion.Euler(0,180,0);
				}

				running = true;
			}
		}else{
			running = false;
			crouching = false;
		}

				
		transform.position = pos;

		if (global_script.healthBar <= 0) {
			SceneManager.LoadScene(2);
		}
	}
	IEnumerator attack(){
		yop = true;
		yield return new WaitForSeconds(0.5f);
		yop = false;
//		attacking = true;
//		yield return new WaitForSeconds(0.5f);
//		attacking = false;
	}
	IEnumerator vibrateOneSec(){
		XInputDotNetPure.GamePad.SetVibration (0, 1, 1);  
		yield return new WaitForSeconds(1);
		XInputDotNetPure.GamePad.SetVibration (0, 0, 0);
		global_script.isScreaming = false;


	}
	IEnumerator turnOffScream(){
		yield return new WaitForSeconds(1);
		scream = false;
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "enemy") {
			
			global_script.healthBar -= 10;
			print (global_script.healthBar);
			audioData[3].Play ();
			print (attacking);

			if (yop == true) {
				Destroy (col.gameObject);
			}
				
		

		}
		if (col.tag == "popcorn_energy") {
			audioData[1].Play ();

			if (global_script.popcornCount <= 5 && global_script.popcornCount > 0) {
				popcornToCollect [global_script.popcornCount - 1].GetComponent<SpriteRenderer> ().color = Color.white;
				if (global_script.popcornCount == 5) {
					animHeadBobble.enabled = true;
					global_script.allowScream = true;
				

				}
			} 

		}

		if(col.tag == "enemy_throw"){

//			if(attacking){
//				Destroy(col.gameObject);
//				Debug.Log("hit enemy throw!!!!!!!");
//			}else{
//				global_script.healthBar -= 10;
//				Debug.Log("current health ....." + global_script.healthBar);
//				audioData[3].Play ();
//			}
//
			global_script.healthBar -= 10;
			Debug.Log("current health ....." + global_script.healthBar);
			audioData[3].Play ();
			if (yop == true) {
				Destroy (col.gameObject);
			}



		}
//		if (col.tag == "jack") {
//			global_script.healthBar -= 10;
//			if (yop == true) {
//				Destroy (col.gameObject);
//			}
//
//			audioData[3].Play ();
////			if (yop == true) {
////				Destroy (col.gameObject);
////			}
////			StartCoroutine (jackPop ());
//
//		}

		if(col.tag == "surface" ){
			grounded = true;
			Debug.Log ("grounded enter");
		}
		if(col.tag == "bighands" ){
			global_script.healthBar -= 15;

			audioData[3].Play ();
		}

		if(col.tag == "death" ){
			SceneManager.LoadScene(2);
		}

		if(col.tag == "enemy" && attacking){
			Debug.Log("HIT THE ENEMYYY");
		}

	}



	IEnumerator jackPop(){
		float random = Random.Range (0f, 3f);
		yield return new WaitForSeconds(random);
		Debug.Log ("pop"+random);



	}
//	void OnCollisionEnter2D(Collision2D col){
//		Debug.Log(col.collider.tag);
//		if (col.collider.tag == "crate") {
//			Debug.Log(Mathf.Round (Input.GetAxisRaw ("Crouch")));
//			if ((Mathf.Round (Input.GetAxisRaw ("Crouch")) < 0)) {
//				col.collider.isTrigger = true;
//
//			} else if ((Mathf.Round (Input.GetAxisRaw ("Crouch")) > 0)) {
//				
//			}
//		}
//
//	
//
//	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "crate") {
			col.isTrigger = false;
		}

		if(col.tag == "surface"){
			grounded = false;
			print ("here exit");
		}
	}

	
}