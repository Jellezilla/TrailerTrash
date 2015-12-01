using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CargoController : MonoBehaviour 
{
	public CargoBag cargoBag;

	public List<GameObject> cargoList = new List<GameObject>();
	private GameObject nextCargo;
	private GameObject currentCargo;
	private bool waiting = false;

	private GameObject OnLevelUIObject;
	private OnLevelUI OnLevelUI;

	// Use this for initialization
	void Start () 
	{
		cargoBag = GetComponent<CargoBag>();

		OnLevelUIObject = (GameObject)GameObject.Find ("OnLevelUI");
		OnLevelUI = OnLevelUIObject.GetComponent<OnLevelUI>();

		cargoBag.ProduceBag ();

		SetNextCargo ();
		SpawnCargo ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown (KeyCode.Space))
		{
			DropCargo();
		}
	}

	private void SpawnCargo()
	{
		GameObject cargoToSpawn = nextCargo;
		GameObject cargo = (GameObject) Instantiate (cargoToSpawn, cargoToSpawn.transform.position, new Quaternion());
		cargo.transform.SetParent (gameObject.transform, false);
		HingeJoint hingeJoint = cargo.GetComponent<HingeJoint>();
		hingeJoint.connectedBody = GetComponent<Rigidbody>();
		currentCargo = cargo;
		SetNextCargo ();
		OnLevelUI.WriteNextCargo (nextCargo);
	}

	private void SetNextCargo()
	{
		nextCargo = cargoBag.GetNextCargo ();
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
