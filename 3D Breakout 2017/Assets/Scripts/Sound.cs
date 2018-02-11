using UnityEngine.Audio;
using UnityEngine;

// make the custom class visible in the inspector
[System.Serializable]
public class Sound  {

	// make the custom class be visible in the inspector
	public string name;

	public AudioClip clip;

	[Range(0f,1f)]
	public float volume;
	[Range(.1f,3f)]
	public float pitch;

	[HideInInspector]
	public AudioSource source;

}
