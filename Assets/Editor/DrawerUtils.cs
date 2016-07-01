using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public static class DrawerUtils {
    public static GUILayoutOption labelWidth = GUILayout.Width(50f);
    public static GUILayoutOption bigLabelWidth = GUILayout.Width(65f);
    public static GUILayoutOption selectWidth = GUILayout.Width(150f);
    public static GUILayoutOption signSelectWidth = GUILayout.Width(100f);
    public static GUILayoutOption miniButtonWidth = GUILayout.Width(30f);

    public static void DrawConditionLine(FieldModificator influence, string[] fieldSelect, string[] signSelect, string label = null) {
        EditorGUILayout.BeginHorizontal();

        if (label != null) {
            EditorGUILayout.LabelField(label, GUIStyle.none, labelWidth);
        }

        int selectedIndex = influence.field != null && influence.field != "" ? System.Array.IndexOf(fieldSelect, influence.field) : 1;
        int popupIndex = EditorGUILayout.Popup("", selectedIndex, fieldSelect, EditorStyles.popup, selectWidth);
        influence.field = popupIndex >= 0 && popupIndex < fieldSelect.Length ? fieldSelect[popupIndex] : null;

        selectedIndex = influence.sign != null && influence.sign != "" ? System.Array.IndexOf(signSelect, influence.sign) : 0;

        influence.sign = signSelect[EditorGUILayout.Popup("", selectedIndex, signSelect, EditorStyles.popup, signSelectWidth)];

        influence.amount = EditorGUILayout.FloatField(influence.amount);

        EditorGUILayout.EndHorizontal();
    }

    public static void DrawConditionLine(RandomFieldModificator influence, string[] fieldSelect, string[] signSelect, string label = null) {
        EditorGUILayout.BeginHorizontal();

        if (label != null) {
            EditorGUILayout.LabelField(label, GUIStyle.none, labelWidth);
        }

        int selectedIndex = influence.field != null && influence.field != "" ? System.Array.IndexOf(fieldSelect, influence.field) : 1;
        influence.field = fieldSelect[EditorGUILayout.Popup("", selectedIndex, fieldSelect, EditorStyles.popup, selectWidth)];

        selectedIndex = influence.sign != null && influence.sign != "" ? System.Array.IndexOf(signSelect, influence.sign) : 0;

        influence.sign = signSelect[EditorGUILayout.Popup("", selectedIndex, signSelect, EditorStyles.popup, signSelectWidth)];

        influence.amount = EditorGUILayout.TextField(influence.amount);

        EditorGUILayout.EndHorizontal();
    }

    public static void AddAndRemoveButtons<T>(List<T> target) where T : new() {
        EditorGUILayout.BeginHorizontal("Box");
        if (GUILayout.Button("+", EditorStyles.miniButtonLeft, miniButtonWidth)) {
            target.Add(new T());
        }
        if (GUILayout.Button("-", EditorStyles.miniButtonRight, miniButtonWidth)) {
            target.RemoveAt(target.Count - 1);
        }
        EditorGUILayout.EndHorizontal();
    }

    public static string[] GetFieldsAsStrings<T>() {
        System.Reflection.FieldInfo[] fields = typeof(T).GetFields();
        string[] labels = new string[fields.Length];

        for (int i = 0; i < fields.Length; i++) {
            if (fields[i].Name != "instance") {
                labels[i] = fields[i].Name;
            }
        }

        return labels;
    }
}
