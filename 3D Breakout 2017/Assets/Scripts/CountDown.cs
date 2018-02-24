using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {


	Text countDownText;
	public float timeLeft = 5.0f;
	public bool count = false;


	void Awake () {
		
		countDownText = GetComponent<Text>();

	}

	void Update(){
		if (count == true){
//			Debug.Log ("count = true");
			countDownStart ();
			
		}
	}
		
	public void countDownStart () {

		GetComponent<Text> ().enabled = true;

		// set the bar of powerup
		GameObject BarOfTimer = GameObject.Find("BarOfTimer");
		TimerOfPowerup BarOfTimerScript = BarOfTimer.GetComponent<TimerOfPowerup>();
		BarOfTimerScript.SetBarOfPowerup (timeLeft);

		timeLeft -= Time.deltaTime;
		countDownText.text = "Time Left: " + Mathf.Round(timeLeft);

		//	if drop the ball while powerup is working
		if (timeLeft < -1) {
			count = false;
			GetComponent<Text> ().enabled = false;

			// hide the bar of powerup
			BarOfTimerScript.SetBarOfPowerup (0.0f);

		}

		// else if the powerup time is up
		else if(timeLeft < 0)
		{
			// hide the bar of powerup
			BarOfTimerScript.SetBarOfPowerup (0.0f);

			count = false;
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
}
