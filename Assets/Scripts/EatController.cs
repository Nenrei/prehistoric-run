using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatController : MonoBehaviour {

	AudioController audio;

	// Use this for initialization
	void Awake () {
		audio = GameObject.Find ("Audio").GetComponent<AudioController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.transform.tag == "Human") {
			GameObject.Find ("CameraShake").GetComponent<CameraShake> ().Shake (0.05f, 0.05f);

			transform.GetComponent<Animator> ().SetTrigger ("eat");
			col.transform.gameObject.GetComponent<HumanController> ().Disapear ();

			audio.PlayEat ();

		} else if (col.transform.tag == "Fire") {
			col.gameObject.GetComponent<Animator> ().SetBool ("off", true);
		}

	}
}
