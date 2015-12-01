using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnLevelUI : MonoBehaviour 
{
	public float maxTime = 30.0f;
	private float timeLeft;
	private Truck truck;

	//fields
	GameObject timeObject;
	private Text time;

	GameObject nextObject;
	private Text next;

	GameObject cargoImageObject;
	Image cargoImage;

	// Use this for initialization
	void Start () 
	{
		//fields
		timeObject = GameObject.Find ("Time");
		time = timeObject.GetComponent<Text>();

		nextObject = GameObject.Find ("Next");
		next = nextObject.GetComponent<Text>();

		cargoImageObject = GameObject.Find ("CargoImage");
		cargoImage = cargoImageObject.GetComponent<Image>();

		truck = GameObject.Find ("Truck").GetComponent<Truck> ();
		timeLeft = maxTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeLeft -= Time.deltaTime;
		
		if (timeLeft <= 0) 
		{
			timeLeft = 0;
			truck.active = true;
		}
		time.text = Mathf.Ceil(timeLeft).ToString ();
	}

	public void WriteNextCargo(GameObject cargo)
	{
		next.text = cargo.name;
		BaseCargo baseCargo = cargo.GetComponent<BaseCargo>();
		cargoImage.sprite = baseCargo.UISprite;
	}
}
