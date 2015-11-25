using UnityEngine;
using System.Collections;

public class CargoSwing : MonoBehaviour 
{
	public float swingPower;

	// Use this for initialization
	void Start () 
	{
		Rigidbody rigid = GetComponent<Rigidbody>();
		int num = Random.Range (0,2);
		if (num == 1) 
		{
			rigid.AddForce (transform.forward*swingPower);
		} 
		else 
		{
			rigid.AddForce (-transform.forward*swingPower);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
