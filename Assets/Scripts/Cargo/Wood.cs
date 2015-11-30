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
		base.CollisionHandler (collision);
	}
}
