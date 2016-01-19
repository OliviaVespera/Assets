using UnityEngine;
using System.Collections;

public class AerithSprite : MonoBehaviour {
	public Transform target;
	public float mOffset;

	private Animator mAnimator;
	public NavMeshAgent mAgent;
	// Use this for initialization
	void Start () {
		mAnimator = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (mAgent.velocity.x == 0.0f) {
			mAnimator.SetInteger ("Direction", 0);
		} else if (mAgent.velocity.z > 0.5f) {
			mAnimator.SetInteger ("Direction", 1);
		} else if (mAgent.velocity.z < -0.5f) {
			mAnimator.SetInteger ("Direction", 3);
		} else if (mAgent.velocity.x > 0.5f) {
			mAnimator.SetInteger ("Direction", 4);
		} else if (mAgent.velocity.x < -0.5f) {
			mAnimator.SetInteger ("Direction", 2);
		}
	
	}
	void LateUpdate(){
		transform.localPosition = new Vector3 (target.localPosition.x, transform.localPosition.y, target.localPosition.z + mOffset);
	}
}
