using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour {

//	public GameObject ball;
//	public GameObject cloneBall;

	public void clone(){
//		Debug.Log ("Clone!!");
		GM.instance.ball_num++;


		GameObject ball = GameObject.Find("Ball(Clone)"); // do it first to avoid finding the new cloneBall
		Ball ballScript = ball.GetComponent<Ball>();

		GameObject cloneBall = Instantiate (GM.instance.ballPrefab, transform.position, Quaternion.identity) as GameObject;
		GM.instance.AddNewCloneBall (cloneBall);

		cloneBall.GetComponent<Rigidbody> ().isKinematic = false;

		cloneBall.gameObject.GetComponent<TrailRenderer>().enabled = true;
		cloneBall.GetComponent<Ball> ().ballInPlay = true;
		cloneBall.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity;


		if (ballScript.isFireBall == true) {
//			Debug.Log ("It's fireball!");
			cloneBall.GetComponent<Ball>().isFireBall = true;
			cloneBall.GetComponent<ChangeMaterial> ().FireBall ();
		}
	}
}
