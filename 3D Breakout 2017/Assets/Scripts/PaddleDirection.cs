using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleDirection : MonoBehaviour {

	public bool isReverse = false;


	void Update()
	{
		if (isReverse)
			Debug.Log ("Reverse");
	}
}
