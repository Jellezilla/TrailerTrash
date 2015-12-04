using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour 
{
	private GameObject finalScoreObject;
	Text finalScore;

	// Use this for initialization
	void Start ()
	{
		finalScoreObject = GameObject.Find ("FinalScore");
		finalScore = finalScoreObject.GetComponent<Text>();
		finalScore.text = GameConstants.totalScore.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			GameObject buttonClickObject = GameObject.Find ("ButtonClick");
			AudioSource buttonClick = buttonClickObject.GetComponent<AudioSource>();
			buttonClick.Play ();
			Application.Quit();
		}
	}
}
