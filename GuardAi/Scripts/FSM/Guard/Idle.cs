using UnityEngine;
using System.Collections;

public class Idle : States {

    public Idle (FSM efsm)
	{
		fsmClass = efsm;
	}

	public override void Enter()
	{
        fsmClass.detection.enabled = true;
        Debug.Log ("Entering idle state");
    }

	public override void Execute()
	{
        fsmClass.target = fsmClass.wayPoints[fsmClass.wayPtIndex]; // changing targets by traversing through the array of way points
        fsmClass.fDist = Vector3.Distance(fsmClass.transform.position, fsmClass.target.position); //find distance between guard and the target
        if (fsmClass.fDist > fsmClass.fRadius) // if guard is far from the target, continue moving
        {
            //Debug.Log("moving animation");
            fsmClass.agent.SetDestination(fsmClass.target.position);
        }
        else // if guard is near to the target, change target
        {
            //Debug.Log("change target");
            if (fsmClass.wayPtIndex < fsmClass.wayPoints.Length-1) // incrementing the index to traverse
            {
                fsmClass.wayPtIndex++;
            }

            else
            {
                fsmClass.wayPtIndex = 0; // reset index when it reaches max
            }
        }

        if (fsmClass.getTime() > 25.0f) // if idled for 10 seconds
        {
            fsmClass.anim.SetInteger("Action", 2);
            fsmClass.changeState(State._Distracted); //transition to distracted
        }

        fsmClass.facing();
	}

	public override void Exit()
	{
		Debug.Log ("Leaving idle state");
    } 
}
