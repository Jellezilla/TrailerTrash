using UnityEngine;
using System;
using System.Collections;


public class GUInterface : MonoBehaviour {

	Font myFont;


	// Use this for initialization
	void Start () {
		myFont = Resources.Load ("GROBOLD.ttf") as Font;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void GUI() {
		if (Application.loadedLevel == 0) {
				
		}
		
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = myFont;

		//GUI.Label (new Rect (10, 10, 100, 30), "Hello World!", myStyle);

	}
}
