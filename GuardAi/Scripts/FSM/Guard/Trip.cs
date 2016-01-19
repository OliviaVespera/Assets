using UnityEngine;
using System.Collections;

public class Trip : States {
	
	public Trip (FSM efsm)
	{
		fsmClass = efsm;
	}
	
	public override void Enter()
	{
		Debug.Log ("Entering tripped state");
        Debug.Log("trip animation");
        fsmClass.detection.enabled = false;
        fsmClass.anim.SetInteger("Action", 5);
        fsmClass.agent.SetDestination(fsmClass.transform.position); // stop guard movement
    }
	
	public override void Execute()
	{
        if (fsmClass.getTime() > 2.5f) //trip animation last for 2.5 seconds
        {
            fsmClass.changeState(State._Recover); // transition to recover
        }
	}
	
	public override void Exit()
	{
		Debug.Log ("exiting tripped state");
	}
}
