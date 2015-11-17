using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {


	Rigidbody rigid;
	public float speed = 10.0F;
	public float maxSpeed = 10.0F;
	public float jumpSpeed = 0.3F;
	// Use this for initialization
	void Start () {
		rigid = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate() {
		if(Input.GetKey (KeyCode.LeftArrow)) {
			rigid.AddForce(-Vector3.right * speed, ForceMode.Force);

		}
		if(Input.GetKey (KeyCode.RightArrow)) {
			rigid.AddForce(Vector3.right * speed, ForceMode.Force);
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			rigid.AddForce(Vector3.up * jumpSpeed/2, ForceMode.Impulse);
		}
		if(rigid.velocity.magnitude > maxSpeed)
		{
			rigid.velocity = rigid.velocity.normalized * maxSpeed;
		}
		
	}
}
