using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_script : MonoBehaviour {
	public GameObject menuPic;
	public Sprite otherMenuPic;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void PlayGameButtonOnClick()
	{
		//Output this to console when the Button is clicked
		Debug.Log("You have clicked the button!");
		//load scene
		menuPic.GetComponent<SpriteRenderer> ().sprite = otherMenuPic;
		StartCoroutine (nextScene());


	}
	public void playAgainClick()
	{
		//Output this to console when the Button is clicked
		Debug.Log("You have clicked the button!");
		//load scene
		SceneManager.LoadScene (1);



	}

	IEnumerator nextScene(){
		yield return new WaitForSeconds(1);

		SceneManager.LoadScene (1);
	}
}
