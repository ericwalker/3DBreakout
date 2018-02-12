using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 20f;

	private Rigidbody rb;
	public bool ballInPlay;
	public bool isFireBall = false; // judge the ball is on fire or not

	public AudioClip paddleHit;
	public AudioClip brickHit;
	public AudioClip wallHit;
	public AudioClip missed;
	public AudioClip brickHitFireball;


	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		// set the method to launch the ball

		// launch the ball by finger
		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Ended && ballInPlay == false) {

				GM.instance.attachedBall = null;
				transform.parent = null;
				ballInPlay = true;
				rb.isKinematic = false;
				this.gameObject.GetComponent<TrailRenderer>().enabled = true;
				//rb.AddForce (new Vector3(ballInitialVelocity, ballInitialVelocity, 0));

				Vector3 movement = new Vector3 (ballInitialVelocity * Input.GetAxis ("Horizontal"), ballInitialVelocity, 0);
				// diagonal movement speed = movement speed along an axis.
				rb.velocity = Vector3.ClampMagnitude (movement, ballInitialVelocity); // set the started speed
			}


		} 	
		// launch the ball by keyboard
		else if (Input.GetButtonDown ("LaunchBall") && ballInPlay == false) { 

			GM.instance.attachedBall = null;
			transform.parent = null;
			ballInPlay = true;
			rb.isKinematic = false;
			this.gameObject.GetComponent<TrailRenderer>().enabled = true;
			//rb.AddForce (new Vector3(ballInitialVelocity, ballInitialVelocity, 0));

			Vector3 movement = new Vector3 (ballInitialVelocity * Input.GetAxis ("Horizontal"), ballInitialVelocity, 0);
			// diagonal movement speed = movement speed along an axis.
			rb.velocity = Vector3.ClampMagnitude (movement, ballInitialVelocity); // set the started speed
		}

//		if (ballInPlay == true) {
//			rb.velocity = ballInitialVelocity * (rb.velocity.normalized);
//		}
	}

	void OnCollisionEnter(Collision col){ // when the ball hit the other ball
			
		// keep the ball at the same speed
		rb.velocity = ballInitialVelocity * (rb.velocity.normalized);

		if (col.gameObject.name == "Paddle(Clone)") {
//			Debug.Log ("paddle");
			FindObjectOfType<AudioManager>().Play("PaddleHit");
		}

//		if (col.gameObject.name == "Wall1" || col.gameObject.name == "Wall2" || col.gameObject.name == "Roof") {
		if (col.gameObject.tag == "Wall") {
//			Debug.Log ("wall");
			FindObjectOfType<AudioManager>().Play("WallHit");
		}

		if (col.gameObject.tag == "Brick") {
//			Debug.Log ("brickHit");
			FindObjectOfType<AudioManager>().Play("BrickHit");
		}

//		if (col.gameObject.name == "Floor") {
//			Debug.Log ("Floor");
//		}
	}


	// when the fireball hit the bricks, play the sound effect
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Brick") {
			//			Debug.Log ("I have a coin.");
			PlayBallSound (brickHitFireball);
		}
	}



	public void setBallSpeed(float dist, float paddleLength){
		//Debug.Log("Ball touched the paddle.");
		//rb.AddForce(300f*dist,0,0);

		// set the angle of the velocity of the ball according to the position of collision with the paddle
		Vector3 movement = new Vector3 (dist*ballInitialVelocity, (paddleLength-dist-1)*ballInitialVelocity, 0);
		// diagonal movement speed = movement speed along an axis.
		rb.velocity = Vector3.ClampMagnitude (movement, ballInitialVelocity); // set the speed

		//Debug.Log ("Ball speed: " + rb.velocity.magnitude);
	}

	public void PlayBallSound(AudioClip clip){
		GetComponent<AudioSource> ().PlayOneShot (clip);
	}
}
