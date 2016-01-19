using UnityEngine;
using System.Collections;

public class Scared : States {

	public Scared (FSM efsm)
	{
		fsmClass = efsm;
	}
	
	public override void Enter()
	{
		Debug.Log ("Entering scared state");
        fsmClass.anim.SetInteger("Action", 6);
        fsmClass.detection.enabled = false; // deactivate detection collider so the guard cannot detect other things while scared
        fsmClass.agent.SetDestination(fsmClass.transform.position); // stop guard movement
    }
	
	public override void Execute()
	{
        Debug.Log("Play scared animation");
        fsmClass.look(State._Run); //transition to run
	}
	
	public override void Exit()
	{
        Debug.Log ("exiting scared state");
	}
}
