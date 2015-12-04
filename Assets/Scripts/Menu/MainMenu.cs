using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	private int startLevel = 0;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			GameObject soundObject = GameObject.Find("SoundSystem");
			SoundSystem soundSystem = soundObject.GetComponent<SoundSystem>();
			soundSystem.Save();

			GameObject buttonClickObject = GameObject.Find ("ButtonClick");
			AudioSource buttonClick = buttonClickObject.GetComponent<AudioSource>();
			buttonClick.Play ();
			Application.LoadLevel(startLevel);
		}
	}
}
