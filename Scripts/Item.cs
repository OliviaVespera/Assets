using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public Player pl;
	Vector2 playerPos;

	// Use this for initialization
	void Start () {
		GameObject playa = GameObject.FindGameObjectWithTag ("Player");
		pl = playa.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			pickupItem(0);
		}
	}

	void pickupItem(int n)
	{
		if (n == 0)
		{
			Debug.Log("Picked up key");
			pl.editInventory(0,1);
			Destroy(gameObject);
		}
	}
}
