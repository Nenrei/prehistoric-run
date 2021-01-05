using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public PlayerMovement player;
	public float plusX = 5;

	private Vector3 lastPlayerPosition;
	private float distanceToMove;

	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerMovement> ();
		lastPlayerPosition = player.transform.position;
		if (GameData.musicEnabled) {
			GetComponent<AudioSource> ().Play ();
		}
	}


	void FixedUpdate(){

		distanceToMove = player.transform.position.x - lastPlayerPosition.x;

		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);

		lastPlayerPosition = player.transform.position;

	}
}
