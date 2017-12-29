using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score = 0; // The player's score.

	Text scoreText;  // Reference to the Text component.

	// Use this for initialization
	void Awake () {
		scoreText = GetComponent<Text>();
		// score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString();
	}
}
