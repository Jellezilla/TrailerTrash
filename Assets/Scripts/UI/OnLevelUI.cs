using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnLevelUI : MonoBehaviour 
{
	private GameObject missionWinObject;
	private MissionWinUI missionWinUI;

	public float maxTime = 30.0f;
	public float timeLeft;
	private Truck truck;

	//fields
	GameObject timeObject;
	private Text time;

	GameObject nextObject;
	private Text next;

	GameObject cargoImageObject;
	Image cargoImage;

	GameObject woodObject;
	Text wood;

	GameObject ironObject;
	Text iron;

	GameObject glassObject;
	Text glass;

	// Use this for initialization
	void Awake () 
	{
		missionWinObject = GameObject.Find ("MissionWinUI");
		missionWinUI = missionWinObject.GetComponent<MissionWinUI>();

		//fields
		timeObject = GameObject.Find ("Time");
		time = timeObject.GetComponent<Text>();

		nextObject = GameObject.Find ("Next");
		next = nextObject.GetComponent<Text>();

		woodObject = GameObject.Find ("Wood");
		wood = woodObject.GetComponent<Text> ();
		
		ironObject = GameObject.Find ("Iron");
		iron = ironObject.GetComponent<Text>();
		
		glassObject = GameObject.Find ("Glass");
		glass = glassObject.GetComponent<Text>();

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
			truck.SetActive(false);
		}
		time.text = Mathf.Ceil(timeLeft).ToString ();
	}

	public void WriteNextCargo(GameObject cargo)
	{
		next.text = cargo.name;
		BaseCargo baseCargo = cargo.GetComponent<BaseCargo>();
		cargoImage.sprite = baseCargo.UISprite;
	}

	public void WriteOrder(int woodNum, int woodOrder, int ironNum, int ironOrder, int glassNum, int glassOrder)
	{
		wood.text = woodNum.ToString () + "/" + woodOrder.ToString ();
		iron.text = ironNum.ToString () + "/" + ironOrder.ToString ();
		glass.text = glassNum.ToString () + "/" + glassOrder.ToString ();

	}
}
