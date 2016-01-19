using UnityEngine;
using System.Collections;

public class States : FSM {

	public FSM fsmClass = null;
	public States state = null;


	public virtual void Enter()
	{}

	public virtual void Execute()
	{}

	public virtual void Exit()
	{}
}
