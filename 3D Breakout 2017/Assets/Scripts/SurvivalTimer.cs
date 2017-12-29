using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalTimer : MonoBehaviour {


	Text survivalTimerText;
	private string timer;
	private float temp; 

	void Awake () {
		survivalTimerText = GetComponent<Text>();
		// score = 0;
	}


	// Update is called once per frame
	void Update () {
		
		temp += Time.deltaTime; //#3
		TimeSpan timeSpan = TimeSpan.FromSeconds(temp); //#4

		timer = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); //#5
		survivalTimerText.text = timer; //#6

//		timer += Time.deltaTime;
//		survivalTimerText.text = "" + timer;
	}
}