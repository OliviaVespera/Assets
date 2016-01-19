using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	Rigidbody2D rbody;
	//public Ghost gh;
	public float moveSpeed = 5;
	int keysAvailable = 0;
	Vector2 mousePos;
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		//GameObject ghostScript = GameObject.FindGameObjectWithTag ("Ghost");
		//gh = ghostScript.GetComponent<Ghost>
		GameObject entrance = GameObject.FindGameObjectWithTag ("Entrance");
		rbody.position = entrance.transform.position;
	}
	// Update is called once per frame
	void Update () {
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//Debug.Log (mousePos);
		if (Input.GetMouseButton(0))
		{
			playerMove();
		}
	}
	
	void playerMove()
	{
		rbody.position = Vector2.MoveTowards (rbody.position, mousePos, Time.deltaTime*moveSpeed); 
	}
	
	public void editKey(int amt)
	{
		keysAvailable+=amt;
		Debug.Log("Keys available: " + keysAvailable);
	}
	
	public int getKeys()
	{
		return keysAvailable;
	}
}
