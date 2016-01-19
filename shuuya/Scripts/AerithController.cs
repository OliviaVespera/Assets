using UnityEngine;
using System.Collections;

public class AerithController : MonoBehaviour {
	private NavMeshAgent agent;
	public Transform target;
	public float speed=0.5f;
	public float theOffset=0.0f;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		target= GameObject.FindWithTag ("Player").transform;
		agent.transform.position = new Vector3 (target.position.x+theOffset, agent.transform.position.y, target.position.z+theOffset);
	
	}
}
