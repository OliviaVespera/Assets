using UnityEngine;
using System.Collections;

public class MaidAI : MonoBehaviour
{
	public Transform target;
	public float speed = 10.0f;
	public Rigidbody rb;
		
	enum MaidStates //This displays all the states of MaidStates
	{
		Idle,
		Walk,
		Clean,
		Interact,
		Scared,
		Run,
		Recover
	}

	MaidStates CurrentState; //this will store the current state

	// Use this for initialization
	void Start ()
	{
		CurrentState = MaidStates.Idle;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (CurrentState) {
		case MaidStates.Idle:
			Idle ();
			break;
		case MaidStates.Interact:
			Interact ();
			break;
		case MaidStates.Walk:
			Walk ();
			float step = speed * Time.deltaTime; 
			transform.position = Vector3.MoveTowards(transform.position, target.position, step);
			break;
		case MaidStates.Clean:
			Clean ();
			break;
		case MaidStates.Scared:
			Scared ();
			break;
		case MaidStates.Run:
			Run ();
			break;
		case MaidStates.Recover:
			Recover ();
			break;
		default:
			Debug.Log ("There is an error");
			CurrentState = MaidStates.Idle;
			break;
		}
	}

	void Idle ()
	{
		//GameObject.Find ("Maid").animation.Play ("Idle"); //The code will be used to play the idle animation.
		if (GameObject.FindGameObjectWithTag ("Player").transform.position == GameObject.FindGameObjectWithTag("Maid").transform.position) //if the player walks towards the maid	 
			CurrentState = MaidStates.Interact; //the idle state will transit to the interact state
		else if (GameObject.FindGameObjectWithTag("Ghost").transform.position == GameObject.FindGameObjectWithTag("Maid").transform.position) //if the ghost is in the same area as the maid location
			CurrentState = MaidStates.Scared; // the idle state will transit to the scared state
		else //if none of the above transition conditions occur
			CurrentState = MaidStates.Walk; //the idle state will transit to the walk state
	}

	void Interact ()
	{
		Debug.Log ("I will give you some tips to find the xxx item");
		CurrentState = MaidStates.Idle; //idle state transits back to idle state
	}

	void Walk ()
	{
		//GameObject.Find("Maid").animation.Play("Walk"); //The code will be used to play the walk animation.
		float step = speed * Time.deltaTime; // set the walk speed
		CurrentState = MaidStates.Clean; //walk state transitions to the clean state
	}

	void Clean ()
	{
		//GameObject.Find("Maid")animation.Play("Clean"); //plays the clean animation.
		CurrentState = MaidStates.Idle; //clean state transitions back to idle state
	}

	void Scared ()
	{
		//GameObject.Find("Maid")animation.Play("Scared"); //plays the scared animation
		CurrentState = MaidStates.Run; //scared state transitions into run state
	}

	void Run ()
	{
		//GameObject.Find("Maid")animation.Play("Run"); //plays the running animation
		float step = (speed + 5.0f) * Time.deltaTime; //setting up the run speed
		CurrentState = MaidStates.Recover; //run state transitions to recover state
	}

	void Recover ()
	{
		//GameObject.Find("Maid")animation.Play("Recover"); //plays the recover animation
		CurrentState = MaidStates.Idle; //recover state transitions back to idle state
	}
}
