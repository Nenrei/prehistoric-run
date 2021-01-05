using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampController : MonoBehaviour {

	public float target1, target2;
	public GameObject[] humans;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnHumanPrefabs(){

		int random1 = Random.Range (0, 5);
		int random2 = Random.Range (0, 5);

		if (random1 == random2) {
			SpawnHumanPrefabs ();
			return;
		}

		humans [random1].transform.localPosition = new Vector3 (target1, 0, 0);
		humans [random1].SetActive (true);

		humans [random2].transform.localPosition = new Vector3 (target2, 0, 0);
		humans [random2].SetActive (true);
	}
}
