using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	public GameObject menu;

	public void OpenCloseSettings(){
		if (gameObject.activeInHierarchy) {
			gameObject.SetActive (false);
			menu.SetActive (true);
		} else {
			gameObject.SetActive (true);
			menu.SetActive (false);
		}
	}


}
