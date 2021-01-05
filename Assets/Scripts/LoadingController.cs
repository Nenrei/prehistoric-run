using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour {

	public GameObject loadingScreen;
	public Text sencente;

	public GameObject player;

	public string[] sentences;


	// Use this for initialization
	void Awake () {
		//sencente.text = sentences [Random.Range (0, sentences.Length)];

		InvokeRepeating ("ChangeSentence", 0f, 5f);
		//Invoke ("ClosePanel", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		player.GetComponent<Animator> ().SetBool ("loading", true);
	}

	void ChangeSentence(){
		sencente.text = sentences [Random.Range (0, sentences.Length)];
	}

	void ClosePanel(){
		loadingScreen.SetActive (false);
	}
		
}
