using UnityEngine;
using System.Collections;

public class Run : States {
	
	public Run(FSM efsm)
	{
		fsmClass = efsm;
	}
	
	public override void Enter()
	{
        fsmClass.anim.SetInteger("Action", 7);
        Debug.Log ("Entering run state");
	}
	
	public override void Execute()
	{
        Debug.Log("Running animation");
		runBack (); // run back to original position
        fsmClass.facing();
	}
	
	public override void Exit()
	{
		Debug.Log ("exiting run state");
	}

	void runBack()
	{
        fsmClass.agent.SetDestination(fsmClass.startPos); // set destination for guard to move towards starting position
        fsmClass.fDist = Vector3.Distance(fsmClass.transform.position, fsmClass.startPos); // find distance between guard position and target position
        if (fsmClass.fDist < 0.5f) // if close to start position
        {
            fsmClass.changeState(State._Crouch); // transition to crouch
        }
	}
}
