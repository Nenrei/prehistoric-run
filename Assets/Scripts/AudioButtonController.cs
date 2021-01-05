using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButtonController : MonoBehaviour {

	public Sprite audioOn, audioOff;
	public AudioSource source;

	public GameObject music, effects;

	void Awake(){
		if (!GameData.musicEnabled) {
			music.GetComponent<Image> ().sprite = audioOff;
			source.Stop ();
		} else {
			music.GetComponent<Image> ().sprite = audioOn;
			source.Play ();
		}

		if (!GameData.effectsEnabled) {
			effects.GetComponent<Image> ().sprite = audioOff;
		} else {
			effects.GetComponent<Image> ().sprite = audioOn;
		}
	}

	public void TurnOnOffMusic(){
		if (GameData.musicEnabled) {
			GameData.musicEnabled = false;
			music.GetComponent<Image> ().sprite = audioOff;
			source.Stop ();
		} else {
			GameData.musicEnabled = true;
			music.GetComponent<Image> ().sprite = audioOn;
			source.Play ();
		}
	}

	public void TurnOnOffEffects(){
		if (GameData.effectsEnabled) {
			GameData.effectsEnabled = false;
			effects.GetComponent<Image> ().sprite = audioOff;
		} else {
			GameData.effectsEnabled = true;
			effects.GetComponent<Image> ().sprite = audioOn;
		}
	}
		

}
