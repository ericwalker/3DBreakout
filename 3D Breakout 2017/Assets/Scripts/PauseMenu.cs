using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	
	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			FindObjectOfType<AudioManager>().Play("ClickSound");
//			GameIsPaused = !GameIsPaused;
			if (GameIsPaused) {
				Resume ();
			}

			else {
				Pause ();
			}
		} 
	}

	// if press the pause button
	public void Pause_Buttun(){
		if (GameIsPaused) {
			Resume ();
		}

		else {
			Pause ();
		}
	}

	public void Resume(){
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	void Pause(){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void Restart(){
		Time.timeScale = 1f;
		GameIsPaused = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Option(){

	}

	public void MainMenu(){
		Time.timeScale = 1f;

		GameIsPaused = false;
		SceneManager.LoadScene("Menu");
	}
}
