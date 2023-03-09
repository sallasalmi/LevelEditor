using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level))]
public class LevelEditorWindow : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("LevelEditor"))
        {
            LevelEditor.Open((Level)target);
        }

        DrawDefaultInspector();

    }

}
