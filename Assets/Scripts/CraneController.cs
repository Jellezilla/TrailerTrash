using UnityEngine;
using System.Collections;

public class CraneController : MonoBehaviour {
	
	public GameObject Cube1;

	private Rigidbody rigid;

	float maxUpAndDown = 0.01F;             // amount of meters going up and down
	float speed = 20.0F;
	float maxSpeed = 20.0F;
	private float angle = 0.0F;
	private bool active;

	private float toDegrees = Mathf.PI / 180;
	// Use this for initialization
	void Start () {
		rigid = transform.GetComponent<Rigidbody> ();
		rigid.useGravity = false;
		active = true;
		StartCoroutine (SpawnCall (5.0F));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.J)) {
		
			SpawnNewObject();	
		}
		if (Input.GetKey (KeyCode.A)) {
			rigid.AddForce(-Vector3.right * (speed/3), ForceMode.Force);
		}
		if (Input.GetKey (KeyCode.D)) {
			rigid.AddForce(Vector3.right * (speed/3), ForceMode.Force);
		}

	}
	void FixedUpdate() {
		if (active)
		{
			angle += speed * Time.deltaTime;
			if (angle > 360) angle -= 360;
			transform.position = new Vector3(transform.position.x + (maxUpAndDown * Mathf.Cos(angle * toDegrees)), transform.position.y, transform.position.z);
		}


		// restrictions
		if(rigid.velocity.magnitude > maxSpeed)
		{
			rigid.velocity = rigid.velocity.normalized * maxSpeed;
		}
		if (transform.position.x < -1.43f) 
			transform.position = new Vector3 (-1.42f, transform.position.y, transform.position.z);
		if (transform.position.x > 1.43f) 
			transform.position = new Vector3 (1.42f, transform.position.y, transform.position.z);
		
	}

	void SpawnNewObject() {
		
		
		
		Vector3 pos = new Vector3 (transform.position.x, 5.0F, 0.0F);
		//(Instantiate(Cube1, pos, transform.rotation) as GameObject).transform.parent = transform;
		Instantiate (Cube1, pos, transform.rotation);


	}
	IEnumerator SpawnCall(float wait) {
		SpawnNewObject ();
		yield return new WaitForSeconds (wait);


		if (active) {
			StartCoroutine(SpawnCall(Random.Range (3,5)));
		}
	}
}
