using UnityEngine;
using System.Collections;

public class Recover : States {
	
	public Recover (FSM efsm)
	{
		fsmClass = efsm;
	}
	
	public override void Enter()
	{
		Debug.Log ("Entering recover state");
        Debug.Log("playing recovery animation");
        fsmClass.detection.enabled = true; // re enable vision collider so that the guard can notice its surroundings again
    }
	
	public override void Execute()
	{
        if (fsmClass.getTime() > 2.5) // recovery animation lasts 2.5 seconds
        {
            fsmClass.changeState(State._Lost); //transition to lost state
        }
	}
	
	public override void Exit()
	{
		Debug.Log ("exiting recover state");
	}
}
