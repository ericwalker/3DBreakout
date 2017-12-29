using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {

	public Material[] material;
	private Renderer rend;
	private GameObject _ball;
	private GameObject [] _bricks;

	// Use this for initialization
	void Awake () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		rend.sharedMaterial = material [0];
	}
		
	// change the material of black brick
	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Ball(Clone)" && this.gameObject.name != "Ball(Clone)") {
			// Debug.Log ("change!");
			rend.sharedMaterial = material [1];
		}	
	}

	public void FireBall(){
//		_bricks = GameObject.FindGameObjectsWithTag ("Brick"); // use to enable the trigger of the bricks

		if (this.gameObject.GetComponent<Ball> ().isFireBall == true) {

			// change to fireball material
			rend.sharedMaterial = material [1];

			// change the trail material to fireballtrail
			this.gameObject.GetComponent<TrailRenderer>().enabled = false;
			this.gameObject.transform.Find ("FireBallTrail").GetComponent<TrailRenderer> ().enabled = true;
		}
		else if (this.gameObject.GetComponent<Ball> ().isFireBall == false) {

			// change back to whiteball material
			rend.sharedMaterial = material [0];


			// change the trail material to fireballtrail
			this.gameObject.GetComponent<TrailRenderer>().enabled = true;
			this.gameObject.transform.Find ("FireBallTrail").GetComponent<TrailRenderer> ().enabled = false;
		}
	}

	public void MakeCloneBallRed(){
		// change to fireball material
		rend.sharedMaterial = material [1];

		this.gameObject.GetComponent <Ball> ().isFireBall = true;
		// change the trail material to fireballtrail
		this.gameObject.GetComponent<TrailRenderer>().enabled = false;
		this.gameObject.transform.Find ("FireBallTrail").GetComponent<TrailRenderer> ().enabled = true;
	}

	public void BrickSetIsTrigger(){
		_bricks = GameObject.FindGameObjectsWithTag ("Brick"); // use to enable the trigger of the bricks

		// transform all of the bricks into trigger in order to pass all of the things
		foreach (GameObject Brick in _bricks) {
			if (Brick != null) {
				Brick.GetComponent<Bricks> ().SetIsTrigger ();
			}	
		}
	}

	public void BrickSetNotTrigger(){
		_bricks = GameObject.FindGameObjectsWithTag ("Brick"); // use to enable the trigger of the bricks

		// transform all of the bricks into trigger in order to pass all of the things
		foreach (GameObject Brick in _bricks) {
			if (Brick != null) {
				Brick.GetComponent<Bricks> ().SetNotTrigger ();
			}
		}
	}
}
