using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerOfPowerup : MonoBehaviour {
	Image BarOfTimer;
	float timeAmt = 5.0f;

	void Start () {
		BarOfTimer = this.GetComponent<Image>();
	}

	public void SetBarOfPowerup(float time)
	{
		if (time >= 0.01) {
			GetComponent<ShowIcon> ().ShowFireIcon ();
			BarOfTimer.enabled = true;
			time -= Time.deltaTime;
			BarOfTimer.transform.localScale = new Vector3 (time / timeAmt, BarOfTimer.transform.localScale.y, BarOfTimer.transform.localScale.z); 
		} 
		else if (time < 0.01)
		{
			GetComponent<ShowIcon> ().HideFireIcon ();
			BarOfTimer.enabled = false;	
		}
	}
}