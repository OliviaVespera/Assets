using UnityEngine;
using System.Collections;

public class MemoryItem : MonoBehaviour {

    public EventLevel1 lv1;

	// Use this for initialization
	void Start () {
        GameObject lvl1 = GameObject.FindGameObjectWithTag("Event");
        lv1 = lvl1.GetComponent<EventLevel1>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lv1.memoryAmt+= 1;
            Destroy(transform.gameObject);
        }
    }
}
