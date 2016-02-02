using UnityEngine;
using System.Collections;

public class TestMovement : MonoBehaviour {
	public float ghostSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(Time.deltaTime * ghostSpeed * Input.GetAxis ("Horizontal"), 0,
		                                       Time.deltaTime * ghostSpeed * Input.GetAxis("Vertical"));
	
	}
}
