using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerOfPowerup : MonoBehaviour {
	Image BarOfTimer;
//	Image BarOfTimerImage;
	float timeAmt = 5.0f;
//	float time;

	// Use this for initialization
	void Start () {
		BarOfTimer = this.GetComponent<Image>();
//		BarOfTimerImage = Image.Find("BarOfTimerImage");
//		time = timeAmt;
	}

	public void SetBarOfPowerup(float time)
	{
		
		if (time >= 0.01) {
//			BarOfTimerImage.SetActive (true);
			BarOfTimer.enabled = true;
			time -= Time.deltaTime;
			BarOfTimer.transform.localScale = new Vector3 (time / timeAmt, BarOfTimer.transform.localScale.y, BarOfTimer.transform.localScale.z); 
		} else if (time < 0.01) {
//			BarOfTimerImage.SetActive (false);
			BarOfTimer.enabled = false;
		}
	}
}