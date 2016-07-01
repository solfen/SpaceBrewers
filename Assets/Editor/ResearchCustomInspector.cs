using UnityEngine;
using System;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(ResearchManager))]
public class ResearchCustomInspector : Editor {
    private string[] ressourcesFieldsLabels;
    private string[] mercenariesFieldsLabels;
    private string[] objectsLabels;
    private string[] conditionSignLabels = new string[3] { ">", "<", "=" };
    private string[] rewardSignLabels = new string[1] { "+" };

    private ResearchManager myTarget;

    public override void OnInspectorGUI() {
        myTarget = (ResearchManager)target;

        if (ressourcesFieldsLabels == null) {
            ressourcesFieldsLabels = DrawerUtils.GetFieldsAsStrings<RessourcesManager>();
        }
        if (mercenariesFieldsLabels == null) {
            mercenariesFieldsLabels = DrawerUtils.GetFieldsAsStrings<MercenaryTeam>();
        }
        if (objectsLabels == null) {            
            List<string> objectsLabelsList = new List<string>();

            for (int i = 0; i < GameData.instance.buildingsCategories.Count; i++) {
                for(int j=0; j< GameData.instance.buildingsCategories[i].buildings.Count; j++) {
                    if(!GameData.instance.buildingsCategories[i].buildings[j].isUnlocked) {
                        objectsLabelsList.Add(GameData.instance.buildingsCategories[i].buildings[j].name);
                    }
                }
            }

            objectsLabels = objectsLabelsList.ToArray();
        }

        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("precentUpdateInterval"));
        ShowList(myTarget, serializedObject.FindProperty("researches"));
        serializedObject.ApplyModifiedProperties();
    }

    private void ShowList(ResearchManager target, SerializedProperty list) {
        
        EditorGUILayout.PropertyField(list);
        if (!list.isExpanded) {
            return;
        }

        EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
        if (target.researches.Count != list.arraySize) {
            return; // serialized property has not been updated
        }

        for (int i = 0; i < target.researches.Count; i++) {
            var elem = list.GetArrayElementAtIndex(i);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(elem);
            if (!elem.isExpanded) {
                EditorGUI.indentLevel--;
                continue;
            }

            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("name"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("type"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("icon"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("baseDuration"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("baseCost"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("nbOfAugments"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("costMultiplierEachTime"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("description"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("summary"));

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasRessourcesSpawnCondition"));
            if (target.researches[i].hasRessourcesSpawnCondition) {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.researches[i].ressourcesSpawnConditions.Count; j++) {
                    DrawerUtils.DrawConditionLine(target.researches[i].ressourcesSpawnConditions[j], ressourcesFieldsLabels, conditionSignLabels);
                }

                DrawerUtils.AddAndRemoveButtons<FieldModificator>(target.researches[i].ressourcesSpawnConditions);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasRessourceRewards"));
            if (target.researches[i].hasRessourceRewards) {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.researches[i].ressourcesRewards.Count; j++) {
                    DrawerUtils.DrawConditionLine(target.researches[i].ressourcesRewards[j], ressourcesFieldsLabels, rewardSignLabels);
                }

                DrawerUtils.AddAndRemoveButtons<RandomFieldModificator>(target.researches[i].ressourcesRewards);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasObjectRewards"));
            if (target.researches[i].hasObjectRewards) {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.researches[i].objectRewards.Count; j++) {
                    if (target.researches[i].objectRewards[j].objectName != null && System.Array.IndexOf(objectsLabels, target.researches[i].objectRewards[j].objectName) == -1) {
                        target.researches[i].objectRewards.RemoveAt(j);
                        j--;
                        continue;
                    }

                    EditorGUILayout.BeginHorizontal();

                    EditorGUILayout.LabelField("Unlock Object:", GUIStyle.none, DrawerUtils.signSelectWidth);

                    int selectedIndex = target.researches[i].objectRewards[j].objectName != null && target.researches[i].objectRewards[j].objectName != "" ? System.Array.IndexOf(objectsLabels, target.researches[i].objectRewards[j].objectName) : 0;
                    target.researches[i].objectRewards[j].objectName = objectsLabels[EditorGUILayout.Popup("", selectedIndex, objectsLabels, EditorStyles.popup, DrawerUtils.selectWidth)];

                    EditorGUILayout.EndHorizontal();
                }

                DrawerUtils.AddAndRemoveButtons<ObjectReward>(target.researches[i].objectRewards);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasMercenariesRewards"));
            if (target.researches[i].hasMercenariesRewards) {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.researches[i].mercenariesRewards.Count; j++) {
                    DrawerUtils.DrawConditionLine(target.researches[i].mercenariesRewards[j], mercenariesFieldsLabels, rewardSignLabels);
                }

                DrawerUtils.AddAndRemoveButtons<RandomFieldModificator>(target.researches[i].mercenariesRewards);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }

            EditorGUI.indentLevel--;
        }


    }
}
