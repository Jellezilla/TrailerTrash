using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			GameObject buttonClickObject = GameObject.Find ("ButtonClick");
			AudioSource buttonClick = buttonClickObject.GetComponent<AudioSource>();
			buttonClick.Play ();
			Application.Quit();
		}
	}
}
