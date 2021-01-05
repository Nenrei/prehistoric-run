using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanController : MonoBehaviour {

	public float speed = 2;
	public int amount = 1;

	bool moveToCounter;
	Vector3 counterPosition, roarPosition;
	Transform counter;

	CountsController countsController;

	// Use this for initialization
	void Awake () {
		countsController = GameObject.Find ("Canvas").GetComponent<CountsController>();
		counter = countsController.humanCounter.transform;
	}
	
	// Update is called once per frame
	void Update () {

		counterPosition = counter.position;

		if (moveToCounter) {
			transform.position = Vector3.MoveTowards (transform.position, counterPosition, speed);
			if(transform.position == counterPosition){
				moveToCounter = false;
				gameObject.SetActive (false);
				countsController.IncrementHumanCount (amount);
			}
		}
		
	}

	public void Disapear(){
		moveToCounter = true;
		transform.localScale = new Vector3 (1.25f, 1.25f, 1f);
		GetComponent<CanvasGroup> ().alpha = 0.5f;
	}
}
