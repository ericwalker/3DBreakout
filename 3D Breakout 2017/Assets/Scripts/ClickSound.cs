using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour {


//	public AudioClip sound;

	private Button button { get { return GetComponent<Button>(); } }
	private AudioSource source { get { return GetComponent<AudioSource>(); } }

	void Start () 
	{
		gameObject.AddComponent<AudioSource>();
//		source.clip = sound;
		source.playOnAwake = false;

		button.onClick.AddListener(() => FindObjectOfType<AudioManager>().Play("ClickSound"));
	}

	// unused
	public void PlayClickSound(string clipName){
		FindObjectOfType<AudioManager>().Play(clipName);
	}
}
