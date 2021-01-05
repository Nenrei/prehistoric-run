using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtintionController : MonoBehaviour {

	public Transform target;

	Transform player;

	public bool started;
	public bool extintionStarted;

	public DinoPooler dinoPooler;

	public Transform origin;
	public Transform meteor;
	public GameObject explosion;
	public GameObject[] craters;

	public Text extText;
	CountsController countsController;


	// Use this for initialization
	void Awake () {
		player = GameObject.Find ("Player").transform;
		countsController = GameObject.Find ("Canvas").GetComponent<CountsController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (started) {

			if (target == null) {
				meteor.localPosition = Vector3.zero;
			}

			if (target != null) {
				meteor.position = Vector3.MoveTowards (meteor.position, target.position, GameObject.Find ("Player").GetComponent<PlayerMovement>().speed * 5 * Time.deltaTime);
				if (meteor.position == target.position) {
					Explode ();
					target = null;
					started = false;
					meteor.position = origin.position;
				}
			}

		}
	}

	void OnTriggerEnter2D(Collider2D col){
		string tag = col.gameObject.tag;
		if (!extintionStarted) {
			return;
		}

		if (tag == "Triceratops" || tag == "Stegosaurio" || tag == "Spinosaurus") {
			started = true;
			target = col.gameObject.transform;
			GameObject.Find ("Audio").GetComponent<AudioController> ().PlayMeteor ();
		}
	}

	void Explode(){
		target.gameObject.SetActive (false);

		for (var i = 0; i < craters.Length; i++) {
			if (!craters [i].activeInHierarchy) {
				craters [i].transform.position = new Vector3 (target.position.x, craters [i].transform.position.y, 1f);
				craters [i].SetActive (true);
				break;
			}
		}

		explosion.transform.position = new Vector3 (target.position.x, explosion.transform.position.y, 1f);
		explosion.SetActive (true);

		GameObject.Find ("Audio").GetComponent<AudioController> ().PlayExplosion ();

		Invoke ("EndExplosion", 0.5f);

	}

	void EndExplosion(){
		explosion.SetActive (false);
	}

	public void StartExtintion(){
		if (GameData.extintionCount > 0) {
			GameData.usedExtintions++;
			countsController.DecrementHumanCount (GameData.extintionPrice);
			extintionStarted = true;
			GameObject.Find ("BackMeteorPooler").GetComponent<BackGroundMeteorPooler> ().StartExtintion ();
			Invoke ("StopExtintion", 10f);
		}
	}

	public void StopExtintion(){
		if (extintionStarted) {
			extintionStarted = false;
			GameObject.Find ("BackMeteorPooler").GetComponent<BackGroundMeteorPooler> ().StopExtintion ();
		}
	}

	public void CalculateExtintion(){
		GameData.extintionCount = (int) Mathf.Round (GameData.humanCount / GameData.extintionPrice);
		extText.text = GameData.extintionCount.ToString ();
	}
}
