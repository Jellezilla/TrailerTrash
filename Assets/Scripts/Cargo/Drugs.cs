using UnityEngine;
using System.Collections;

public class Drugs : BaseCargo 
{
	void OnCollisionEnter(Collision collision)
	{	
		Debug.Log ("This is Drugs colliding!");
		base.CollisionHandler (collision);
		//And now what is special to Iron Collision
	}
}
