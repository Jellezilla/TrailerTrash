using UnityEngine;
using System.Collections;

public class Trailer : MonoBehaviour 
{
	private GameObject score;
	private ScoreHandler scoreHandler;

	// Use this for initialization
	void Start () 
	{
		score = GameObject.Find ("Score");
		scoreHandler = score.GetComponent<ScoreHandler>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
