using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BocataController : MonoBehaviour {

	public string[] messages;
	public Text messageText;

	// Use this for initialization
	void Awake () {
		messageText.text = messages[Random.Range(0, messages.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
