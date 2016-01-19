using UnityEngine;
using System.Collections;

public class Crouch : States {
	
	public Crouch (FSM efsm)
	{
		fsmClass = efsm; // creating an instance of a class
    }
	
	public override void Enter()
	{
		Debug.Log ("Entering crouching state");
        fsmClass.anim.SetInteger("Action", 8);
        Debug.Log("Ghost still in vicinity");
	}
	
	public override void Execute()
	{
        Debug.Log("crouching animation");
		fsmClass.look (State._Crouch); // execute look function, to look around its surroundings
        Debug.Log(fsmClass.fTimePassed);
        if (fsmClass.getTime() > 7) // if 7 seconds of no detecting anyone nearby
        {
            Debug.Log("times up");
            fsmClass.anim.SetInteger("Action", 9);
            fsmClass.changeState(State._Recover); // transition to recovery state
        }
	}
	
	public override void Exit()
	{
		Debug.Log ("exiting crouching state");
    }
}
