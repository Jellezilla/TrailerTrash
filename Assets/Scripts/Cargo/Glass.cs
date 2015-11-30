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
		//Destroy (gameObject);
	}
}
