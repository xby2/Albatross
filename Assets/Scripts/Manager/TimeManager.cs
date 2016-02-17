using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class TimeManager : MonoBehaviour {

    /// <summary>
    /// Time left in the match in seconds
    /// </summary>
	public float timeLeft;

	private Text timeText;
	
    // Use this for initialization
	void Start () {
		timeText = GetComponent<Text>();
		timeLeft = 100f;
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( timeLeft < 0 ) { 
			timeText.text = "Game Over";
			return;
		}
		timeText.text = timeLeft.ToString("F0");
		timeLeft -= Time.deltaTime;
	}
}
