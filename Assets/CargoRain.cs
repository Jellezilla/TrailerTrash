using UnityEngine;
using System.Collections;

public class CargoRain : MonoBehaviour {


	public Transform woodPrefab;
	public Transform ironPrefab;
	public Transform glassPrefab;

	int rand;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		rand = Random.Range (1, 20);
		if (rand == 1) {
			RainDaCargo();
		}
	
	}
	void RainDaCargo() {
		int typeRand = Random.Range (1, 4);
		Vector3 pos = GetRandSpawnPos ();
		if (typeRand == 1) {
			Instantiate(woodPrefab, pos, Quaternion.identity);
		} else if (typeRand == 2) {
			Instantiate(ironPrefab, pos, Quaternion.identity);
		} else if (typeRand == 3) {
			Instantiate(glassPrefab, pos, Quaternion.identity);
		}

	}

	Vector3 GetRandSpawnPos () {
		float randx = Random.Range (0.0f, 14.5f);
		float randy = 5.0f;
		float randz = Random.Range (-9.0f, -0.5f);
		return new Vector3(randx, randy, randz);
	}
}

