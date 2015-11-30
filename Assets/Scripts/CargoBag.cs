using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CargoBag : MonoBehaviour 
{
	private CargoController cargoController;
	public int extraCargo;

	public int ironOrder;
	public int woodOrder;
	public int glassOrder;

	public List<GameObject> order = new List<GameObject>();
	public List<GameObject> bag = new List<GameObject>();
	public List<GameObject> trailer = new List<GameObject>();

	public List<GameObject> tmpList = new List<GameObject> ();

	void Awake()
	{
		cargoController = GetComponent<CargoController>();
	}

	public void ProduceBag()
	{
		GenerateOrderList ();
		GenerateBagList ();

		for (int i = 0; i < bag.Count; i++) //shuffle bag
		{
			GameObject temp = bag[i];
			int randomIndex = Random.Range(i, bag.Count);
			bag[i] = bag[randomIndex];
			bag[randomIndex] = temp;
		}


		foreach (GameObject go in order) {
			tmpList.Add(go);
		}
	}

	public void AddCargoAndCheckOrder(GameObject cargo)
	{
		trailer.Add (cargo);
		/*
		bool theSame = true;
		int i=0;
		while(i < order.Count)
		{
			if(trailer.Contains(order[i]))
			{
				Debug.Log("contained");
				i++;
			}
			else
			{
				Debug.Log("did not contain, so we stop");
				theSame = false;  
				break;
			}
		}
		if(theSame)
		{
			Debug.Log("Mission Completed");
		}*/


		/////
		// this is the check that needs to run .. often!? 
		foreach (GameObject go in trailer) {
			//if(tmpList.Contains(go)) {
			foreach(GameObject go2 in tmpList) {
				if(go == go2) {
					Debug.Log("jeg er her");
					tmpList.Remove(go);
				}
			}
		}
		Debug.Log (tmpList.Count);
	}

	public void RemoveCargo(GameObject cargo)
	{
		if(trailer.Contains(cargo))
		{
			Debug.Log("was on trailer, so we remove it");
			trailer.Remove(cargo);
		}
	}

	private void GenerateOrderList()
	{
		for(int i = 0; i<ironOrder;i++)
		{
			order.Add(cargoController.cargoList[0]);
			bag.Add(cargoController.cargoList[0]);
		}
		for(int j = 0; j<woodOrder;j++)
		{
			order.Add(cargoController.cargoList[1]);
			bag.Add(cargoController.cargoList[1]);
		}
		for(int k = 0; k<glassOrder;k++)
		{
			order.Add(cargoController.cargoList[2]);
			bag.Add(cargoController.cargoList[2]);
		}
	}

	private void GenerateBagList()
	{
		for(int i = 0; i<extraCargo;i++)
		{
			if(ironOrder > 0)
			{
				bag.Add(cargoController.cargoList[0]);
			}
			if(woodOrder > 0)
			{
				bag.Add(cargoController.cargoList[1]);
			}
			if(glassOrder > 0)
			{
				bag.Add(cargoController.cargoList[2]);
			}
		}
	}
}
