using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionWinUI : MonoBehaviour 
{
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
		order.text = Mathf.Ceil(orderPoints).ToString ();
		bonus.text = Mathf.Ceil((timeLeft*timeFactor)).ToString();
		levelScore.text = Mathf.Ceil((orderPoints + (timeLeft*timeFactor))).ToString ();
		GameConstants.totalScore += orderPoints + (timeLeft * timeFactor);
		totalScore.text = Mathf.Ceil(GameConstants.totalScore).ToString ();

		balanceLabel.text = "Average Tile:" + Mathf.Ceil (tiltSensor.GetAverageTilt ()).ToString ();
		balance.text = Mathf.Ceil ((1/tiltSensor.GetAverageTilt ())*1000).ToString ();
		Debug.Log(tiltSensor.GetAverageTilt ());
	}

	public void WinLevel()
	{
		Application.LoadLevel (Application.loadedLevel+1);
	}


}
