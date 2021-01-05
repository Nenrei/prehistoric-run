using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMeteorPooler : MonoBehaviour {

	public GameObject[] meteors;
	public GameObject despawn;
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartExtintion(){
		InvokeRepeating ("StartLaunch", 0f, 0.2f);
	}

	public void StopExtintion(){
		CancelInvoke ();
	}

	void StartLaunch(){
		for (int i = 0; i < meteors.Length; i++) {
			if(!meteors[i].activeInHierarchy){
				LaunchMeteor (meteors[i]);
				break;
			}
		}
	}

	void LaunchMeteor(GameObject meteor){
		meteor.transform.localPosition = new Vector3 (Random.Range(0f, 25f), 0f, 0f);

		SpriteRenderer meteorRenderer= meteor.GetComponent<SpriteRenderer> ();

		float scale = Random.Range (0.25f, 0.75f);
		Color myColor = new Color ();
		if (scale < 0.5f) {
			ColorUtility.TryParseHtmlString ("#6F6F6FD9", out myColor);
			meteorRenderer.sortingOrder = -3;
		} else {
			meteorRenderer.sortingOrder = -1;
			ColorUtility.TryParseHtmlString ("#FFFFFFED", out myColor);
		}
		meteorRenderer.color = myColor;

		meteor.transform.localScale = new Vector3 (scale, scale, 1f);

		meteor.SetActive (true);
	}

}
