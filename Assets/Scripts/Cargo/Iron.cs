using UnityEngine;
using System.Collections;

public class Iron : BaseCargo 
{
	void OnCollisionEnter(Collision collision)
	{	
		Debug.Log ("This is Iron colliding!");
		base.CollisionHandler (collision);
		//And now what is special to Iron Collision
	}
}
