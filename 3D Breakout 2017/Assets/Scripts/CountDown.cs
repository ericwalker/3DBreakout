using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {


	Text FireballCountdownText, ReverseCountdownText;
	public float FireballCountdownTimeLeft = 5.0f;
	public float ReverseCountdownTimeLeft = 5.0f;
	public bool FireballCountdown = false;
	public bool ReverseCountdown = false;


	void Awake () {
		
		FireballCountdownText = GetComponent<Text>();
		ReverseCountdownText = GetComponent<Text> ();

	}

	void Update(){
		if (FireballCountdown == true){
//			Debug.Log ("count = true");
			FireballCountdownStart ();
		}
		if (ReverseCountdown == true){
			//			Debug.Log ("count = true");
			ReverseCountdownStart ();
		}
	}
		
	public void FireballCountdownStart () {

		GetComponent<Text> ().enabled = true;

		// set the bar of powerup
		GameObject BarOfTimerFire = GameObject.Find("BarOfTimerFire");
		TimerOfPowerup BarOfTimerFireScript = BarOfTimerFire.GetComponent<TimerOfPowerup>();
		BarOfTimerFireScript.SetBarOfTimer (FireballCountdownTimeLeft);

		FireballCountdownTimeLeft -= Time.deltaTime;
		FireballCountdownText.text = "Time Left: " + Mathf.Round(FireballCountdownTimeLeft);

		//	if drop the ball while powerup is working
		if (FireballCountdownTimeLeft < -1) {
			FireballCountdown = false;
			GetComponent<Text> ().enabled = false;

			// hide the bar of powerup
			BarOfTimerFireScript.SetBarOfTimer (0.0f);

		}

		// else if the powerup time is up
		else if(FireballCountdownTimeLeft < 0)
		{
			// hide the bar of powerup
			BarOfTimerFireScript.SetBarOfTimer (0.0f);

			FireballCountdown = false;
			GetComponent<Text> ().enabled = false;

			// the powerUp time is over, so turn the ball back to normal
			GameObject _ball;

			for (int i = 0; i < GM.instance.cloneBallList.Count; i++) {
				_ball = GM.instance.cloneBallList[i];

				_ball.GetComponent<Ball> ().isFireBall = false;
				_ball.GetComponent<ChangeMaterial> ().FireBall ();
				_ball.GetComponent<ChangeMaterial> ().BrickSetNotTrigger ();
			}
		}


	}

	public void ReverseCountdownStart () {

		GetComponent<Text> ().enabled = true;

		// set the bar of powerup
		GameObject BarOfTimerReverse = GameObject.Find("BarOfTimerReverse");
		TimerOfPowerup BarOfTimerReverseScript = BarOfTimerReverse.GetComponent<TimerOfPowerup>();
		BarOfTimerReverseScript.SetBarOfTimer (ReverseCountdownTimeLeft);

		ReverseCountdownTimeLeft -= Time.deltaTime;
		ReverseCountdownText.text = "Time Left: " + Mathf.Round(ReverseCountdownTimeLeft);

		//	if drop the ball while powerup is working
		if (ReverseCountdownTimeLeft < -1) {
			Debug.Log ("Die!");
			ReverseCountdown = false;
			GetComponent<Text> ().enabled = false;

			// hide the bar of powerup
			BarOfTimerReverseScript.SetBarOfTimer (0.0f);
		}

		// else if the powerup time is up
		else if(ReverseCountdownTimeLeft < 0)
		{
			// hide the bar of powerup
			BarOfTimerReverseScript.SetBarOfTimer (0.0f);

			ReverseCountdown = false;
			GetComponent<Text> ().enabled = false;

			GameObject _paddle;

			_paddle = GM.instance.clonePaddle;
			_paddle.GetComponent<Paddle> ().paddleDirection = 1;
		}


	}
}
