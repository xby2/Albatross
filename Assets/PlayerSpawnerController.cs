using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSpawnerController : MonoBehaviour {

	public GameObject[] playerPrefabs;

	public static List<PlayerController> playerControllers;
	// Use this for initialization
	void Start () {
		playerControllers = new List<PlayerController>();
		var inputManager = InputManager.getCurrentInputManager();

		var prefabCount = playerPrefabs.Length;

		var x = 0;
		foreach(var key in inputManager.playerControls.Keys) {
			var playerPrefab = playerPrefabs[x % prefabCount];
			var player = Instantiate(playerPrefab, new Vector3(5.82f, 1.74f, 6.41f), Quaternion.identity) as GameObject;
			var playerController = player.GetComponent<PlayerController>();
			playerControllers.Add (playerController);
			playerController.playerId = key;
			x ++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
