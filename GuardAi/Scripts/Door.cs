using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Player pl;
    Animator anim;
    public NavMeshObstacle doorObstacle;
    public BoxCollider col;

	// Use this for initialization
	void Start () {
		GameObject playa = GameObject.FindGameObjectWithTag ("Player");
		pl = playa.GetComponent<Player>();
        anim = GetComponent<Animator>();
        doorObstacle = GetComponent<NavMeshObstacle>();
        col = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//void OnCollisionEnter(Collision other)
	//{
	//	if (other.gameObject.CompareTag("Player"))
	//	{
	//		if (pl.getInventory(0) > 0)
	//		{
	//			Debug.Log("Door opened");
	//			pl.editInventory(0,-1);
	//			Destroy(gameObject);
	//		}
	//		else
	//		{
	//			Debug.Log("Not enough keys");
    //          Debug.Log("Keys available: " + pl.getInventory(0));
	//		}
	//	}
	//}

    public void DoorAction()
    {
        //float fDist = Vector3.Distance(transform.position, pl.transform.position);
        if (anim.GetBool ("Open") == true)
        {
            doorObstacle.enabled = true;
            anim.SetBool("Open", false);
            col.enabled = true;
            Debug.Log("Door closed");
        }

        else if (anim.GetBool("Open") == false)
        {
            doorObstacle.enabled = false;
            anim.SetBool("Open", true);
            col.enabled = false;
            Debug.Log("Door Opened");
        }
    }
}
