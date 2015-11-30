using UnityEngine;
using System.Collections;

public class Wood : BaseCargo 
{
	void OnCollisionEnter(Collision collision)
	{	
		Debug.Log ("This is Wood colliding!");
		base.CollisionHandler (collision);
		//And now what is special to Iron Collision
	}
}
