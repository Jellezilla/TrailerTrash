using UnityEngine;
using System.Collections;

public class ObjectProperties : MonoBehaviour {

	CraneController ch;
	public float weight;
	// Use this for initialization
	void Start () {
		//ch = GameObject.FindWithTag ("Crane").GetComponent<CraneController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate() {


		if (transform.position.y < 0.0f) {

			//ch.score -= 1;
			Destroy(gameObject);

		}
	}
	public void SetColor(Color color) {



	}
}
