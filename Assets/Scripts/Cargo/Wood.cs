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

	public override void PlayCracked()
	{
		if (!truck.active)
		{
			crackedWood.Play ();
		}
	}
	
	public override void PlayDestroy()
	{
		if (!truck.active)
		{
			destoryedWood.Play ();
		}
	}
}
