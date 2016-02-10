using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Check if the game is finished
/// </summary>
[RequireComponent(typeof(GameStateManager))]
public class GameFinishedController : MonoBehaviour {

    /// <summary>
    /// Game object to show the game is over
    /// </summary>
    public GameObject gameOverText;

    /// <summary>
    /// Game object that manages time left
    /// </summary>
    public TimeManager timeManager;

    /// <summary>
    /// How long to show the end game sequence, in seconds
    /// </summary>
    public float showGameOverDuration;

    /// <summary>
    /// The modified timescale of the game during th end game sequence
    /// </summary>
    public float gameOverTimeScale;

    /// <summary>
    /// Screen to load after the match
    /// </summary>
    public string afterMatchScene;

    public GameStateManager gameState;

	// Use this for initialization
	void Start () {
        gameState = gameObject.GetComponent<GameStateManager>();
	}
	
	// Update is called once per frame
	void Update () {

        //Do not update game state if determined or game over not available
        if (gameState.winningPlayerId != null || 
            gameOverText == null ||
            timeManager == null)
        {
            return;
        }

        //Check if one player is remaining
        var remainingPlayers = gameState.players.Where(p => p.lives > 0).ToList();
        if (remainingPlayers.Count == 1)
        {
            gameState.winningPlayerId = remainingPlayers.First().playerId;
            StartCoroutine(endMatch());
        }

        //Draw
        if (remainingPlayers.Count == 0)
        {
            StartCoroutine(endMatch());
        }
        
        //Check if game time ends
        if (timeManager.timeLeft <= 0)
        {
            //Remove time manager to avoid calling game over multiple times
            timeManager = null;

            var mostLives = gameState.players.Select(p => p.lives).Max();

            var playersWithMostLives = gameState.players.Where(p => p.lives == mostLives).ToList();

            //Set winner if we have only one
            if (playersWithMostLives.Count == 1)
            {
                gameState.winningPlayerId = playersWithMostLives.First().playerId;
            }

            StartCoroutine(endMatch());
        }
    }

    IEnumerator endMatch()
    {
        //Disable abilities
        
        gameOverText.SetActive(true);

        var originalTimeScale = Time.timeScale;
        Time.timeScale = gameOverTimeScale;

        //Hold execution for X seconds
        yield return new WaitForSeconds(showGameOverDuration);

        //Remove reference to avoid breaking things
        gameState.players = new List<PlayerController>();

        //Reset time scale
        Time.timeScale = originalTimeScale;

        Application.LoadLevel(afterMatchScene);
    }
}
