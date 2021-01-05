using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public AudioClip jump, hit, eat, countdown, explosion, meteor;

	AudioSource[] audio;


	// Use this for initialization
	void Awake () {
		audio = GetComponents<AudioSource> ();
	}

	public void PlayMeteor(){
		Play (meteor);
	}

	public void PlayExplosion(){
		Play (explosion);
	}
	
	public void PlayJump(){
		Play (jump);
	}

	public void PlayHit(){
		Play (hit);
	}

	public void PlayEat(){
		Play (eat);
	}

	public void PlayCountDown(){
		Play (countdown);
	}

	void Play(AudioClip clip){

		if (!GameData.effectsEnabled) {
			return;
		}

		AudioSource source = audio [0];

		if (source.isPlaying)
			source = audio [1];

		if (!source.isPlaying) {
			source.clip = clip;
			source.Play ();
		}
	}

}


