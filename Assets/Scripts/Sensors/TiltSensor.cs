using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TiltSensor : MonoBehaviour 
{
	public List<GameObject> edges = new List<GameObject>();

	void Update() 
	{
		//float modifier = GetTilt () * 100.0F;
		//Debug.Log (modifier);
		Debug.Log (GetTilt().ToString());
	}
	public float GetTilt()
	{
		return Mathf.Abs (edges[0].transform.position.y-edges[1].transform.position.y);
	}
}
