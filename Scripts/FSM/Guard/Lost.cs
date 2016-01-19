using UnityEngine;
using System.Collections;

public class Lost : States {

	public Lost (FSM efsm)
	{
		fsmClass = efsm;
	}
	
	public override void Enter()
	{
		Debug.Log ("Entering lost state");
        Debug.Log("Lost animation");
        fsmClass.questionMark.SetActive(true);
        fsmClass.agent.SetDestination (fsmClass.transform.position); //stops agent from moving
	}
	
	public override void Execute()
	{
        fsmClass.look(State._Chasing); // execute look function to look around guard, if player is found within 5 seconds, enter Alert state
        if (fsmClass.getTime() > 5) //if lost for 5 seconds, enter idle state
        {
            fsmClass.anim.SetInteger("Action", 0);
            fsmClass.changeState(State._Idle);
        }
    }
	
	public override void Exit()
	{
        fsmClass.questionMark.SetActive(false);
        Debug.Log ("Exiting lost state");
	}
}
