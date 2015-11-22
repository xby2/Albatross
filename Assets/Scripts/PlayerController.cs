using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    private float speed;
	// Use this for initialization
	void Start () {
        speed = 0.5f;
	
	}
	
	// Update is called once per frame
	void Update () {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        transform.position += new Vector3(h * speed , 0, v * speed);

    }
}
