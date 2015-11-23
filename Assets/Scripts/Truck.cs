using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour {


	Transform trailer;
	private float spd = 250.0F;
	Rigidbody rigid;
	bool active;
	// Use this for initialization
	void Start () {
		active = false;
		trailer = GameObject.FindWithTag ("Trailer").transform;
		rigid = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.U)) {
			active = true;
		}
		if (active) {
			BackUp ();
		}
		if (transform.position.x < 8.5f) {
			active = false;
			StartCoroutine(DriveOff());
		}
	}

	void FixedUpdate() {
		if (rigid.velocity.magnitude > spd) {
			rigid.velocity = rigid.velocity.normalized * spd;
		}
	}
	IEnumerator BackUp() {
		//while (
		rigid.AddForce (-Vector3.right * spd, ForceMode.Force);
		yield return null;
	}

	IEnumerator DriveOff() {

		
		trailer.parent = transform;


		while (Vector3.Distance(trailer.position, transform.position) > 50.0f) {    // transform.position.x < 20.0f) {
			rigid.AddForce(Vector3.right * (spd * 1.5f) , ForceMode.Force);
			yield return null;	
		}
	}
}
