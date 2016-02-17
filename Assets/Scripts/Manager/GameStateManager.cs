using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Holds all public data for a trail used in the match
/// </summary>
[RequireComponent(typeof(PersistUntilReplaced))]
public class GameStateManager : MonoBehaviour {

    /// <summary>
    /// Reference to all the players in the game
    /// </summary>
    public List<PlayerController> players;
    
    public int? winningPlayerId;

    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    /// <summary>
    /// Returns the opponents for the given player
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public List<PlayerController> getOpponents(PlayerController player)
    {
        return players.Where(p => p != player)
            .ToList();
    }
}
