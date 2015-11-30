using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour {


	GameObject trailer;
	private float spd = 20.0F;
	Rigidbody rigid;
	public bool active;
	Vector3 pos;
	bool init;

	private GameObject scoreUIObject;
	private GameObject score;
	private ScoreHandler scoreHandler;

	// Use this for initialization
	void Start () {
		active = false;
		init = true;
		trailer = GameObject.FindWithTag ("Trailer");
		rigid = transform.GetComponent<Rigidbody> ();

		scoreUIObject = (GameObject)GameObject.Find ("ScoreUI");
		score = GameObject.Find ("Score");
		scoreHandler = score.GetComponent<ScoreHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.U)) {

			active = true;
		}
		if (active) {
			StartCoroutine(StartEngine ());
		}
//		Debug.Log (rigid.velocity.magnitude);
		
	}

	void FixedUpdate() {
		if (rigid.velocity.magnitude > spd) {
			rigid.velocity = rigid.velocity.normalized * spd;
		}
	}



	IEnumerator StartEngine() 
	{
		yield return StartCoroutine(BackUp ());
		yield return StartCoroutine(DriveOff());
	}

	IEnumerator BackUp() 
	{
		while (Vector3.Distance(trailer.transform.position, transform.position) > 8.0f) {
			rigid.AddForce(-Vector3.right * 20.0f, ForceMode.Force);
			//Debug.Log (Vector3.Distance(trailer.position, transform.position));
	 		yield return null;
			}

	}

	IEnumerator DriveOff() {
		if (init) {
			
			init = false;
			//rigid.Sleep ();
			//trailer.transform.GetComponent<Rigidbody> ().Sleep ();
			//transform.parent = trailer.transform;

			rigid.isKinematic = true;
			trailer.GetComponent<Rigidbody> ().isKinematic = true;
			//trailer.transform.parent = transform;
			//HingeJoint hj = gameObject.AddComponent<HingeJoint> ();
//			HingeJoint hj2 = trailer.AddComponent<HingeJoint> ();
			SpringJoint hj2 = trailer.AddComponent<SpringJoint> ();
			//hj2.maxDistance = 1.0f;
			hj2.spring = 100;
			//hj2.connectedAnchor.Set (8.0f, 0.0f, 0.0f);
			//hj2.anchor.Set (8.0f, 0.0f, 0.0f);
			//hj2.useMotor = true;
			//hj2.useSpring = true;
			//	hj.connectedBody = trailer.GetComponent<Rigidbody> ();
			hj2.connectedBody = rigid;
			StartCoroutine (delayScore());
		}



		StartCoroutine (waitMethod(1.0f));

		//transform.parent = trailer.transform;
		//GameObject platform = GameObject.FindWithTag ("Platform");
		//HingeJoint hj = trailer.AddComponent<HingeJoint> ();
		//hj.connectedBody = rigid;
		//transform.GetComponent<HingeJoint> ().connectedBody = platform.GetComponent<Rigidbody>();
		yield return new WaitForSeconds (0.1f);
		active = false;

	}
	IEnumerator waitMethod(float wait) {
		yield return new WaitForSeconds (wait);
		StartCoroutine (testDrive ());
	}

	IEnumerator delayScore() 
	{
		yield return new WaitForSeconds (4.5f);
		scoreHandler.countChanges = false;
		scoreUIObject.GetComponent<Canvas> ().enabled = true;
		scoreHandler.UpdateCanvas();
	}

	IEnumerator testDrive () {
		Debug.Log ("testDrive!");
		rigid.isKinematic = false;
		trailer.GetComponent<Rigidbody> ().isKinematic = false;

		while (transform.position.x < 120.0f) { //Vector3.Distance(trailer.position, transform.position) > 50.0f) {    // 

			rigid.AddForce(Vector3.right * (spd * 0.5f) , ForceMode.Force);
			yield return null;	
		}
	}

}
