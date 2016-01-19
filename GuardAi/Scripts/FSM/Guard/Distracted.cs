using UnityEngine;
using System.Collections;

public class Distracted : States {

	public Distracted (FSM efsm)
	{
		fsmClass = efsm; // creating an instance of a class
    }

	public override void Enter()
	{
		Debug.Log ("Entering distracted state");
        Debug.Log("Playing distracted animation");
        fsmClass.detection.enabled = false;
        fsmClass.agent.SetDestination(fsmClass.transform.position); // stops agent from moving
    }
	
	public override void Execute()
	{
        //if distracted for 10 seconds, go back to idle
		if (fsmClass.getTime() > 10) // idles for 10 seconds
		{
            fsmClass.anim.SetInteger("Action", 3);
            fsmClass.changeState(State._Idle); // change back to idle state
		}
	}
	
	public override void Exit()
	{
		Debug.Log ("exiting distracted state");
    }
}
