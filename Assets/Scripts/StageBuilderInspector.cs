using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(StageController))]
public class StageBuilderInspector : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var stageBuilderScript = target as StageController;

        if (GUILayout.Button("Build Stage")) {
            stageBuilderScript.BuildStage();
        }

    }
}
