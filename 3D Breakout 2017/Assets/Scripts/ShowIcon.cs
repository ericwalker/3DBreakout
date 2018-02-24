using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowIcon : MonoBehaviour {

	public GameObject fireIcon;

	public void ShowFireIcon()
	{
		fireIcon.GetComponent<RawImage>().enabled = true;
	}

	public void HideFireIcon()
	{
		fireIcon.GetComponent<RawImage>().enabled = false;
	}
}