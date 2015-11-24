using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour {


	Transform trailer;
	private float spd = 50.0F;
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
			StartCoroutine(StartEngine ());
		}
		
	}

	void FixedUpdate() {
		if (rigid.velocity.magnitude > spd) {
			rigid.velocity = rigid.velocity.normalized * spd;
		}
	}



	IEnumerator StartEngine() {
		yield return StartCoroutine(BackUp ());
		yield return StartCoroutine(DriveOff());

	}

	IEnumerator BackUp() {
		while (Vector3.Distance(trailer.position, transform.position) > 8.0f) {
			rigid.AddForce(-Vector3.right * 20.0f, ForceMode.Force);
			//Debug.Log (Vector3.Distance(trailer.position, transform.position));
	 		yield return null;
			}

	}

	IEnumerator DriveOff() {

		Debug.Log ("drive off mofo!");
		trailer.parent = transform;

		active = false;

		while (transform.position.x < 20.0f) { //Vector3.Distance(trailer.position, transform.position) > 50.0f) {    // 
			rigid.AddForce(Vector3.right * (spd * 1.5f) , ForceMode.Force);
			yield return null;	
		}
	}

}
