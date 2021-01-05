using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CampGenerator : MonoBehaviour {

	public GameObject campPrefab;
	public Transform spawnPoint;
	public float minDistanceBetween;
	public float maxDistanceBetween;
	public CampPooler pooler;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < spawnPoint.position.x) {

			float distanceBetween = Random.Range (minDistanceBetween, maxDistanceBetween);

			transform.position = new Vector3 (transform.position.x + distanceBetween , transform.position.y, transform.position.z);
			GameObject obj = pooler.getNextCamp();
			obj.transform.position = transform.position;
			obj.transform.rotation = transform.rotation;
			obj.SetActive (true);


			/*GameObject[] estegos = GameObject.FindGameObjectsWithTag ("Stegosaurio");
			GameObject[] triceros = GameObject.FindGameObjectsWithTag ("Triceratops");

			GameObject[] dinos = estegos.Concat (triceros).ToArray();

			for(int i = 0 ; i < dinos.Length ; i++){

				float minX = obj.transform.position.x - 3;
				float maxX = obj.transform.position.x + 3;

				if (dinos [i].transform.position.x > minX && dinos [i].transform.position.x < maxX) {
					dinos[i].SetActive (false);
					Debug.Log ("CampGenerator");
					return;
				}
			}*/
		}
	}
}
