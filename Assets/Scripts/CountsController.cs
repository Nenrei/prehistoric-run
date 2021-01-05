using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountsController : MonoBehaviour {

	public GameObject humanCounter;
	public Text humanText;

	public void IncrementHumanCount(int amount){
		GameData.humanCount += amount;
		GameData.humansEated += amount;
		humanText.text = GameData.humanCount.ToString();
		humanText.GetComponentInParent<Animator> ().SetTrigger ("shake");

		GameObject.Find("Player").GetComponent<PowersController> ().RecalculatePowersAmount ();
		GameObject.Find("MeteorPooler").GetComponent<ExtintionController> ().CalculateExtintion ();
	}

	public void DecrementHumanCount(int amount){
		GameData.humanCount -= amount;
		humanText.text = GameData.humanCount.ToString();
		humanText.GetComponentInParent<Animator> ().SetTrigger ("shake");

		GameObject.Find("Player").GetComponent<PowersController> ().RecalculatePowersAmount ();
		GameObject.Find("MeteorPooler").GetComponent<ExtintionController> ().CalculateExtintion ();
	}
}
