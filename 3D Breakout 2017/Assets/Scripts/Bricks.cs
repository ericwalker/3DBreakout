using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

	public GameObject brickParticle;

	public int hp = 1;
	public int scoreValue = 10;

	private bool iscollided = false;
	private bool istriggered = false; 

	public ItemDropScript itemScript; // used to drop item
	private GameObject _ball;

	void Start(){
//		_ball = GameObject.Find ("Ball(Clone)");
	}

	void Update(){
// 		if (_ball.GetComponent<Ball> ().isFireBall) {
//			SetIsTrigger ();
//		}
	}

	void OnCollisionEnter(Collision col){ // when the ball hit the brick

		if (iscollided == false) {
			// do your things here that has to happen once
			if (col.gameObject.name == "Ball(Clone)") {
				// hit point, blood
				hp = hp - 1;

				if (hp == 0) {
					GameObject newexplosion = Instantiate (brickParticle, transform.position, Quaternion.identity);
					Destroy (newexplosion, 1);
		
					ScoreManager.score += scoreValue;
					GM.instance.DestroyBrick ();

					itemScript.CalculateItem (transform.position); // create and drop the item, ex: powerUp
//					Debug.Log (gameObject.name);
					Destroy (gameObject); // destroy the brick

					// Debug.Log ("Ball speed: " + col.gameObject.GetComponent<Rigidbody> ().velocity.magnitude);
				}
			}
			iscollided = true;
		} else {
//			Debug.Log (gameObject.name + " - ignore");
		}
	}

	void OnCollisionExit(Collision col){
		iscollided = false;
	}

	private void OnTriggerEnter(Collider col){
		if (istriggered == false) {

			if (col.gameObject.name == "Ball(Clone)") {
				GameObject newexplosion = Instantiate (brickParticle, transform.position, Quaternion.identity);
				Destroy (newexplosion, 1);

				ScoreManager.score += scoreValue;
				GM.instance.DestroyBrick ();

				itemScript.CalculateItem (transform.position); // create and drop the item, ex: powerUp

//				Debug.Log (gameObject.name + " (fireball)");

				Destroy (gameObject); // fireball can destroy bricks directly
			}
			istriggered = true;
		} else {
//			Debug.Log (gameObject.name + " (fireball) - ignore");
		}
	}

	void OnTriggerExit(Collider col){
		istriggered = false;
	}


	public void SetIsTrigger(){
//		Debug.Log ("set isTrigger " +		 gameObject.ToString());
		GetComponent<BoxCollider> ().isTrigger = true;
	}

	public void SetNotTrigger(){
		GetComponent<BoxCollider> ().isTrigger = false;
	}
}

