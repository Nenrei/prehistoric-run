using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour {

	public Text countDown;

	public bool incrementTime;

	float time;

	AudioController audio;

	bool onePlayed, twoPlayed, threePlayed;

	// Use this for initialization
	void Start () {
		countDown = GetComponent<Text> ();
		audio = GameObject.Find ("Audio").GetComponent<AudioController> ();
		StartCount ();
	}
	
	// Update is called once per frame
	void Update () {
		if (incrementTime) {

			time += Time.deltaTime;

			if (Mathf.Floor(time) == 1) {
				countDown.fontSize = 300;
				countDown.text = "2";
				if (!twoPlayed) {
					audio.PlayCountDown ();
					twoPlayed = true;
				}
			}

			if (Mathf.Floor(time) == 2) {
				countDown.text = "1";
				if (!onePlayed) {
					audio.PlayCountDown ();
					onePlayed = true;
				}
			}

			if (Mathf.Floor(time) == 3) {
				countDown.fontSize = 150;
				countDown.text = "Corre!";
				if (!threePlayed) {
					audio.PlayCountDown ();
					threePlayed = true;
				}
				GameObject.Find ("Player").GetComponent<PlayerMovement> ().runEnabled = true;
				GameObject.Find ("TimeCounter").GetComponent<TimeController> ().run = true;
				GameObject.Find ("Bocata").GetComponent<Animator> ().SetBool("off", true);
			}

			if (time > 4) {
				incrementTime = false;
				time = 0;
				countDown.gameObject.SetActive (false);
			}

		}
	}

	public void StartCount(){
		countDown.text = "3";
		incrementTime = true;
		gameObject.SetActive (true);
		onePlayed = false;
		twoPlayed = false;
		threePlayed = false;
		audio.PlayCountDown ();
	}

	/*public void SetInactive(){
		incrementTime = true;
		gameObject.SetActive (false);
		audio.PlayCountDown ();
	}*/
}
