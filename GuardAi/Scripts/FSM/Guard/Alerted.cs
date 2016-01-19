using UnityEngine;
using System.Collections;

public class Alerted : States {

    public Alerted (FSM efsm)
	{
		fsmClass = efsm; // creating an instance of a class
	}
	
	public override void Enter()
	{
        fsmClass.anim.SetInteger("Action", 1);
		Debug.Log ("Entering alerted state");
        fsmClass.agent.SetDestination(fsmClass.transform.position); //stop agent in position
    }
	
	public override void Execute()
	{
		fsmClass.look (State._Chasing); // execute look function, to look around its surroundings
        if (fsmClass.getTime() > 5) // if looked for more than 5 seconds
        {
            fsmClass.anim.SetInteger("Action", 0);
            fsmClass.changeState(State._Idle); // transition to the idle state
        }
	}
	
	public override void Exit()
	{
		Debug.Log ("Exiting alerted state");
    }
}
