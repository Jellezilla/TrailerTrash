using UnityEngine;
using System.Collections;

public class MissionLoseUI : MonoBehaviour 
{
	private int currentLevel;
	// Use this for initialization
	void Start () 
	{
		currentLevel = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space) && gameObject.GetComponent<Canvas>().enabled == true) 
		{
			LoseLevel();
		}
	}

	public void LoseLevel()
	{
		GameObject soundObject = GameObject.Find("SoundSystem");
		SoundSystem soundSystem = soundObject.GetComponent<SoundSystem>();
		soundSystem.Save();

		GameObject buttonClickObject = GameObject.Find ("ButtonClick");
		AudioSource buttonClick = buttonClickObject.GetComponent<AudioSource>();
		buttonClick.Play ();
		Application.LoadLevel (currentLevel);
	}
}
