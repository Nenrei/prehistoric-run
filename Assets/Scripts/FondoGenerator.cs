using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoGenerator : MonoBehaviour {

	public GameObject ground;
	public Transform spawnPoint;
	public float distanceBetween;

	public ObjectPooler pooler;

	private float groundWidth;

	// Use this for initialization
	void Start () {
		groundWidth = ground.GetComponent<BoxCollider2D> ().size.x;
	}

	// Update is called once per frame
	void FixedUpdate () {



		if (transform.position.x < spawnPoint.position.x) {
			transform.position = new Vector3 (transform.position.x + groundWidth + distanceBetween , transform.position.y, transform.position.z);
			//Instantiate (ground, transform.position, transform.rotation);
			GameObject obj = pooler.GetPooledObject();
			obj.transform.position = transform.position;
			obj.transform.rotation = transform.rotation;
			obj.SetActive (true);
		}

	}
}
