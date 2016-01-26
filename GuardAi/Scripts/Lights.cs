using UnityEngine;
using System.Collections;

public class Lights : MonoBehaviour {

	public GameObject gameLight;
	public float delay = 2.0f;
    public BoxCollider bax;

	// Use this for initialization
	void Start () {
        bax = transform.gameObject.GetComponent<BoxCollider>();
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
            bax.enabled = false;
			yield break;
		}

		else
		{
			yield return new WaitForSeconds(delay);
            Debug.Log("Exited");
			gameLight.SetActive(true);
            bax.enabled = true;
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
