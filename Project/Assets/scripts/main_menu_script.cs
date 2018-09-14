using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_script : MonoBehaviour {
	public GameObject menuPic;
	public Sprite otherMenuPic;
	AudioSource [] music;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		music = GetComponents<AudioSource> ();
	}

	public void PlayGameButtonOnClick()
	{
		//Output this to console when the Button is clicked
		Debug.Log("You have clicked the button!");
		//load scene
		menuPic.GetComponent<SpriteRenderer> ().sprite = otherMenuPic;
		music [1].Play ();
		StartCoroutine (nextScene());


	}
	public void creds()
	{

		SceneManager.LoadScene (4);


	}
	public void playAgainClick()
	{
		//Output this to console when the Button is clicked
		Debug.Log("You have clicked the button!");
		//load scene
		SceneManager.LoadScene (1);



	}
	public void controlsClick()
	{
		//Output this to console when the Button is clicked

		//load scene
		SceneManager.LoadScene (3);



	}
	public void backClick()
	{
		//Output this to console when the Button is clicked

		//load scene
		SceneManager.LoadScene (0);



	}
	IEnumerator nextScene(){
		yield return new WaitForSeconds(1);

		SceneManager.LoadScene (1);
	}
}
