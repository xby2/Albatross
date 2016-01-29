using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageController : MonoBehaviour {


    // Container to store all stage tiles/walls
    public GameObject stageContainer;
    public GameObject stageTilePrefab;
    public GameObject stageWallPrefab;

    public List<GameObject> stageObjects;

    public int size;
 
	// Use this for initialization
	void Start () {
    }
	
    public void BuildStage()
    {
        if (stageObjects == null) stageObjects = new List<GameObject>();
        stageObjects.ForEach(t => DestroyImmediate(t));
        stageObjects.Clear();

        // Build Tiles
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                stageObjects.Add(Instantiate(stageTilePrefab, new Vector3(i * 1.1f, 0, j * 1.1f), new Quaternion()) as GameObject);
            }
        }



        // Build Walls
        var wallSize = size * 1.1f;
        var end = (wallSize * 1.1f / 2) - 0.5f;
        var w = Instantiate(stageWallPrefab, new Vector3(end -0.4f, 0, -0.6f), new Quaternion()) as GameObject;
        stageObjects.Add(w);
        w.transform.Rotate(0, 0, 0, Space.Self);
        w.transform.localScale = new Vector3(wallSize*2, 5f, 0.1f);
        var v = Instantiate(stageWallPrefab, new Vector3(end -0.4f, 0, wallSize - 0.4f), new Quaternion()) as GameObject;
        stageObjects.Add(v);
        v.transform.Rotate(0, 0, 0, Space.Self);
        v.transform.localScale = new Vector3(wallSize * 2, 5f, 0.1f);
        var x = Instantiate(stageWallPrefab, new Vector3(-0.4f, 0, end ), new Quaternion()) as GameObject;
		stageObjects.Add(x);
        x.transform.Rotate(0, 90, 0, Space.Self);
        x.transform.localScale = new Vector3(wallSize * 2, 5f, 0.1f);
		x.transform.position += new Vector3(-0.4f, 0, 0.4f);
		Debug.Log ("End " + end);
		Debug.Log ("Z " + (end + 0.3f));

		var z = Instantiate(stageWallPrefab, new Vector3(wallSize - 0.4f, 0, end), new Quaternion()) as GameObject;
        stageObjects.Add(z);
        z.transform.Rotate(0, 90, 0, Space.Self);
        z.transform.localScale = new Vector3(wallSize * 2, 5f, 0.1f);


        foreach (var so in stageObjects)
        {
            so.transform.parent = stageContainer.transform;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
