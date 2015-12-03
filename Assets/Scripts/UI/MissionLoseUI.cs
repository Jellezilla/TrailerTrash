using UnityEngine;
using System.Collections;

public class MissionLoseUI : MonoBehaviour 
{
	private int currentLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoseLevel()
	{
		Application.LoadLevel (currentLevel);
	}
}
