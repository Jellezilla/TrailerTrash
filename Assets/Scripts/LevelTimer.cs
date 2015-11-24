using UnityEngine;
using System.Collections;

public class LevelTimer : MonoBehaviour {


	private bool loseScreen;
	private bool winScreen;
	private float maxTime = 45.0f;
	private float timeLeft;
	// Use this for initialization
	void Start () {
		timeLeft = maxTime;
		loseScreen = false;
		winScreen = false;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if (timeLeft >= 0) {
			StartCoroutine(LoseScreen());
		}
	}
	void OnGUI() {
		GUI.Label (new Rect (Screen.width / 2 - 100,15, 200, 25), "Time left: " + (int)timeLeft);  
		if (loseScreen) {
			// create GUI window.
		}
	}
	IEnumerator LoseScreen() {
		loseScreen = true;
		yield return new WaitForSeconds(3.0F);
	}
}
