using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour {

	public GameObject icon;

	public void ShowIcon()
	{
		icon.GetComponent<RawImage>().enabled = true;
	}

	public void HideIcon()
	{
		icon.GetComponent<RawImage>().enabled = false;
	}
}