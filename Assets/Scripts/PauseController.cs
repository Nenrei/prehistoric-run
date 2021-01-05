using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

	public GameObject pausePanel;
	public CountDownController countDown;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenPause(){
		if (!countDown.gameObject.activeInHierarchy) {
			pausePanel.SetActive (true);
			Time.timeScale = 0;
		}
	}

	public void ClosePause(){
		pausePanel.SetActive (false);
		Time.timeScale = 1;
	}

	public void quit(){
		Application.Quit ();
	}

	public void Restart(){
		Time.timeScale = 1;
		GameData.InitValues ();
		SceneManager.LoadScene ("escena");
	}

	public void MainMenu(){
		Time.timeScale = 1;
		GameData.InitValues ();
		SceneManager.LoadScene ("Main");
	}
}
