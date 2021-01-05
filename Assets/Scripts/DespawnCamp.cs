using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnCamp : MonoBehaviour {

	public GameObject despawnPoint;
	CampController controller;

	// Use this for initialization
	void Start () {
		despawnPoint = GameObject.Find ("DespawnPoint");
		controller = transform.GetComponent<CampController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < despawnPoint.transform.position.x) {
			gameObject.SetActive(false);

			for (int i = 0; i < controller.humans.Length; i++) {
				controller.humans [i].SetActive (false);
			}
		}
	}
}
