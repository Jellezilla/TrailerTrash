using UnityEngine;
using System.Collections;

public class SoundSystem : MonoBehaviour 
{
	private GameObject radioObject;

	AudioSource radio;

	// Use this for initialization
	void Start () 
	{
		radioObject = GameObject.Find ("Radio");
		radio = radioObject.GetComponent<AudioSource> ();
		radio.Play ();
		radio.time = GameConstants.radioTime;
	}

	public void Save()
	{
		GameConstants.radioTime = radio.time;
	}
}
