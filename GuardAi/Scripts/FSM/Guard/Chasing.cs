using UnityEngine;
using System.Collections;

public class Chasing : States {
	
	public Chasing (FSM efsm)
	{
		fsmClass = efsm;
	}
	
	public override void Enter()
	{
		Debug.Log ("Entering chase state");
	}
	
	public override void Execute()
	{
        fsmClass.agent.SetDestination(fsmClass.target.position); // using navmesh to set the player's location as its destination
        fsmClass.anim.SetInteger("Action", 0);
        inSights (); // check if player is still in sights
        fsmClass.facing();
    }
	
	public override void Exit()
	{
		Debug.Log ("exiting chase state");
	}

	void inSights()
	{
        RaycastHit hit;
        Vector3 lookDirection;
        lookDirection = fsmClass.target.transform.position - fsmClass.transform.position; // calculate direction at which the guard is looking at
        fsmClass.fDist = Vector3.Distance(fsmClass.transform.position, fsmClass.target.position); // obtain distance between player and guard ai
        Debug.DrawRay(fsmClass.vision.transform.position, lookDirection); //draw ray to test if the guard is looking at the right direction

        if (Physics.Raycast(fsmClass.vision.transform.position, lookDirection, out hit, 50)) // if raycast hits somethings
        {
            if (hit.collider.CompareTag("Wall") && fsmClass.fDist > 6) // if player is too far away and sight hits a wall
            {
                Debug.Log("Player lost");
                fsmClass.anim.SetInteger("Action", 4);
                fsmClass.changeState(State._Lost); // change states when player cannot be seen
            }
        }
    }
}
