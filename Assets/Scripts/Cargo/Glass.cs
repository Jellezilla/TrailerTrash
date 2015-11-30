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
		Debug.Log ("This is Glass colliding!");
		Destroy (gameObject);
	}
}
