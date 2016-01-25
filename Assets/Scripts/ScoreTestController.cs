using UnityEngine;
using System.Collections;

public class ScoreTestController : MonoBehaviour {



    public void onClick()
    {
        var players  = (PlayerController[])FindObjectsOfType<PlayerController>();

        foreach ( PlayerController p in players)
        {
            p.Die();
        }



        ScoreManager.score += 10;
    }
}
