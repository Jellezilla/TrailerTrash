using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelEndUI : MonoBehaviour 
{
	private GameObject winObject;
	private Button winButton;

	private GameObject loseObject;
	private Button loseButton;

	// Use this for initialization
	void Start () 
	{
		winObject = GameObject.Find ("WinLevel");
		winButton = winObject.GetComponent<Button>();

		loseObject = GameObject.Find ("LoseLevel");
		loseButton = loseObject.GetComponent<Button>();
	}

	public void SetEndUI(bool win)
	{
		if (win) 
		{
			Destroy (loseObject);
		} 
		else 
		{
			Destroy (winObject);
		}
	}

	private void WinLevel()
	{
		Application.LoadLevel (Application.loadedLevel+1);
	}

	private void LoseLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
