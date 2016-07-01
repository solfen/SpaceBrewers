/*using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(SailorManager))]
public class SailorManagerCustomInspector : Editor {
    private SailorManager myTarget;

    public override void OnInspectorGUI() {

        myTarget = (SailorManager)target;

        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("sailorsList"), true);
        ShowSailorConfig(serializedObject.FindProperty("sailorsConfig"));

        serializedObject.ApplyModifiedProperties();

    }

    private void ShowSailorConfig(SerializedProperty sailorsConfig) {
        EditorGUILayout.PropertyField(sailorsConfig);
        if (!sailorsConfig.isExpanded) {
            return;
        }
        EditorGUI.indentLevel++;
        EditorGUILayout.PropertyField(sailorsConfig.FindPropertyRelative("barRefilingStations"), true);
        EditorGUILayout.PropertyField(sailorsConfig.FindPropertyRelative("barWanderPoints"), true);
        EditorGUILayout.PropertyField(sailorsConfig.FindPropertyRelative("eventCheckerInterval"));
        
        EditorGUI.indentLevel--;
        
        EditorGUILayout.field
        var arr = System.Enum.GetValues(typeof(order_type));
        foreach (order_type type in arr) {

        }
    }
}*/
