using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour 
{
	public bool countChanges = true;
	public float weightGoal;
	private float totalWeight = 0;

	GameObject weight;

	Text weightText;

	GameObject goal;
	GameObject goal2;
	GameObject onWeight;
	GameObject currentLevel;
	
	Text goalText;
	Text goal2Text;
	Text onWeightText;
	Text currentLevelText;

	GameObject buttonObject;
	Button button;
	
	// Use this for initialization
	void Start () 
	{
		goal = GameObject.Find ("LevelGoal");
		goal2 = GameObject.Find ("LevelGoal2");
		onWeight = GameObject.Find ("OnWeight");
		currentLevel = GameObject.Find ("CurrentLevel");
		
		goalText = goal.GetComponent<Text>();
		goal2Text = goal2.GetComponent<Text>();
		onWeightText = onWeight.GetComponent<Text>();
		currentLevelText = currentLevel.GetComponent<Text>();
		currentLevelText.text = (Application.loadedLevel + 1).ToString();

		weight = GameObject.Find ("Weight");

		weightText = weight.GetComponent<Text>();

		buttonObject = GameObject.Find ("Button");
		button = buttonObject.GetComponent<Button>();

		goalText.text = weightGoal.ToString ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ChangeWeight(float weight)
	{
		if (countChanges) 
		{
			totalWeight += weight;
			onWeightText.text = totalWeight.ToString ();
		}
	}

	public void UpdateCanvas()
	{
		goal2Text.text = weightGoal.ToString ();
		weightText.text = totalWeight.ToString ();
		//change button text and destination
		Text[] answerArr = button.GetComponentsInChildren<Text>();
		Text answer = answerArr[0];

		if (totalWeight >= weightGoal) 
		{
			answer.text = "Win: Next";
			button.onClick.AddListener(
				delegate
				{
					WinLevel();
				}
			);
		} 
		else 
		{
			answer.text = "Fail: Restart";
			button.onClick.AddListener(
				delegate
				{
					LooseLevel();
				}
			);
		}
	}

	public void WinLevel() //restart if failed, continue to next if success
	{
		Application.LoadLevel (Application.loadedLevel+1);
	}

	public void LooseLevel() //restart if failed, continue to next if success
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void Work() //restart if failed, continue to next if success
	{
		Debug.Log ("Work Work");
	}
}
