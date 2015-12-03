using UnityEngine;
using System.Collections;

public class AntiMatter : BaseCargo 
{
	private int kills = 0;
	public int maxKills;

	void Awake()
	{
		breakable = false;
	}

	void OnCollisionEnter(Collision collision)
	{	
		//base.CollisionHandler (collision);
		AntiCollision (collision);
	}

	private void AntiCollision(Collision collision)
	{
		if (collision.gameObject.tag == "Cargo") 
		{
			BaseCargo other = collision.gameObject.GetComponent<BaseCargo>();
			cargoBag.RemoveCargo(other.gameObject);
			Destroy (other.gameObject);
			kills++;
			if(kills >= maxKills)
			{
				Selfdestruct();
			}
		}
		if(collision.gameObject.name == "Trailer" || collision.gameObject.name == "Plane") //increase score if first collision
		{
			Selfdestruct();
		}
	}

	private void Selfdestruct()
	{
		cargoBag.RemoveCargo(gameObject);
		Destroy (gameObject);
	}
}
