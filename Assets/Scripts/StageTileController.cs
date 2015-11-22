using UnityEngine;
using System.Collections;

public class stageTileController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
    void OnCollisionExit()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

}
