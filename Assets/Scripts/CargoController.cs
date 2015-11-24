using UnityEngine;
using System.Collections;

public class CargoController : MonoBehaviour 
{
	public GameObject cargoObject;
	private GameObject currentCargo;
	private bool waiting = false;

	// Use this for initialization
	void Start () 
	{
		SpawnCargo ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown (KeyCode.C))
		{
			DropCargo();
		}
	}

	private void SpawnCargo()
	{
		GameObject cargo = (GameObject) Instantiate (cargoObject, cargoObject.transform.position, new Quaternion());
		cargo.transform.SetParent (gameObject.transform, false);
		HingeJoint hingeJoint = cargo.GetComponent<HingeJoint>();
		hingeJoint.connectedBody = GetComponent<Rigidbody>();
		currentCargo = cargo;
	}

	private void DropCargo()
	{
		if(!waiting)
		{
			currentCargo.transform.SetParent (null, true);
			Destroy(currentCargo.GetComponent<HingeJoint>());
			StartCoroutine (Wait ());
		}
	}

	IEnumerator Wait() 
	{
		waiting = true;
		yield return new WaitForSeconds (1);
		SpawnCargo ();
		waiting = false;
	}
}
