using UnityEngine;
using System.Collections;

public class EventLevel1 : MonoBehaviour {

    public int memoryReq;
    public int talkReq;
    public int memoryAmt = 0;
    public Door memoryDoor;
    public Player pl;
    public int amtTalked = 0;
    public GameObject ghosto;
    public Transform ghostSpawn;
    public Light main;
    public GameObject[] subs;

	// Use this for initialization
	void Start () {
        GameObject playa = GameObject.FindGameObjectWithTag("Player");
        pl = playa.GetComponent<Player>();
        GameObject door = GameObject.FindGameObjectWithTag("MemoryDoor");
        memoryDoor = door.GetComponent<Door>();
    }
	
	// Update is called once per frame
	void Update () {
        if (memoryAmt == memoryReq)
        {
            Debug.Log(memoryAmt);
            Debug.Log("All memory items collected, door is opened");
            memoryDoor.DoorAnim();
            memoryAmt++;
        }

        if (amtTalked == talkReq)
        {
            Debug.Log("Ghost has spawned");
            main.enabled = false;
            for (int i = 0; i<subs.Length; i++)
            {
                subs[i].SetActive(true);
            }
            Instantiate(ghosto, ghostSpawn.position, Quaternion.Euler(90, 0, 0));
            amtTalked++;
        }
	}
}
