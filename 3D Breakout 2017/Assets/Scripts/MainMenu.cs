using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public SceneFader sceneFader;
	public string levelSelectSceneName = "LevelSelect";

	public void PlayGame(){
//		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		sceneFader.FadeTo(levelSelectSceneName);
	}

	public void QuitGame(){
		Debug.Log ("QUIT!");
		Application.Quit ();
	}
}
