using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoController : MonoBehaviour {

	public GameObject menu;

	public GameObject general, controles;

	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenCloseControles(){
		if (general.activeInHierarchy) {
			general.SetActive (false);
			controles.SetActive (true);
		} else {
			general.SetActive (true);
			controles.SetActive (false);
		}
	}


	public void OpenCloseInfo(){
		if (gameObject.activeInHierarchy) {
			gameObject.SetActive (false);
			menu.SetActive (true);
		} else {
			general.SetActive (true);
			controles.SetActive (false);
			gameObject.SetActive (true);
			menu.SetActive (false);
		}
	}
}
