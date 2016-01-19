using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//public Ghost gh;
	public float moveSpeed = 10;
	int keysAvailable = 0;
    int tripItem = 0;
    int assistItem = 0;
    float fDist = 0;
    public Transform target;
    public GameObject tripObject;
    public GameObject assistObject;
    NavMeshAgent agent;
	Vector3 mousePos;
    public Animator anim;

	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

		//GameObject entrance = GameObject.FindGameObjectWithTag ("Entrance");
		//transform.position = entrance.transform.position;
	}
	// Update is called once per frame
	void Update () {
        transform.rotation = (Quaternion.Euler(270.0f, 180.0f, 0.0f));
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        mousePos = new Vector3(mousePos.x, 0.18f, mousePos.z);

        RaycastHit hit;
        Debug.DrawLine(transform.position, mousePos);
        if (Physics.Linecast(transform.position, mousePos, out hit))
        {
            fDist = Vector3.Distance(transform.position, mousePos);
            if (hit.collider.CompareTag("Door") && fDist < 2.5 && Input.GetMouseButtonUp(0))
            {
                Debug.Log("Hit!");
                GameObject newDoor = hit.transform.gameObject;
                Door newDoor2 = newDoor.GetComponent<Door>();
                newDoor2.DoorAction();
            }

            //else if (hit.collider.CompareTag("Furniture"))
            //{
            //    //examine furniture
            //}
        }

        else if (Input.GetMouseButtonUp(0))
		{
            //Debug.Log("Clicked");
            target.position = mousePos;
        }

        if (agent.velocity == Vector3.zero)
        {
            anim.SetBool("IsMoving", false);
        }
        
        else
        {
            anim.SetBool("IsMoving", true);
        }

        agent.SetDestination(target.position);
        facing();
    }

    public void SpawnObject(int itemType)
    {
        if (itemType == 1 && tripItem > 0)
        {
            tripItem--;
            Instantiate(tripObject, transform.position, Quaternion.Euler(90,0,0));
        }

        else if (itemType == 2 && assistItem > 0)
        {
            assistItem--;
            Instantiate(assistObject, transform.position, Quaternion.Euler(90, 0, 0));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TripItemI")) 
        {
            Destroy(other.gameObject);
            tripItem++;
            Debug.Log("Trip items available: " + tripItem);
        }

        else if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            keysAvailable++;
            Debug.Log("Keys available: " + keysAvailable);
        }

        else if (other.CompareTag("AssistItemI"))
        {
            Destroy(other.gameObject);
            assistItem++;
            Debug.Log("Assist item available: " + assistItem);
        }
    }

	public void editInventory(int itemType ,int amt)
	{
        if (itemType == 0)
        {
            keysAvailable += amt;
            Debug.Log("Keys available: " + keysAvailable);
        }

        else if (itemType == 1)
        {
            tripItem += amt;
            Debug.Log("Trip items available: " + tripItem);
        }

        else if (itemType == 2)
        {
            assistItem += amt;
            Debug.Log("Assist items available: " + assistItem);
        }
    }

	public int getInventory(int itemType)
	{
        if (itemType == 0)
        {
            Debug.Log("Keys available: " + keysAvailable);
            return keysAvailable;
        }

        else if (itemType == 1)
        {
            Debug.Log("Trip items available: " + tripItem);
            return tripItem;
        }

        else if (itemType == 2)
        {
            Debug.Log("Assist items available: " + assistItem);
            return assistItem;
        }

        return 0;
    }

    public void facing()
    {
        if (transform.position.z < target.position.z && // move backwards
            Square(transform.position.z - target.position.z) >
            Square(transform.position.x - target.position.x))
        {
            anim.SetInteger("Direction", 3);
        }

        else if (transform.position.z > target.position.z && // move forward
                 Square(transform.position.z - target.position.z) >
                 Square(transform.position.x - target.position.x))
        {
            anim.SetInteger("Direction", 0);
        }

        else if (transform.position.x > target.position.x && // move left
                 Square(transform.position.z - target.position.z) <
                 Square(transform.position.x - target.position.x))
        {
            anim.SetInteger("Direction", 2);
        }

        else if (transform.position.x < target.position.x && // move right
                 Square(transform.position.z - target.position.z) <
                 Square(transform.position.x - target.position.x))
        {
            anim.SetInteger("Direction", 1);
        }

    }

    public float Square(float val)
    {
        return val * val;
    }

}
