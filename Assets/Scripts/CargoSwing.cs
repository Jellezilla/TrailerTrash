using UnityEngine;
using System.Collections;

public class CargoSwing : MonoBehaviour 
{
	public float swingPower;
	public float weight = 15f;

	private GameObject scoreObject;
	private ScoreHandler scoreHandler;
	
	// Use this for initialization
	void Start () 
	{
		scoreObject = (GameObject)GameObject.Find ("Score");
		scoreHandler = scoreObject.GetComponent<ScoreHandler>();

		Rigidbody rigid = GetComponent<Rigidbody>();
		int num = Random.Range (0,2);
		if (num == 1) 
		{
			rigid.AddForce (transform.forward*swingPower);
		} 
		else 
		{
			rigid.AddForce (-transform.forward*swingPower);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.y < 0.5f)
		{
			scoreHandler.ChangeWeight(-weight);
			Destroy (gameObject);
		}
	}
}
