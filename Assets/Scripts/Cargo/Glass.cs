using UnityEngine;
using System.Collections;

public class Glass : BaseCargo 
{
	void OnCollisionEnter(Collision collision)
	{	
		Debug.Log ("This is Glass colliding!");
		base.CollisionHandler (collision);
		//And now what is special to Iron Collision
	}
}
