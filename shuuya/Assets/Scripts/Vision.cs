using UnityEngine;
using System.Collections;

public class Vision : MonoBehaviour {

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
}
