using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour {

	private float spd = 250.0F;
	Rigidbody rigid;
	bool active;
	// Use this for initialization
	void Start () {
		active = false;
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
		if (transform.position.x < 4.5f) {
			active = false;
			StartCoroutine(DriveOff());
		}
	}

	void FixedUpdate() {
		if (rigid.velocity.magnitude > spd) {
			rigid.velocity = rigid.velocity.normalized * spd;
		}
	}
	private void BackUp() {
		rigid.AddForce (-Vector3.right * spd, ForceMode.Force);
	}

	IEnumerator DriveOff() {

		Transform trailer = GameObject.FindWithTag ("Trailer").transform;
		trailer.parent = transform;

		while (transform.position.x < 20.0f) {
			rigid.AddForce(Vector3.right * (spd * 1.5f) , ForceMode.Force);
			yield return null;	
		}
	}
}
