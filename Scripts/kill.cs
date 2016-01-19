using UnityEngine;
using System.Collections;

public class kill : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //player gets damaged
            Debug.Log("Player gets damaged");
        }
    }
}
