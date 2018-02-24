using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropMotion: MonoBehaviour {

	public float dropSpeed = -7.5f;
//	public float resetDeley = 3f;
	private GameObject _paddle;
	private GameObject _ball;

//	Text counterText;



	// Update is called once per frame
	void Update () {
		transform.Translate (dropSpeed*Time.deltaTime, 0, 0);
	}

	private void OnTriggerEnter(Collider col){

		if (col.gameObject.name == "Paddle(Clone)") {
//			Debug.Log (gameObject.name);
			_paddle = col.gameObject;

			if (gameObject.name == "PowerupFire(Clone)") {

				// countdown of the powerUp
				GameObject CounDownText = GameObject.Find("CountDownText");
				CountDown CountDownScript = CounDownText.GetComponent<CountDown> ();
				CountDownScript.timeLeft = 5.0f;
				CountDownScript.count = true;

				for (int i = 0; i < GM.instance.cloneBallList.Count; i++) {
					_ball = GM.instance.cloneBallList[i];

					_ball.GetComponent<Ball> ().isFireBall = true;
					_ball.GetComponent<ChangeMaterial> ().FireBall ();
					_ball.GetComponent<ChangeMaterial> ().BrickSetIsTrigger ();
				}
			}


			if (gameObject.name == "PowerupLive(Clone)") {
				GM.lives++;
//				GM.livesText.text = "Lives: " + GM.lives;
//				GM.instance.livesText.text= "Lives: " + GM.lives;
				GM.instance.livesText.text= GM.lives.ToString();
			}

			if (gameObject.name == "PowerupStrech(Clone)" && _paddle.transform.localScale.x < 6) { // <= 2 times 
				_paddle.transform.localScale = new Vector3(_paddle.transform.localScale.x+1,1,1); // strech the paddle
				_paddle.GetComponent<Paddle>().xBoundary -= 0.5f; // change the xBoundary because streching the paddle
			}

			if (gameObject.name == "PowerdownShrink(Clone)") {
//				GM.instance.DestroyBall();
				if (_paddle.transform.localScale.x > 2) { // < 2 times
					_paddle.transform.localScale = new Vector3 (_paddle.transform.localScale.x - 1, 1, 1); // shrink the paddle
					_paddle.GetComponent<Paddle> ().xBoundary += 0.5f; // change the xBoundary because streching the paddle
				} else {  // 3 times
					GM.instance.LoseLife ();
				}
			}

			if (gameObject.name == "PowerupClone(Clone)") {

				if (GM.instance.ball_num < 3)
				{
					_ball = GameObject.Find ("Ball(Clone)");
					_ball.GetComponent<Clone> ().clone ();
				}
			}

			if (gameObject.name == "Coin(Clone)") {
//				GM.livesText.text = "Lives: " + GM.lives;
				ScoreManager.score += 100;
			}

			Destroy (gameObject); // get the powerUp
		}

		if (col.gameObject.name == "Floor") {
			Destroy (gameObject); // lost the powerUp
		}
	}
}
