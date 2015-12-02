using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionWinUI : MonoBehaviour 
{
	public float orderPoints;
	private float timeFactor = 25;

	GameObject orderObject;
	GameObject bonusObject;
	GameObject levelScoreObject;
	GameObject totalScoreObject;

	Text order;
	Text bonus;
	Text levelScore;
	Text totalScore;

	// Use this for initialization
	void Start () 
	{
		orderObject = GameObject.Find ("Order");
		bonusObject = GameObject.Find ("Bonus");
		levelScoreObject = GameObject.Find ("LevelScore");
		totalScoreObject = GameObject.Find ("TotalScore");

		order = orderObject.GetComponent<Text>();
		bonus = bonusObject.GetComponent<Text>();
		levelScore = levelScoreObject.GetComponent<Text>();
		totalScore = totalScoreObject.GetComponent<Text>();
	}

	public void UpdateFields(float timeLeft)
	{
		order.text = Mathf.Ceil(orderPoints).ToString ();
		bonus.text = Mathf.Ceil((timeLeft*timeFactor)).ToString();
		levelScore.text = Mathf.Ceil((orderPoints + (timeLeft*timeFactor))).ToString ();
		GameConstants.totalScore += orderPoints + (timeLeft * timeFactor);
		totalScore.text = Mathf.Ceil(GameConstants.totalScore).ToString ();
	}

	public void WinLevel()
	{
		Application.LoadLevel (Application.loadedLevel+1);
	}


}
