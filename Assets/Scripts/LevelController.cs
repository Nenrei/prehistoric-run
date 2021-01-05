using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

	public int level = 1;
	public GameObject poop;

	public float lastTime = 10;
	public float newLastTime = 25;
	public float changeTime = 40;

	float nextSpeed;

	PlayerMovement playerMovController;
	TimeController timeController;
	AudioController audioController;

	Text levelText;

	bool canSpeedUp;

	bool incrementSpeed;


	// Use this for initialization
	void Awake () {
		levelText = GetComponentInChildren<Text> ();
		levelText.text = level.ToString ();
		playerMovController = GameObject.Find ("Player").GetComponent<PlayerMovement>();
		timeController = GameObject.Find ("TimeCounter").GetComponent<TimeController> ();
		audioController = GameObject.Find ("Audio").GetComponent<AudioController> ();
		nextSpeed = playerMovController.speed;
	}
	
	// Update is called once per frame
	void Update () {

		if (int.Parse (timeController.timeText.text) == lastTime && canSpeedUp) {
			UpdateSpeed ();
			canSpeedUp = false;
		} else {
			canSpeedUp = true;
		}

		if (incrementSpeed) {
			if (playerMovController.speed >= nextSpeed) {
				incrementSpeed = false;
			} else {
				playerMovController.speed += Time.deltaTime;
			}
		}

	}

	void UpdateSpeed(){

		levelText.GetComponentInParent<Animator> ().SetTrigger ("shake");
		incrementSpeed = true;
		nextSpeed++;

		if (playerMovController.jumpForce > 10) {
			//playerMovController.jumpForce--;
		}

		level++;
		if (lastTime < changeTime) {
			lastTime += lastTime;
		} else {
			lastTime += newLastTime;
		}
		levelText.text = level.ToString ();

		Vector3 target = GameObject.Find ("Player").transform.position;
		poop.transform.position = new Vector3 (target.x - 0.5f, target.y - 0.5f, 0f);
		poop.SetActive (true);
		//obj.GetComponent<Rigidbody2D> ().AddForce (Vector2.left);
//		audioController.PlayCoin ();

		if (level == 6) {
			playerMovController.jumpForce--;
		}

		GameData.level = level;
	}
}
