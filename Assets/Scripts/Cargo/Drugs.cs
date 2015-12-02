using UnityEngine;
using System.Collections;

public class Drugs : BaseCargo 
{
	void Awake()
	{
		breakable = false;
	}

	void OnCollisionEnter(Collision collision)
	{	
		base.CollisionHandler (collision);
	}
}
