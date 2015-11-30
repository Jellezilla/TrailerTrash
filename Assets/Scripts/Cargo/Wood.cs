using UnityEngine;
using System.Collections;

public class Wood : BaseCargo 
{
	void Awake()
	{
		breakable = true;
	}

	void OnCollisionEnter(Collision collision)
	{	
		Debug.Log ("This is Wood colliding!");
		base.CollisionHandler (collision);
	}
}
