using UnityEngine;
using System.Collections;

public class Chests : MonoBehaviour {

    public GameObject item;
    public Transform spawnPt;
    bool opened;

	// Use this for initialization
	void Start () {
        opened = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Opened()
    {
        if (opened == false)
        { 
            Debug.Log("Chest opened");
            opened = true;
            Instantiate(item, spawnPt.position, Quaternion.Euler(-90.0f, -180.0f, 0.0f));
        }
        else
        {
            Debug.Log("Chest is empty");
        }
    }
}
