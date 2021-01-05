using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundTravel : MonoBehaviour {
	public float speed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (GameObject.Find ("Player").GetComponent<PlayerMovement> ().runEnabled) {



			transform.position =  (new Vector3 (transform.position.x + Time.deltaTime*speed, transform.position.y, transform.position.z));
		}
	}
}
