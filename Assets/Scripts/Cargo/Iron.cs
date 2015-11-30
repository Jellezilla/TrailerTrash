using UnityEngine;
using System.Collections;

public class Iron : BaseCargo 
{
	void Awake()
	{
		breakable = false;
	}

	void OnCollisionEnter(Collision collision)
	{	
		Debug.Log ("This is Iron colliding!");
		base.CollisionHandler (collision);
	}
}
