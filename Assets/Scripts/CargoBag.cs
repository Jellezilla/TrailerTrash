using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CargoBag : MonoBehaviour 
{
	GameObject truckObject;
	Truck truck;

	private CargoController cargoController;
	public int extraCargo;

	public int ironOrder;
	public int woodOrder;
	public int glassOrder;

	private int bagIndex = 0;

	public List<GameObject> order = new List<GameObject>();
	public List<GameObject> bag = new List<GameObject>();

	private List<GameObject> trailer = new List<GameObject>();

	public List<GameObject> tmpTrailer = new List<GameObject> ();

	void Awake()
	{
		truckObject = GameObject.Find ("Truck");
		truck = truckObject.GetComponent<Truck>();

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
	}

	public GameObject GetNextCargo()
	{
		GameObject cargo = bag [bagIndex];
		bagIndex++;
		if(bagIndex > bag.Count-1)
		{
			bagIndex = 0;
		}
		return cargo;
	}

	public void AddCargoAndCheckOrder(GameObject cargo)
	{
		trailer.Add (cargo);

		tmpTrailer = new List<GameObject> ();

		foreach (GameObject go in trailer)
		{
			tmpTrailer.Add(go);
		}

		int found = 0;
		foreach(GameObject go in order)
		{
			foreach(GameObject go2 in tmpTrailer)
			{
				if(go2.name.Contains(go.name))
				{
					found++;
					tmpTrailer.Remove(go2);
					break;
				}
			}
		}
		if (found == order.Count)
		{
			truck.SetActive();
		} 
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
