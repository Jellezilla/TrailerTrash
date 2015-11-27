using UnityEngine;
using System.Collections;

public class CargoSwing : MonoBehaviour 
{
	public float swingPower;
	public float weight = 15f;

	private GameObject scoreObject;
	private ScoreHandler scoreHandler;

	public bool collidedTrailer = false;
	public bool collidedGround = false;
	
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

	void OnCollisionEnter(Collision collision) 
	{	
		if(collision.gameObject.name == "Cargo(Clone)" && !collidedTrailer) //increase score if first collision
		{
			collidedTrailer = true;
			scoreHandler.ChangeWeight(weight);
		}
		if(collision.gameObject.name == "Trailer" && !collidedTrailer) //increase score if first collision
		{
			collidedTrailer = true;
			scoreHandler.ChangeWeight(weight);
		}
		if(collision.gameObject.name == "Plane" && !collidedGround && collidedTrailer) //decrase score if first collision
		{
			collidedGround = true;
			scoreHandler.ChangeWeight(-weight);
		}
	}
}
