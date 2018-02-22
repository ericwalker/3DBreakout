using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public SceneFader sceneFader;
	public string levelSceneName = "Scene1";

	public void PlayGame(){
		sceneFader.FadeTo(levelSceneName);
//		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame(){
		Debug.Log ("QUIT!");
		Application.Quit ();
	}
}
