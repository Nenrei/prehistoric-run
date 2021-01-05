using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dino{
	public GameObject prefab;
	[Range(0,100)]
	public float ratio;
	public List<float> range;
}

public class DinoGenerator : MonoBehaviour {

	public Dino[] dinos;
	public Transform spawnPoint;
	public float minDistanceBetween;
	public float maxDistanceBetween;

	public DinoPooler pooler;

	private float dinoWidth;

	string lastSpawned;

	// Use this for initialization
	void Start () {
		CalculateOdds ();
	}

	void CalculateOdds(){

		float ranges = dinos.Length;

		float lastRangeNumber = 0;

		for (int i = 0; i < ranges; i++) {

			dinos [i].range = new List<float> ();

			for (int j = 0; j < dinos [i].ratio; j++) {
				lastRangeNumber++;
				dinos [i].range.Add (lastRangeNumber);
			}
		}

	}

	// Update is called once per frame
	void Update () {
		
		if (transform.position.x < spawnPoint.position.x) {

			SpawnNewObject ();
		}

	}

	void SpawnNewObject(){
		float distanceBetween = Random.Range (minDistanceBetween, maxDistanceBetween);

		//Instantiate (ground, transform.position, transform.rotation);
		GameObject obj = pooler.getNextDino();

		if (obj == null) {
			Debug.Log ("Spawnea NULL 3");
			return;
		}

		transform.position = new Vector3 (transform.position.x + distanceBetween, transform.position.y, transform.position.z);

		if (obj.tag == "Human") {
			obj.transform.position = new Vector3 (transform.position.x, transform.position.y + 2f, transform.position.z);
		}else if (obj.tag == "Spinosaurus") {
			obj.transform.position = new Vector3 (transform.position.x, transform.position.y + 0.35f, transform.position.z);
		} else if (obj.tag == "Camp") {
			obj.transform.position = new Vector3 (transform.position.x, transform.position.y - 0.25f, transform.position.z);
			obj.GetComponent<CampController> ().SpawnHumanPrefabs ();			
		}else {
			obj.transform.position = new Vector3 (transform.position.x, transform.position.y , transform.position.z);
		}

		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);
	}

}
