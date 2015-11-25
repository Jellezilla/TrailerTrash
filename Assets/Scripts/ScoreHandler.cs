using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour 
{
	public float weightGoal;
	private float totalWeight = 0;

	GameObject weight;

	Text weightText;

	// Use this for initialization
	void Start () 
	{
		weight = GameObject.Find ("Weight");

		weightText = weight.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ChangeWeight(float weight)
	{
		totalWeight += weight;
		Debug.Log ("weight = " + totalWeight);
	}

	public void UpdateCanvas()
	{
		weightText.text = totalWeight.ToString ();
	}

	public void FinishLevel() //restart if failed, continue to next if success
	{
		Debug.Log ("Finish Level");
		Application.LoadLevel (Application.loadedLevel+1);
	}
}
