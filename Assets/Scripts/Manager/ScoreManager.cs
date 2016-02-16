using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {
    PlayerController[] playerControllers;
    Dictionary<int, List<Image>> playerIcons;
    Text counterText;


    // Use this for initialization
    void Start() {
		if (PlayerSpawnerController.playerControllers == null) return;
        playerIcons = new Dictionary<int, List<Image>>();
		counterText = GetComponent<Text>();
		playerControllers = PlayerSpawnerController.playerControllers.ToArray();
		// Get all player instances
        //this.playerControllers = (PlayerController[])FindObjectsOfType<PlayerController>();
		var x = 0f;
        foreach (var p in playerControllers)
        {
            var playerID = p.GetInstanceID();
            
            for (var i = 0; i < p.lives; i++)
            {
                var icon = GameObject.Instantiate(p.icon, new Vector3(0, 0, 0), Quaternion.identity) as Image;
                 icon.transform.SetParent(gameObject.transform);
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



    // Update is called once per frame
    void Update() {
		if (playerControllers == null) Start ();
        foreach (var p in playerControllers)
        {
            var i = 0;
			if (!playerIcons.ContainsKey(p.GetInstanceID())) continue;
            foreach (Image icon in playerIcons[p.GetInstanceID()]) {

               icon.enabled = (i < p.lives);
               i++;
            }



        }
    }
}
