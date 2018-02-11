using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuWithoutIcon : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {

//			GameIsPaused = !GameIsPaused;

			if (GameIsPaused) {
				Resume ();
			}

			else {
				Pause ();
			}

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
		//		GM.lives = 3;
		//		GM.instance.ball_num = 0;
		//		GM.instance.bricks = 21;
		//		ScoreManager.score = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Option(){

	}

	public void MainMenu(){
		SceneManager.LoadScene("Menu");
	}
}
