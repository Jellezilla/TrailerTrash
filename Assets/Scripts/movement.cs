using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {


	Rigidbody rigid;
	public float speed = 0.30F;
	// Use this for initialization
	void Start () {
		rigid = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate() {
		if(Input.GetKeyDown (KeyCode.LeftArrow)) {
			rigid.AddForce(-Vector3.right * speed, ForceMode.Force);

		}
		if(Input.GetKeyDown (KeyCode.RightArrow)) {
			rigid.AddForce(Vector3.right * speed, ForceMode.Force);
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			transform.position = new Vector3(0.0F,0.9F,0.0F);
		}
	}
}
