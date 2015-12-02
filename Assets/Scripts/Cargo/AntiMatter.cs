using UnityEngine;
using System.Collections;

public class AntiMatter : BaseCargo 
{
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
		}
		if(collision.gameObject.name == "Trailer" || collision.gameObject.name == "Plane") //increase score if first collision
		{
			cargoBag.RemoveCargo(gameObject);
			Destroy (gameObject);
		}
	}
}
