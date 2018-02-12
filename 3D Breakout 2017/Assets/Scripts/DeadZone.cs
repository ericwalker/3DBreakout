using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	// void OnTriggerEnter(){
	void OnCollisionEnter(Collision col){

		if (col.gameObject.name == "Ball(Clone)") {

			GM.instance.RemoveCloneBall (col.gameObject);
//			Destroy (col.gameObject);

			col.gameObject.GetComponent<MeshRenderer>().enabled = false;
			col.gameObject.GetComponent<TrailRenderer>().enabled = false;
			col.gameObject.transform.Find ("FireBallTrail").GetComponent<TrailRenderer> ().enabled = false;
			col.gameObject.transform.position = new Vector3(0, -15f, 0); // avoid the ball touch the dead ball
			col.gameObject.GetComponent<Rigidbody> ().isKinematic = true;


			// play the missed sound
			if (--GM.instance.ball_num == 0) {
//				col.gameObject.GetComponent<Ball> ().PlayBallSound (col.gameObject.GetComponent<Ball> ().missed);
//				StartCoroutine (TimerOfDead (col.gameObject)); // delay 1sec for playing missed sound

				Destroy (col.gameObject);
				FindObjectOfType<AudioManager>().Play("PlayerDeath");
				GM.instance.LoseLife ();
			} else {
				Destroy (col.gameObject);
			}
		}
	}


	// ** unused after adding AudioManager
	// use to play the missed sound before detroy the ball
	private IEnumerator TimerOfDead(GameObject ball){
		yield return new WaitForSeconds (1.0f);

		Destroy (ball);
	}




}