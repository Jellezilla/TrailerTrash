using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	private int startLevel = 0;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Application.LoadLevel(startLevel);
		}
	}
}
