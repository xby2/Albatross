using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSpawnerController : MonoBehaviour {

	public GameObject[] players;

	public static List<PlayerController> playerControllers;
	// Use this for initialization
	void Start () {
		playerControllers = new List<PlayerController>();
		var inputManager = InputManager.getCurrentInputManager();

		var playerCount = players.Length;

		var x = 0;
		foreach(var key in inputManager.playerControls.Keys) {
			var player = players[x % playerCount];
			var playerController = player.GetComponent<PlayerController>();
			playerControllers.Add (playerController);
            playerController.Respawn();
			x ++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
