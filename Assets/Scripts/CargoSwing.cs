using UnityEngine;
using System.Collections;

public class CargoSwing : MonoBehaviour 
{
	public float swingPower;

	// Use this for initialization
	void Start () 
	{
		Rigidbody rigid = GetComponent<Rigidbody>();
		rigid.AddForce (transform.forward*swingPower);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
