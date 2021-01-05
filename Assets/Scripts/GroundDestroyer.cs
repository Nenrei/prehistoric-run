using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour {

	public GameObject despawnPoint;

	// Use this for initialization
	void Start () {
		despawnPoint = GameObject.Find ("DespawnPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < despawnPoint.transform.position.x) {
			//Destroy (gameObject);
			gameObject.SetActive(false);
		}
	}
}
