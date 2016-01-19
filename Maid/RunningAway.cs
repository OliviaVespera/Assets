using UnityEngine;
using System.Collections;

public class RunningAway : MonoBehaviour {

	public Transform Hide;
	public Transform Ghost;
	public Transform Origin;
	public float speed;
	private Transform target = null;
	private bool GhostInSights;

	public void IfTriggered(){     // Function where the maid starts running after detecting the ghost 
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, Hide.position, step);
	}

	public void IfNotTriggered(){        // Function where the maid returns to origin position 
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, Origin.position, step);
	}

	void OnTriggerStay(Collider other){ 
		if (other.tag == "Ghost") { // If the ghost hits the collider
			GhostInSights = true; // makes the condition where the maid has seen the ghost to be true 
		} 
	}



	void OnTriggerExit(Collider other){ 
		if (other.tag == "Ghost")// If the ghost is no longer in the collider
			target = null;
		{
			StartCoroutine("Delay"); // Calls the delay function
		}
	}

	IEnumerator Delay(){
		yield return new WaitForSeconds (3);  // makes the maid wait for 3 seconds before resuming function
		GhostInSights = false;
	}

	void Update()
	{
		if(GhostInSights==true)
		{
			IfTriggered();
		}

		else
		{
			IfNotTriggered();
		}
	}
}

	