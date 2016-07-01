using UnityEngine;
using System;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(MissionsManager))]
public class MissionsCustomInspector : Editor {
    private string[] ressourcesFieldsLabels;
    private string[] sectorFieldsLabels;
    private string[] familyFieldsLabels;
    private string[] conditionSignLabels = new string[3] { ">", "<", "=" };
    private string[] rewardSignLabels = new string[1] { "+" };
    private MissionsManager myTarget;

    public override void OnInspectorGUI() {
        myTarget = (MissionsManager)target;
        if (ressourcesFieldsLabels == null) {
            ressourcesFieldsLabels = DrawerUtils.GetFieldsAsStrings<RessourcesManager>();
        }

        if (sectorFieldsLabels == null) {
            sectorFieldsLabels = DrawerUtils.GetFieldsAsStrings<Sector>();
        }

        if (familyFieldsLabels == null) {
            familyFieldsLabels = DrawerUtils.GetFieldsAsStrings<Family>();
        }

        serializedObject.Update();
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("sectorHostilityCoef"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("sectorDistanceCoef"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("sectorReputationCoef"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mercenaryDefenseCoef"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mercenaryNegociationCoef"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mercenarySneakCoef"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mindManipulationCoef"));

        ShowList(myTarget, serializedObject.FindProperty("missions"));
        serializedObject.ApplyModifiedProperties();
    }

    private void ShowList(MissionsManager target, SerializedProperty list) {

        EditorGUILayout.PropertyField(list);
        if (!list.isExpanded) {
            return;
        }

        EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
        if (target.missions.Count != list.arraySize) {
            return; // serialized property has not been updated
        }

        for (int i = 0; i < target.missions.Count; i++) {
            var elem = list.GetArrayElementAtIndex(i);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(elem);
            if (!elem.isExpanded) {
                EditorGUI.indentLevel--;
                continue;
            }

            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("name"), false);
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("type"), false);
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("icon"), false);
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("beerCost"), false);
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("moneyCost"), false);
            target.missions[i].successProbabilityFactor = EditorGUILayout.FloatField("Success factor", target.missions[i].successProbabilityFactor);
            target.missions[i].durationFactor = EditorGUILayout.FloatField("Duration factor", target.missions[i].durationFactor);

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasRessourcesSpawnCondition"));
            if (target.missions[i].hasRessourcesSpawnCondition) {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.missions[i].ressourcesSpawnConditions.Count; j++) {
                    DrawerUtils.DrawConditionLine(target.missions[i].ressourcesSpawnConditions[j], ressourcesFieldsLabels, conditionSignLabels);
                }

                DrawerUtils.AddAndRemoveButtons<FieldModificator>(target.missions[i].ressourcesSpawnConditions);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }


            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasSectorSpawnCondtions"));
            if (target.missions[i].hasSectorSpawnCondtions) {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.missions[i].sectorSpawnCondtions.Count; j++) {
                    DrawerUtils.DrawConditionLine(target.missions[i].sectorSpawnCondtions[j], sectorFieldsLabels, conditionSignLabels);
                }

                DrawerUtils.AddAndRemoveButtons<FieldModificator>(target.missions[i].sectorSpawnCondtions);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }
            
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasFamilySpawnCondtions"));
            if (target.missions[i].hasFamilySpawnCondtions) {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.missions[i].familySpawnConditions.Count; j++) {
                    DrawerUtils.DrawConditionLine(target.missions[i].familySpawnConditions[j], familyFieldsLabels, conditionSignLabels);
                }

                DrawerUtils.AddAndRemoveButtons<FieldModificator>(target.missions[i].familySpawnConditions);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }


            EditorGUI.indentLevel++;
            EditorGUILayout.BeginVertical("Box");

            for (int j = 0; j < target.missions[i].descriptions.Count; j++) {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Description", GUIStyle.none, DrawerUtils.bigLabelWidth);
                target.missions[i].descriptions[j].text = EditorGUILayout.TextField(target.missions[i].descriptions[j].text);
                EditorGUILayout.EndHorizontal();
            }

            DrawerUtils.AddAndRemoveButtons<MissionDescription>(target.missions[i].descriptions);
            EditorGUILayout.EndVertical();

            EditorGUI.indentLevel--;
            EditorGUILayout.Separator();

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasRessourcesReward"));
            if (target.missions[i].hasRessourcesReward) {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("isRessourcesRewardConditional"));
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.missions[i].ressourceRewards.Count; j++) {
                    if (target.missions[i].isRessourcesRewardConditional) {
                        DrawerUtils.DrawConditionLine(target.missions[i].ressourceRewards[j].condition, sectorFieldsLabels, conditionSignLabels, "if");
                    }
                    DrawerUtils.DrawConditionLine(target.missions[i].ressourceRewards[j].reward, ressourcesFieldsLabels, rewardSignLabels, "reward");
                }

                DrawerUtils.AddAndRemoveButtons<Reward>(target.missions[i].ressourceRewards);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasSectorConsequencies"));
            if (target.missions[i].hasSectorConsequencies) {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("isSectorConsequenciesConditional"));
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.missions[i].sectorConsequencies.Count; j++) {
                    if (target.missions[i].isSectorConsequenciesConditional) {
                        DrawerUtils.DrawConditionLine(target.missions[i].sectorConsequencies[j].condition, sectorFieldsLabels, conditionSignLabels, "if");
                    }
                    DrawerUtils.DrawConditionLine(target.missions[i].sectorConsequencies[j].consequency, sectorFieldsLabels, rewardSignLabels, "reward");
                }

                DrawerUtils.AddAndRemoveButtons<SectorConsequency>(target.missions[i].sectorConsequencies);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasSectorFailureConsequencies"));
            if (target.missions[i].hasSectorFailureConsequencies) {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("isSectorFailureConsequenciesConditional"));
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.missions[i].sectorFailureConsequencies.Count; j++) {
                    if (target.missions[i].isSectorFailureConsequenciesConditional) {
                        DrawerUtils.DrawConditionLine(target.missions[i].sectorFailureConsequencies[j].condition, sectorFieldsLabels, conditionSignLabels, "if");
                    }
                    DrawerUtils.DrawConditionLine(target.missions[i].sectorFailureConsequencies[j].consequency, sectorFieldsLabels, rewardSignLabels, "reward");
                }

                DrawerUtils.AddAndRemoveButtons<SectorConsequency>(target.missions[i].sectorFailureConsequencies);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasFamilyConsequencies"));
            if (target.missions[i].hasFamilyConsequencies) {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("isFamilyConsequenciesConditional"));
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.missions[i].familyConsequencies.Count; j++) {
                    if (target.missions[i].isFamilyConsequenciesConditional) {
                        DrawerUtils.DrawConditionLine(target.missions[i].familyConsequencies[j].condition, familyFieldsLabels, conditionSignLabels, "if");
                    }
                    DrawerUtils.DrawConditionLine(target.missions[i].familyConsequencies[j].consequency, familyFieldsLabels, rewardSignLabels, "reward");
                }

                DrawerUtils.AddAndRemoveButtons<SectorConsequency>(target.missions[i].familyConsequencies);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasFamilyFailureConsequencies"));
            if (target.missions[i].hasFamilyFailureConsequencies) {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("isFamilyFailureConsequenciesConditional"));
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.missions[i].familyFailureConsequencies.Count; j++) {
                    if (target.missions[i].isFamilyFailureConsequenciesConditional) {
                        DrawerUtils.DrawConditionLine(target.missions[i].familyFailureConsequencies[j].condition, familyFieldsLabels, conditionSignLabels, "if");
                    }
                    DrawerUtils.DrawConditionLine(target.missions[i].familyFailureConsequencies[j].consequency, familyFieldsLabels, rewardSignLabels, "reward");
                }

                DrawerUtils.AddAndRemoveButtons<SectorConsequency>(target.missions[i].familyFailureConsequencies);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasSailorsConsequencies"));
            if (target.missions[i].hasSailorsConsequencies) {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("isSailorsConsequenciesConditional"));
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.missions[i].sailorConsequencies.Count; j++) {
                    if (target.missions[i].isSailorsConsequenciesConditional) {
                        DrawerUtils.DrawConditionLine(target.missions[i].sailorConsequencies[j].condition, ressourcesFieldsLabels, conditionSignLabels, "if");
                    }

                    target.missions[i].sailorConsequencies[j].nb = EditorGUILayout.IntField("Sailors Nb", target.missions[i].sailorConsequencies[j].nb);
                }

                DrawerUtils.AddAndRemoveButtons<SailorSpawn>(target.missions[i].sailorConsequencies);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasSailorsFailureConsequencies"));
            if (target.missions[i].hasSailorsFailureConsequencies) {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("isSailorsFailureConsequenciesConditional"));
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.missions[i].sailorsFailureConsequencies.Count; j++) {
                    if (target.missions[i].isSailorsFailureConsequenciesConditional) {
                        DrawerUtils.DrawConditionLine(target.missions[i].sailorsFailureConsequencies[j].condition, ressourcesFieldsLabels, conditionSignLabels, "if");
                    }

                    target.missions[i].sailorsFailureConsequencies[j].nb = EditorGUILayout.IntField("Sailors Nb", target.missions[i].sailorsFailureConsequencies[j].nb);
                }

                DrawerUtils.AddAndRemoveButtons<SailorSpawn>(target.missions[i].sailorsFailureConsequencies);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
                EditorGUILayout.Separator();
            }

            EditorGUI.indentLevel--;
        }
    }

}
