using UnityEngine;
using System.Collections;

public class LevelTimer : MonoBehaviour {


	private bool loseScreen;
	private bool winScreen;
	private float maxTime = 45.0f;
	private float timeLeft;
	private GameObject scoreUIObject;
	private GameObject score;
	private ScoreHandler scoreHandler;

	private bool timeOut = false;

	// Use this for initialization
	void Start ()
	{
		scoreUIObject = (GameObject)GameObject.Find ("ScoreUI");
		scoreUIObject.GetComponent<Canvas> ().enabled = false;
		score = GameObject.Find ("Score");
		scoreHandler = score.GetComponent<ScoreHandler>();

		timeLeft = maxTime;
		loseScreen = false;
		winScreen = false;
	}
		
		// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0) {
			timeLeft = 0;
			timeOut = true;
			scoreUIObject.GetComponent<Canvas> ().enabled = true;
			scoreHandler.UpdateCanvas();
			//StartCoroutine(ChangeLevel());
		}
	}
	void OnGUI() 
	{
		if(!timeOut)
		{
			GUI.Label (new Rect (Screen.width / 2 - 100,15, 200, 25), "Time left: " + (int)timeLeft);
		}
		  
		if (loseScreen) {

			// create GUI window.
		}
	}

	IEnumerator ChangeLevel() {
		float fadeTime = GameObject.Find ("SceneFader").GetComponent<Fading>().BegindFade(1);
		yield return new WaitForSeconds (fadeTime);

	}
}
