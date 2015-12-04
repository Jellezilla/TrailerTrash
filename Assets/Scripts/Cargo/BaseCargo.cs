using UnityEngine;
using System.Collections;

public class BaseCargo : MonoBehaviour 
{
	private GameObject truckObject;
	public Truck truck;

	//sounds
	GameObject crackedGlassObject;
	GameObject crackedWoodbject;
	GameObject destroyedGlassObject;
	GameObject destroyedWoodObject;

	public AudioSource crackedGlass;
	public AudioSource crackedWood;
	public AudioSource destroyedGlass;
	public AudioSource destoryedWood;

	public GameObject collisionObject;
	
	private AudioSource collision;

	public Material tempBreak;

	public int cargoHealth;
	private bool cracked;

	public bool breakable;
	public float swingPower;
	public float weight = 15f;

	private GameObject newCrane;
	public CargoBag cargoBag;

	public bool collidedTrailer = false;
	public bool collidedGround = false;

	public Sprite UISprite;
	
	// Use this for initialization
	void Start () 
	{
		truckObject = GameObject.Find ("Truck");
		truck = truckObject.GetComponent<Truck>();

		crackedGlassObject = GameObject.Find ("CrackedGlass");
		crackedWoodbject = GameObject.Find ("CrackedWood");
		destroyedGlassObject = GameObject.Find ("DestroyGlass");
		destroyedWoodObject = GameObject.Find ("DestroyWood");

		crackedGlass = crackedGlassObject.GetComponent<AudioSource>();
		crackedWood = crackedWoodbject.GetComponent<AudioSource>();;
		destroyedGlass = destroyedGlassObject.GetComponent<AudioSource>();;
		destoryedWood = destroyedWoodObject.GetComponent<AudioSource>();;

		collisionObject = GameObject.Find ("Collision");

		collision = collisionObject.GetComponent<AudioSource>();

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
			CollisionSound();
			collidedTrailer = true;
			cargoBag.AddCargoAndCheckOrder(gameObject);

			if(gameObject.name == "Iron(Clone)")
			{
				BaseCargo other = collision.gameObject.GetComponent<BaseCargo>();
				if(other.cracked)
				{
					other.PlayDestroy();
					cargoBag.RemoveCargo(other.gameObject);
					Destroy (other.gameObject);
				}
				other.cargoHealth--;
				if(other.cargoHealth <= 0)
				{
					other.cracked = true;
					other.PlayCracked();
					other.gameObject.GetComponent<Renderer>().material = other.tempBreak;
				}
			}
		}
		if(collision.gameObject.name == "Trailer" && !collidedTrailer) //increase score if first collision
		{
			CollisionSound();
			collidedTrailer = true;
			cargoBag.AddCargoAndCheckOrder(gameObject);
		}
		if(collision.gameObject.name == "Plane" && !collidedGround && collidedTrailer) //decrase score if first collision
		{
			PlayDestroy();
			collidedGround = true;
			cargoBag.RemoveCargo(gameObject);
			Destroy (gameObject);
		}
	}

	private void CollisionSound()
	{
		collision.Play ();
	}

	public virtual void PlayCracked()
	{

	}

	public virtual void PlayDestroy()
	{

	}
}
