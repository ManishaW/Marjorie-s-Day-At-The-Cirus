using UnityEngine;
using System.Collections;

public class camera_follow_script : MonoBehaviour {

	public Transform playerTransform;
	public Vector3 offset;
	public Vector3 velocity = Vector3.zero;
	public float smoothTime = 0.6f;
	void FixedUpdate () 
	{
		Vector3 targetPos = playerTransform.position;
		//transform.position = new Vector3 (playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
//		targetPos.z = transform.position.z;
		targetPos.y += 3f;
		targetPos.x += 3f;

//		targetPos.x = 
		transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, smoothTime);

	
	}


}