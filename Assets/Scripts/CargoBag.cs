using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CargoBag : MonoBehaviour 
{
	public bool conditionMet = false;

	GameObject truckObject;
	Truck truck;

	private GameObject OnLevelUIObject;
	public OnLevelUI OnLevelUI;

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

		OnLevelUIObject = (GameObject)GameObject.Find ("OnLevelUI");
		OnLevelUI = OnLevelUIObject.GetComponent<OnLevelUI>();

		cargoController = GetComponent<CargoController>();

		StartCoroutine (WaitStartInspect());
	}

	IEnumerator WaitStartInspect()
	{
		yield return new WaitForSeconds (0.01f);
		InspectTrailer ();
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
		CheckOrder ();
	}

	public void CheckOrder()
	{
		InspectTrailer ();
		
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
			conditionMet = true;
			truck.SetActive (true);
		}
		else 
		{
			conditionMet = false;
		}
	}

	private void InspectTrailer()
	{
		//how many wood/Iron/Glass are there, update UI
		int wood = 0;
		int iron = 0;
		int glass = 0;

		foreach(GameObject cargo in trailer)
		{
			if(cargo.name.Contains("Wood"))
			{
				wood++;
			}
			else if(cargo.name.Contains("Iron"))
			{
				iron++;
			}
			else if(cargo.name.Contains("Glass"))
			{
				glass++;
			}
		}
		OnLevelUI.WriteOrder(wood, woodOrder,iron, ironOrder, glass, glassOrder);
	}

	public void RemoveCargo(GameObject cargo)
	{
		if(trailer.Contains(cargo))
		{
			trailer.Remove(cargo);
			InspectTrailer();
			conditionMet = false;
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
		if(Application.loadedLevel == 4)
		{
			bag.Add(cargoController.cargoList[3]);
		}
		if(Application.loadedLevel == 5)
		{
			bag.Add(cargoController.cargoList[3]);
			bag.Add(cargoController.cargoList[3]);
		}
	}
}
