using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public GameObject menu, loading;

	public Slider bar;

	public void Play(){
		menu.SetActive (false);
		loading.SetActive (true);

		AsyncOperation operation =  SceneManager.LoadSceneAsync ("escena");
		//StartCoroutine (LoadAsync());
	}

	IEnumerator LoadAsync(){
		AsyncOperation operation =  SceneManager.LoadSceneAsync ("escena");

		while (!operation.isDone) {


				
			bar.value = operation.progress;
			Debug.Log (bar.value);

			yield return null;
		}
	}

	public void quit(){
		Application.Quit ();
	}

	public void LeaderBoard(){
		//PlayGamesScript.ShowLeaderBoardUI ();
	}

}
