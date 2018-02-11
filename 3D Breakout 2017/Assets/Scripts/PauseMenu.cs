using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	private bool paused = false;
//	private Vector3 PauseUIPos = new Vector3 (20, 0, 0);


	void Start(){
		
//		PauseUI.SetActive (false);
	}

	void Update(){
		if (Input.GetButtonDown ("Pause")) {

			paused = !paused;
		}

		// if press the "Gear" icon, which is pause button
		if (paused) { 
			PauseUI.transform.localPosition = new Vector3(0, 0, 0);
//			PauseUI.SetActive (true);
			Time.timeScale = 0; // stop all of the motion in the game
		}

		// if press the Resume button
		if (!paused) {
			PauseUI.transform.localPosition = new Vector3(100, 0, 0);
//			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
			
	}

	// if press the pause button..
	public void Pause_Buttun(){
		paused = true;

	}

	public void Resume(){
		paused = false;
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
