using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

	public float time;
	public Text timeText;
	public bool run;

	// Use this for initialization
	void Start () {
		timeText = GetComponentInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (run) {
			time += Time.deltaTime;
			timeText.text = Mathf.Floor (time).ToString ();
			GameData.time = (int)Mathf.Floor (time);
		}
	}
}
