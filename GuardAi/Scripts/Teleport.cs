using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    public Transform endPos;
    public Player pl;
    public NavMeshAgent pl2;
    public WayPointScript wp;

	// Use this for initialization
	void Start () {
        GameObject playa = GameObject.FindGameObjectWithTag("Player");
        pl = playa.GetComponent<Player>();
        pl2 = playa.GetComponent<NavMeshAgent>();
        GameObject waypt = GameObject.FindGameObjectWithTag("path_02");
        wp = waypt.GetComponent<WayPointScript>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit player");
            pl2.enabled = false;
            pl.transform.position = endPos.position;
            wp.transform.position = endPos.position;
            pl2.enabled = true;
        }
    }
}
