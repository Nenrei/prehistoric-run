using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {

	public GameObject shopPanel;
	public CountDownController countDown;

	public Text roarHave, fartHave, extintionHave;
	public CountsController counts;

	public int fartPrice, roarPrice, extintionPrice;

	public Text roarCost, fartCost, extintionCost;

	public CanvasGroup extintionButton;


	float time;

	// Use this for initialization
	void Awake () {
		time = 0f;
		counts = GetComponent<CountsController> ();
		fartCost.text = fartPrice.ToString();
		roarCost.text = roarPrice.ToString();
		extintionCost.text = extintionPrice.ToString();

		if(GameData.extintionCount < 1){
			extintionButton.alpha = 1f;
			extintionButton.interactable = true;
		}else{
			extintionButton.alpha = 0.5f;
			extintionButton.interactable = false;
		}

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OpenShop(){
		if (!countDown.gameObject.activeInHierarchy) {
			shopPanel.SetActive (true);
			//Time.timeScale = 0;
			roarHave.text = GameData.roarCount.ToString();
			fartHave.text = GameData.fartCount.ToString();
			extintionHave.text = GameData.extintionCount.ToString ();

			Time.timeScale = 0;
		}
	}

	public void CloseShop(){
		shopPanel.SetActive (false);
		Time.timeScale = 1;
	}


	public void BuyRoar(){
		int humans = int.Parse (counts.humanText.text);
		if (humans >= roarPrice) {
			humans -= roarPrice;
			roarHave.text = (int.Parse (roarHave.text) + 1).ToString ();
			//counts.IncrementRoarCount ();
			counts.DecrementHumanCount (roarPrice);
		}

	}

	public void BuyFart(){
		int humans = int.Parse (counts.humanText.text);
		if (humans >= fartPrice) {
			humans -= fartPrice;
			fartHave.text = (int.Parse (fartHave.text) + 1).ToString ();
			//counts.IncrementFartCount ();
			counts.DecrementHumanCount (fartPrice);
		}
	}

	public void BuyExtintion(){
		int humans = int.Parse (counts.humanText.text);
		if (humans >= extintionPrice && GameData.extintionCount < 1) {
			humans -= extintionPrice;
			GameData.extintionCount++;
			extintionHave.text = GameData.extintionCount.ToString ();
			extintionButton.alpha = 0.5f;
			extintionButton.interactable = false;
		}
	}
}
