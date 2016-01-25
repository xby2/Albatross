using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {
    public static int score;

    PlayerController[] playerControllers;
    Dictionary<int, List<Image>> playerIcons;
    Text text;

    // Use this for initialization
    void Start() {
        playerIcons = new Dictionary<int, List<Image>>();
        text = GetComponent<Text>();
        score = 0;
        this.playerControllers = (PlayerController[])FindObjectsOfType<PlayerController>();
        foreach (var p in playerControllers)
        {
            var playerID = p.GetInstanceID();
            var x = 0f;
            for (var i = 0; i < p.lives; i++)
            {
                var icon = GameObject.Instantiate(p.icon, new Vector3(0, 0, 0), Quaternion.identity) as Image;
                icon.transform.parent = gameObject.transform;
                icon.transform.localPosition = new Vector3(x, 0, 0);
                x += ((float)icon.rectTransform.sizeDelta.x + 10);
                if (!playerIcons.ContainsKey(playerID))
                {
                    playerIcons.Add(playerID, new List<Image>());
                }

                playerIcons[playerID].Add(icon);
            }
        }
    }


    public void PlayerDie(int instanceID) { }



    // Update is called once per frame
    void Update() {
        foreach (var p in playerControllers)
        {
            var i = 0;
            foreach (Image icon in playerIcons[p.GetInstanceID()]) {

               icon.enabled = (i < p.lives);
               i++;
            }



        }
    }
}
