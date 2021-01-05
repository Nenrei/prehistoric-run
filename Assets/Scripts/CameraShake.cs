using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public Camera cam;

	float shakeAmount = 0;

	void Awake(){
		
	}


	public void Shake(float amt, float length){
		/*shakeAmount = amt;
		InvokeRepeating ("BeginShake", 0, 0.01f);
		Invoke ("StopShake", length);*/
	}


	void BeginShake(){
		if (shakeAmount > 0) {
			Vector3 camPos = cam.transform.position;
			float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
			float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
			camPos.x += offsetX;
			camPos.y += offsetY;

			cam.transform.position = camPos;
		}
	}

	void StopShake(){
		CancelInvoke ("BeginShake");
		cam.transform.position = new Vector3(cam.transform.position.x, -1f, cam.transform.position.z);
	}
}
