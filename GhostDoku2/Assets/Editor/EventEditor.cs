using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IntGameEvent))]
public class EventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        IntGameEvent myGameEvent = (IntGameEvent)target;

        if(GUILayout.Button("Raise Event"))
        {
            myGameEvent.Raise(0);
        }
    }
}

