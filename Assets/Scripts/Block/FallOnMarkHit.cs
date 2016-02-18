using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class FallOnMarkHit : MonoBehaviour {

	public string markAnimationTrigger;
	public float fallDelayDuration;
	
	private Rigidbody myRigidbody;
	private Animator animator;

	// Use this for initialization
	void Start () {
	
		myRigidbody = gameObject.GetComponent<Rigidbody> ();
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Check if mark collider enters
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter(Collider collider) {

		if (collider.GetComponent<MarkCollider>().enabled) {
			StartCoroutine(startFall());
		}
	}

	IEnumerator startFall() {

		animator.SetTrigger(markAnimationTrigger);
		yield return new WaitForSeconds(fallDelayDuration);
		myRigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
	}
}
