using UnityEngine;
using System.Collections;

public class CraneController : MonoBehaviour {
	
	public GameObject Cube1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.J)) {
		
			SpawnNewObject();	
		}
	}


	void SpawnNewObject() {



		Vector3 pos = new Vector3 (0.0F, 5.0F, 0.0F);
		(Instantiate(Cube1, pos, transform.rotation) as GameObject).transform.parent = transform;


	}
}
