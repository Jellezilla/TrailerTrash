using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TiltSensor : MonoBehaviour 
{
	public List<GameObject> edges = new List<GameObject>();
	public List<float> degrees = new List<float>();
	private float degreeModifier = 16f;
	
	void Start()
	{
		StartCoroutine (ConsumeDegree ());
	}

	void Update() 
	{
		//float modifier = GetTilt () * 100.0F;
		//Debug.Log (modifier);
		//Debug.Log ((GetTilt()*degreeModifier).ToString());
	}

	private float GetTilt()
	{
		return Mathf.Abs (edges[0].transform.position.y-edges[1].transform.position.y)*degreeModifier;
	}

	public float GetAverageTilt()
	{
		float total = 0;
		float nums = 0;
		foreach (float num in degrees) 
		{
			total += num;
			nums++;
		}
		return total / nums;
	}

	IEnumerator ConsumeDegree()
	{
		yield return new WaitForSeconds (0.1f);
		degrees.Add (GetTilt());
		StartCoroutine (ConsumeDegree ());
	}
}
