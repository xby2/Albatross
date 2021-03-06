﻿using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
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
#endif

