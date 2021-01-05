using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {

	public Text level, time, humans, roars, farts, extintion, total;
	public TimeController timeController;
	public CountsController countsController;
	public LevelController levelController;
	public AudioClip scoreMusic;
	public AudioSource source;

	public Text multiTime, multiRoar, multiFarts, multiExt;

	string baseText = "0000000";
	int textLength = 7;

	int intLevel;
	int intTime;
	int intHumans;
	int intRoars;
	int intFarts;
	int intExtintion;
	int intTotal = 0;

	// Use this for initialization
	void Awake () {
		level.text = baseText;
		time.text = baseText;
		humans.text = baseText;
		roars.text = baseText;
		farts.text = baseText;
		extintion.text = baseText;
		total.text = baseText;

		multiTime.text = GameData.level.ToString ();
		multiRoar.text = GameData.roarPrice.ToString ();
		multiFarts.text = GameData.fartPrice.ToString ();
		multiExt.text = GameData.extintionPrice.ToString ();

		if (GameData.musicEnabled) {
			source.clip = scoreMusic;
			source.Play ();
			source.loop = false;
		}
	}

	void Update(){

	}

	void Increment(){
		if (intLevel != int.Parse (level.text)) {
			level.text = FillWithZero (intLevel.ToString ());
		} else if (intHumans != int.Parse (humans.text)) {
			level.gameObject.GetComponent<Animator> ().enabled = true;
			humans.text = FillWithZero (intHumans.ToString ());
		} else if (intTime != int.Parse (time.text)) {
			humans.gameObject.GetComponent<Animator> ().enabled = true;
			time.text = FillWithZero (intTime.ToString ());
		} else if (intRoars != int.Parse (roars.text)) {
			time.gameObject.GetComponent<Animator> ().enabled = true;
			roars.text = FillWithZero (intRoars.ToString ());
		} else if (intFarts != int.Parse (farts.text)) {
			roars.gameObject.GetComponent<Animator> ().enabled = true;
			farts.text = FillWithZero (intFarts.ToString ());
		} else if(intExtintion != int.Parse (extintion.text)){
			farts.gameObject.GetComponent<Animator> ().enabled = true;
			extintion.text = FillWithZero (intExtintion.ToString ());
		}else if (intTotal != int.Parse (total.text)) {
			extintion.gameObject.GetComponent<Animator> ().enabled = true;
			CancelInvoke ();
			InvokeRepeating ("IncrementTotal", 0.1f, 0.07f);
		} else {
			CancelInvoke ();
		}
	}

	void IncrementTotal(){
		 if (intTotal != int.Parse (total.text)) {
			total.text = FillWithZero (intTotal.ToString ());
		} else {
			total.gameObject.GetComponent<Animator> ().enabled = true;
			CancelInvoke ();
		}
	}




	public void CalculateScore () {

		intTotal = 0;

		intLevel = levelController.level;
		intTime = GameData.time;
		intHumans = GameData.humansEated;
		intRoars = GameData.usedRoars;
		intFarts = GameData.usedFarts;
		intExtintion = GameData.usedExtintions;

		intTotal += intRoars * GameData.roarPrice;
		intTotal += intFarts * GameData.fartPrice;
		intTotal += intExtintion * GameData.extintionPrice;
		intTotal += intTime * intLevel;
		intTotal += intHumans;

		//PlayGamesScript.AddScoreToLeaderboard (GPGSIds.leaderboard_clasificacion, (long) intTotal);


		InvokeRepeating ("Increment", 1.5f, 0.07f);

		/*
		total.text = FillWithZero(intTotal.ToString());
		*/
	}

	string FillWithZero(string value){
		int restZeros = textLength - value.Length;
		if (restZeros > 0) {

			for (int i = 0; i < restZeros; i++) {
				value = "0" + value;
			}

		}

		return value;
	}



	public void Exit(){
		Application.Quit ();
	}

	public void MainMenu(){
		GameData.InitValues ();
		SceneManager.LoadScene ("Main");
	}

	public void Restart(){
		GameData.InitValues ();
		SceneManager.LoadScene ("escena");
	}

	public void LeaderBoard(){
		//PlayGamesScript.ShowLeaderBoardUI ();
	}
}
