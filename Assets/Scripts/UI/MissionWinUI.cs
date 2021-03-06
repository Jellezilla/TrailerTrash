﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionWinUI : MonoBehaviour 
{
	private int currentLevel;

	private GameObject trailer;
	private TiltSensor tiltSensor;

	public float orderPoints;
	private float timeFactor = 25;

	GameObject orderObject;
	GameObject bonusObject;
	GameObject levelScoreObject;
	GameObject totalScoreObject;
	GameObject balanceObject;
	GameObject balanceLabelObject;

	Text order;
	Text bonus;
	Text levelScore;
	Text totalScore;
	Text balance;
	Text balanceLabel;

	// Use this for initialization
	void Start () 
	{
		currentLevel = Application.loadedLevel;

		orderObject = GameObject.Find ("Order");
		bonusObject = GameObject.Find ("Bonus");
		levelScoreObject = GameObject.Find ("LevelScore");
		totalScoreObject = GameObject.Find ("TotalScore");

		order = orderObject.GetComponent<Text>();
		bonus = bonusObject.GetComponent<Text>();
		levelScore = levelScoreObject.GetComponent<Text>();
		totalScore = totalScoreObject.GetComponent<Text>();

		trailer = GameObject.Find ("Trailer");
		tiltSensor = trailer.GetComponent<TiltSensor> ();

		balanceObject = GameObject.Find ("Balance");
		balance = balanceObject.GetComponent<Text>();

		balanceLabelObject = GameObject.Find ("BalanceLabel");
		balanceLabel = balanceLabelObject.GetComponent<Text>();
	}

	public void UpdateFields(float timeLeft)
	{
		balanceLabel.text = "Average tilt was " + Mathf.Ceil (tiltSensor.GetAverageTilt ()).ToString () + " degress";
		float halfOrder = orderPoints / 2;
		float tiltMod = halfOrder / 35;

		order.text = Mathf.Ceil(orderPoints).ToString ();
		bonus.text = Mathf.Ceil((timeLeft*timeFactor)).ToString();
		balance.text = Mathf.Ceil (halfOrder-((tiltSensor.GetAverageTilt ())*tiltMod)).ToString ();
		levelScore.text = Mathf.Ceil((orderPoints + (timeLeft*timeFactor))+halfOrder-((tiltSensor.GetAverageTilt ())*tiltMod)).ToString ();
		GameConstants.totalScore += Mathf.Ceil(orderPoints + (timeLeft * timeFactor)+(halfOrder-((tiltSensor.GetAverageTilt ())*tiltMod)));

		totalScore.text = Mathf.Ceil(GameConstants.totalScore).ToString ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space) && gameObject.GetComponent<Canvas>().enabled == true) 
		{
			WinLevel();
		}
	}

	public void WinLevel()
	{
		GameObject soundObject = GameObject.Find("SoundSystem");
		SoundSystem soundSystem = soundObject.GetComponent<SoundSystem>();
		soundSystem.Save();

		GameObject buttonClickObject = GameObject.Find ("ButtonClick");
		AudioSource buttonClick = buttonClickObject.GetComponent<AudioSource>();
		buttonClick.Play ();
		Application.LoadLevel (currentLevel+1);
	}


}
