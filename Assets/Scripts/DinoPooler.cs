using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPooler : MonoBehaviour {
	public Dino[] dinos;

	public int pooledAmount;

	public List<GameObject> pooledDinos;

	CountsController counts;

	public bool respawnOnNotFound;

	// Use this for initialization
	void Start () {
		counts = GameObject.Find ("Canvas").GetComponent<CountsController> ();
		dinos = transform.parent.GetComponentInChildren<DinoGenerator> ().dinos;
		pooledDinos = new List<GameObject> ();

		for (int i = 0; i < dinos.Length; i++) {
			for(int j = 0 ; j < pooledAmount ; j++){
				GameObject obj = (GameObject)Instantiate (dinos[i].prefab);
				obj.SetActive (false);
				pooledDinos.Add (obj);
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public GameObject getNextDino(){
		float theChosenOne = Random.Range (0, 100);
		for (int i = 0; i < dinos.Length; i++) {
			if (theChosenOne > dinos [i].range [0] && theChosenOne < dinos [i].range [dinos [i].range.Count - 1]) {
				for (int j = 0; j < pooledDinos.Count; j++) {

					if (pooledDinos [j].tag == dinos [i].prefab.tag && !pooledDinos [j].activeInHierarchy) {
						if (pooledDinos [j].tag == "Spinosaurus" &&  GameData.fartCount == 0) {
							if (respawnOnNotFound) {
								return getNextDino ();
							} else {
								Debug.Log ("Spawnea NULL 1");
								return null;
							}
						} else {
							return pooledDinos [j];
						}
					}
				}
			}
		}
		if (respawnOnNotFound) {
			return getNextDino ();
		} else {
			Debug.Log ("Spawnea NULL 2");
			return null;
		}

		/*GameObject obj = (GameObject)Instantiate (pooledObject);
		obj.SetActive (false);
		pooledDinos.Add (obj);
		return obj;*/
	}
}
