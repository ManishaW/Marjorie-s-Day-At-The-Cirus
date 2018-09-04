using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_bar_image_controller : MonoBehaviour {
	public Image bar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		handleBar();

	}
	void handleBar(){
		bar.fillAmount = global_script.healthBar/100f;
	}

}
