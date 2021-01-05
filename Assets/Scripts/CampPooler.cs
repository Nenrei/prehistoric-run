using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampPooler : MonoBehaviour {

	public GameObject pooledCamp;
	public int pooledAmount;
	List<GameObject> pooledCamps;

	// Use this for initialization
	void Start () {
		
		pooledCamps = new List<GameObject> ();

		for(int i = 0 ; i < pooledAmount ; i++){
			GameObject obj = (GameObject)Instantiate (pooledCamp);
			obj.SetActive (false);
			pooledCamps.Add (obj);
		}

	}

	// Update is called once per frame
	void Update () {

	}

	public GameObject getNextCamp(){
		float theChosenOne = Random.Range (0, 100);

		for(int i = 0 ; i < pooledCamps.Count ; i++){
			if (!pooledCamps [i].activeInHierarchy) {
				pooledCamps [i].GetComponent<CampController> ().SpawnHumanPrefabs ();
				return pooledCamps [i];
			}
		}

		GameObject obj = (GameObject)Instantiate (pooledCamp);
		obj.SetActive (false);
		pooledCamps.Add (obj);
		return obj;
	}
}
