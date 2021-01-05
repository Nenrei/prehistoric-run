using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowersController : MonoBehaviour {

	public GameObject fart;
	public GameObject roar;

	public Text fartText;
	public Text roarText;

	PlayerMovement move;
	CountsController countsController;

	// Use this for initialization
	void Awake () {
		move = GetComponent<PlayerMovement> ();
		countsController = GameObject.Find ("Canvas").GetComponent<CountsController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void UseFart(){
		if (!move.grounded && GameData.fartCount > 0 && !fart.activeInHierarchy) {
			countsController.DecrementHumanCount (GameData.fartPrice);
			ShowFart ();
			GameData.usedFarts++;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, move.jumpForce);
			Invoke ("HideFart", 0.25f);
		}
	}

	void ShowFart(){
		fart.SetActive (true);
	}

	void HideFart(){
		fart.SetActive (false);
	}

	public void UseRoar(){
		if (/*(move.runEnabled || !move.grounded) && */GameData.roarCount > 0 && !roar.activeInHierarchy) {
			countsController.DecrementHumanCount (GameData.roarPrice);
			ShowRoar ();
			Invoke ("HideRoar", 0.3f);
		}
	}

	void ShowRoar(){
		GetComponent<Animator> ().SetTrigger ("roar");
		roar.SetActive (true);
	}

	void HideRoar(){
		roar.SetActive (false);
	}

	public void RecalculatePowersAmount(){
		CalculateFart ();
		CalculateRoar ();
	}
		
	void CalculateFart(){
		GameData.fartCount = (int) Mathf.Round (GameData.humanCount / GameData.fartPrice);
		fartText.text = GameData.fartCount.ToString ();
	}

	void CalculateRoar(){
		GameData.roarCount = (int) Mathf.Round (GameData.humanCount / GameData.roarPrice);
		roarText.text = GameData.roarCount.ToString ();
	}
}
