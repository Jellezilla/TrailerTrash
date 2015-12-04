using UnityEngine;
using System.Collections;

public class menuTruck : MonoBehaviour {
	float speed;
	float startX;
	Rigidbody rigid;
	// Use this for initialization
	void Start () {
		speed = Random.Range (5.05f, 5.15f);
		startX = transform.position.x;
		rigid = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		rigid.AddForce ((Vector3.right *speed), ForceMode.Force);
		//transform.position = new Vector3 ((transform.position.x + rand), transform.position.y, transform.position.z);

		if (transform.position.x > 15.0f) {
			transform.position = new Vector3(startX, transform.position.y, transform.position.z);
		}

	
	}

	void FixedUpdate() {
		if (rigid.velocity.magnitude > speed) {
			rigid.velocity = rigid.velocity.normalized * speed;
		}
	}
}
