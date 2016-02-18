using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class ActivateMark : MonoBehaviour {
	
	public MarkCollider markCollider;
	public float actionDuration;

	private PlayerController playerController;
	private InputManager inputManager;

	// Use this for initialization
	void Start () {
		playerController = gameObject.GetComponent<PlayerController> ();
		inputManager = InputManager.getCurrentInputManager();
	}
	
	// Update is called once per frame
	void Update () {
	    
		if (inputManager.playerControls [playerController.playerId].getActionPressDown()) {

			StartCoroutine(startAttack());
		}
	}

	IEnumerator startAttack() {
		markCollider.enabled = true;
		yield return new WaitForSeconds(actionDuration);
		markCollider.enabled = false;
	}
}
