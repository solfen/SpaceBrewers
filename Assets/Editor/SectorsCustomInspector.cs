using UnityEngine;
using System;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(SectorManager))]
public class SectorsCustomInspector : Editor {

    private SectorManager myTarget;
    private SerializedProperty scenarios;
    private SerializedProperty sectors;

    public override void OnInspectorGUI() {
        myTarget = (SectorManager)target;
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("scenariosUI"));

        scenarios = serializedObject.FindProperty("scenarios");
        scenarios.arraySize = myTarget.scenariosNb;

        EditorGUILayout.PropertyField(scenarios);
        if (!scenarios.isExpanded) {
            return;
        }

        if (myTarget.scenarios.Count != scenarios.arraySize) {
            return; // serialized property has not been updated
        }

        EditorGUI.indentLevel++;

        for (int i = 0; i < myTarget.scenarios.Count; i++) {
            sectors = scenarios.GetArrayElementAtIndex(i).FindPropertyRelative("AISectors");
            sectors.arraySize = myTarget.AIsectorsPerScenario;
            EditorGUILayout.PropertyField(sectors, true);
        }

        EditorGUI.indentLevel--;

        serializedObject.ApplyModifiedProperties();
    }
}
