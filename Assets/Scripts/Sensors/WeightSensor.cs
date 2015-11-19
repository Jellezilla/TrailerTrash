using UnityEngine;
using System.Collections;

public class WeightSensor : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("something hit. I wonder what it weighs?");
	}
}
