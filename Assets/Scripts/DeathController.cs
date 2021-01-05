using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour {

	public GameObject scorePanel;
	AudioController audio;

	// Use this for initialization
	void Awake () {
		audio = GameObject.Find ("Audio").GetComponent<AudioController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "DeathPoint") {
			audio.PlayHit ();
			GetComponent<PlayerMovement> ().dead = true;
			GameObject.Find ("CameraShake").GetComponent<CameraShake> ().Shake (0.3f, 0.2f);
			Invoke ("OpenScore", 0.25f);
		}
	}

	void OpenScore(){
		scorePanel.SetActive (true);
		scorePanel.GetComponent<ScoreController> ().CalculateScore ();
	}

}
