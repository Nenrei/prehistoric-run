using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RunRunRun(){
		GameObject.Find ("Player").GetComponent<PlayerMovement> ().runEnabled = true;
		GameObject.Find ("TimeCounter").GetComponent<TimeController> ().run = true;

		gameObject.SetActive (false);
	}
}
