using UnityEngine;
using System.Collections;

public class Glass : BaseCargo 
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
			crackedGlass.Play ();
		}
	}

	public override void PlayDestroy()
	{
		if (!truck.active)
		{
			destroyedGlass.Play ();
		}
	}
}
