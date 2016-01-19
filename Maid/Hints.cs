using UnityEngine;
using System.Collections;

public class Hints : MonoBehaviour {

void OnTriggerStay(Collider other){
		if(other.tag == "Hero")
		{
			Debug.Log("I will give you hints.");
		}
	}
}