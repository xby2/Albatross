using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

    public GameObject cube;


	// Use this for initialization
	void Start () {
        for (var i = 0; i < 10; i++) {
            for (var j = 0; j < 10; j++) {
                var tile = Instantiate(cube, new Vector3(i * 1.1f, 0, j * 1.1f), new Quaternion());
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
