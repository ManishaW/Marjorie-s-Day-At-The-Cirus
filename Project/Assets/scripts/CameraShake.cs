using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	Vector3 originalPos;
	void Update(){
		originalPos = transform.localPosition;
	}


	public IEnumerator Shake ()
	{
	
		float elapsed = 0.0f;

		while (elapsed < 1f) {
			float x = Random.Range (originalPos.x - 0.5f, originalPos.x + 0.5f);
			float y = Random.Range (originalPos.y - 0.5f, originalPos.y + 0.5f);

			transform.localPosition = new Vector3 (x, y, originalPos.z);

			elapsed += Time.deltaTime;
			yield return null;

		}

		transform.localPosition = originalPos;

	}



}
