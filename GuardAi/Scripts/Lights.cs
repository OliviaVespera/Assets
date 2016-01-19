using UnityEngine;
using System.Collections;

public class Lights : MonoBehaviour {

	public GameObject gameLight;
	public float delay = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator lightOnOff(int n)
	{
		if (n == 0)
		{
			yield return new WaitForSeconds(delay);
			Debug.Log("Entered");
			gameLight.SetActive(false);
			yield break;
		}

		else
		{
			yield return new WaitForSeconds(delay);
			gameLight.SetActive(true);
			yield break;
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			StartCoroutine(lightOnOff(0));
		}
	}

	void OnTriggerExit(Collider other)
	{
		StartCoroutine(lightOnOff(1));
	}
}
