using UnityEngine;
using System.Collections;

public class BaseCargo : MonoBehaviour 
{
	public int cargoHealth;
	private bool cracked;

	public bool breakable;
	public float swingPower;
	public float weight = 15f;

	private GameObject newCrane;
	private CargoBag cargoBag;

	public bool collidedTrailer = false;
	public bool collidedGround = false;

	public Sprite UISprite;
	
	// Use this for initialization
	void Start () 
	{
		newCrane = (GameObject)GameObject.Find ("NewCrane");
		cargoBag = newCrane.GetComponent<CargoBag>();

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

	public void CollisionHandler(Collision collision)
	{
		if(collision.gameObject.tag == "Cargo" && !collidedTrailer) //increase score if first collision
		{
			collidedTrailer = true;
			cargoBag.AddCargoAndCheckOrder(gameObject);

			if(gameObject.name == "Iron(Clone)")
			{
				BaseCargo other = collision.gameObject.GetComponent<BaseCargo>();
				if(other.cracked)
				{
					cargoBag.RemoveCargo(other.gameObject);
					Destroy (other.gameObject);
				}
				other.cargoHealth--;
				if(other.cargoHealth <= 0)
				{
					other.cracked = true;
				}
			}
		}
		if(collision.gameObject.name == "Trailer" && !collidedTrailer) //increase score if first collision
		{
			collidedTrailer = true;
			cargoBag.AddCargoAndCheckOrder(gameObject);
		}
		if(collision.gameObject.name == "Plane" && !collidedGround && collidedTrailer) //decrase score if first collision
		{
			collidedGround = true;
			cargoBag.RemoveCargo(gameObject);
			Destroy (gameObject);
		}
	}
}
