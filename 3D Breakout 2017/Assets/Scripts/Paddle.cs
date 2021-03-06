﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1f;
	public float xBoundary = 7.5f; // boundary to restrict the move of the paddle

	public Vector3 playerPos = new Vector3 (0, 0, 0);
	private Touch touch;
	public int paddleDirection = 1; // if got the powerdownReverse, paddleDirection = -1.

	void Update () 
	{
		// let the ball follow the paddle
		if(GM.instance.attachedBall) {
			Rigidbody ballRigidbody = GM.instance.attachedBall.GetComponent<Rigidbody>();
//			ballRigidbody.position = playerPos + new Vector3(0, 1f, 0);
			ballRigidbody.transform.parent = this.transform;
		}

		float xPos = transform.position.x + (paddleDirection * Input.GetAxis("Horizontal") * paddleSpeed);

		if (Input.touchCount > 0) {
			touch = Input.GetTouch (0);
			xPos = -10f + 20 * touch.position.x / Screen.width; // screen width: 271
			Debug.Log ("screen width: " + Screen.width);
			Debug.Log ("touch position: " + touch.position.x);
		}
			
		playerPos = new Vector3 (Mathf.Clamp (xPos, -xBoundary, xBoundary), 0.0f, 0f);
//		playerPos = new Vector3 (xPos, 0.0f, 0f);
		transform.position = playerPos;

	}

	// to decide the angle of the ball according to the collision position on the paddle
	void OnCollisionEnter(Collision col){
		
		if (col.gameObject.name == "Ball(Clone)") {
			foreach (ContactPoint contact in col.contacts) {
				if (contact.thisCollider == GetComponent<Collider> ()) {
					// This is the paddle's contact point
					float dist = contact.point.x - transform.position.x;
					float paddleLength = transform.localScale.x;

					//	Debug.Log("Ball touched the paddle.");
					GameObject ball = col.gameObject;
					Ball playerScript = ball.GetComponent<Ball> ();

					playerScript.setBallSpeed (dist, paddleLength);
				
				}

			}
		}
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Powerup") {


			//	Debug.Log ("I have a coin.");
			if (col.gameObject.name == "Coin(Clone)") {
				FindObjectOfType<AudioManager> ().Play ("PickCoin");
			} else if (col.gameObject.name == "PowerupLive(Clone)") {
				FindObjectOfType<AudioManager> ().Play ("PickPowerupLive");
			} else {
				FindObjectOfType<AudioManager> ().Play ("PickPowerup");
			}
		} else if (col.gameObject.tag == "Powerdown") {
			FindObjectOfType<AudioManager> ().Play ("PickPowerdown");
		}

	}

}