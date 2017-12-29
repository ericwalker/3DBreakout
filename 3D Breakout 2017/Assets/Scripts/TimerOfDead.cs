using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerOfDead : MonoBehaviour {
	int timer = 0;
	public bool start_Timer = false;

	
	// Update is called once per frame
	void Update () {
		if (start_Timer) {
			StartCoroutine ("timerOfDead");
			start_Timer = false;
			Debug.Log (timer);
		}
	}

	IEnumerator timerOfDead(){
		yield return new WaitForSeconds (3.0f);
		timer++;
//		start_Timer = true;
	}
}
