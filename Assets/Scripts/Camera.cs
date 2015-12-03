using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour 
{
	private GameObject trailer;
	private bool repos = false;

	// Use this for initialization
	void Start () 
	{
		trailer = GameObject.Find ("Trailer");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(trailer.transform.position.x > 25f && !repos)
		{
			repos = true;
			transform.SetParent (null, true);

			//
			Vector3 target = new Vector3(transform.position.x,4.39f,transform.position.z);
			Vector3 targetDir = target - transform.position;
			float step = .01f * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
			transform.rotation = Quaternion.LookRotation(newDir);
		}
	}
}
