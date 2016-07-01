using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(EventsManager))]
public class EventDrawer : Editor {

    private string[] ressourcesFieldsLabels;
    private string[] conditionSignLabels = new string[3] { ">", "<", "=" };
    private string[] rewardSignLabels = new string[1] { "+" };
    private EventsManager myTarget;

    public override void OnInspectorGUI() {
        myTarget = (EventsManager)target;
        if (ressourcesFieldsLabels == null) {
            ressourcesFieldsLabels = DrawerUtils.GetFieldsAsStrings<RessourcesManager>();
        }

        serializedObject.Update();
        ShowList(myTarget, serializedObject.FindProperty("events"));
        serializedObject.ApplyModifiedProperties();
    }

    private void ShowList(EventsManager target, SerializedProperty list) {
        int originalIndentLevel = EditorGUI.indentLevel;

        EditorGUILayout.PropertyField(list);
        if (!list.isExpanded) {
            return;
        }

        EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
        if (target.events.Count != list.arraySize) {
            return; // serialized property has not been updated
        }

        target.eventsCheckInterval = EditorGUILayout.FloatField("Check Interval (in sec)", target.eventsCheckInterval);

        for (int i = 0; i < target.events.Count; i++) {
            var elem = list.GetArrayElementAtIndex(i);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(elem);
            if (!elem.isExpanded) {
                EditorGUI.indentLevel--;
                continue;
            }
            
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("name"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("peremptionTime"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("canHappendOnlyOnce"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("isModal"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("isKillable"));

            target.events[i].probability = EditorGUILayout.IntField("Probability (in %)", target.events[i].probability);
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("antenaProbabilityEnhancement"));
            EditorGUILayout.PropertyField(elem.FindPropertyRelative("alienWrittenProbability"));

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasSpawningCondition"));
            if (target.events[i].hasSpawningCondition) {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.events[i].spawnConditions.Count; j++) {
                    DrawerUtils.DrawConditionLine(target.events[i].spawnConditions[j], ressourcesFieldsLabels, conditionSignLabels);
                }

                DrawerUtils.AddAndRemoveButtons<FieldModificator>(target.events[i].spawnConditions);
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasPopUp"));
            if (target.events[i].hasPopUp) {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("popUpTitle"));
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("popUpSender"));
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("popUpDescription"));
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("popUpIcon"));
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasChoices"));

                if (target.events[i].hasChoices) {
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(elem.FindPropertyRelative("isChoicesConditional"));
                    EditorGUILayout.PropertyField(elem.FindPropertyRelative("isLockedChoicesHidden"));
                    EditorGUILayout.BeginVertical("Box");

                    for (int j = 0; j < target.events[i].choices.Count; j++) {
                        if (target.events[i].isChoicesConditional) {
                            DrawerUtils.DrawConditionLine(target.events[i].choices[j].condition, ressourcesFieldsLabels, conditionSignLabels, "if");
                        }
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.LabelField("Text", GUIStyle.none, DrawerUtils.labelWidth);
                        target.events[i].choices[j].text = EditorGUILayout.TextField(target.events[i].choices[j].text);
                        EditorGUILayout.EndHorizontal();
                    }
                    DrawerUtils.AddAndRemoveButtons<PopUpChoice>(target.events[i].choices);
                    EditorGUILayout.EndVertical();

                    EditorGUI.indentLevel--;
                }
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("doesSpawnPrefab"));
            if (target.events[i].doesSpawnPrefab) {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("isPrefabSpawnConditional"));

                EditorGUILayout.BeginVertical("Box");
                for (int j = 0; j < target.events[i].prefabsSpawn.Count; j++) {
                    if (target.events[i].isPrefabSpawnConditional) {
                        DrawerUtils.DrawConditionLine(target.events[i].prefabsSpawn[j].condition, ressourcesFieldsLabels, conditionSignLabels, "if");
                    }
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("spawn", GUIStyle.none, DrawerUtils.labelWidth);
                    target.events[i].prefabsSpawn[j].prefab = EditorGUILayout.ObjectField(target.events[i].prefabsSpawn[j].prefab, typeof(GameObject), false);
                    target.events[i].prefabsSpawn[j].position = EditorGUILayout.Vector3Field("", target.events[i].prefabsSpawn[j].position);
                    EditorGUILayout.EndHorizontal();
                }
                DrawerUtils.AddAndRemoveButtons<EventSpawnPrefab>(target.events[i].prefabsSpawn);
                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("doesSpawnSailor"));
            if (target.events[i].doesSpawnSailor) {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("isSailorSpawnConditional"));
                EditorGUILayout.BeginVertical("Box");

                for (int j = 0; j < target.events[i].sailorsToSpawn.Count; j++) {
                    if (target.events[i].isSailorSpawnConditional) {
                        DrawerUtils.DrawConditionLine(target.events[i].sailorsToSpawn[j].condition, ressourcesFieldsLabels, conditionSignLabels);
                    }

                    target.events[i].sailorsToSpawn[j].nb = EditorGUILayout.IntField("Sailors nb", target.events[i].sailorsToSpawn[j].nb);
                }

                DrawerUtils.AddAndRemoveButtons<SailorSpawn>(target.events[i].sailorsToSpawn);
                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.PropertyField(elem.FindPropertyRelative("hasRewardCondition"));
            EditorGUILayout.BeginVertical("Box");
            for (int j = 0; j < target.events[i].rewards.Count; j++) {
                if (target.events[i].hasRewardCondition) {
                    DrawerUtils.DrawConditionLine(target.events[i].rewards[j].condition, ressourcesFieldsLabels, conditionSignLabels, "if");
                }

                DrawerUtils.DrawConditionLine(target.events[i].rewards[j].reward, ressourcesFieldsLabels, rewardSignLabels, "reward");
            }
            DrawerUtils.AddAndRemoveButtons<Reward>(target.events[i].rewards);
            EditorGUILayout.EndVertical();


            EditorGUILayout.PropertyField(elem.FindPropertyRelative("doesSpawnAnotherEvent"));
            if (target.events[i].doesSpawnAnotherEvent) {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("eventSpawnDelay"));
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("doesEventBypassConditions"));
                EditorGUILayout.PropertyField(elem.FindPropertyRelative("isEventSpawnConditional"));
                if (target.events[i].isEventSpawnConditional) {
                    EditorGUILayout.BeginVertical("Box");

                    for (int j = 0; j < target.events[i].nextEvent.Count; j++) {
                        DrawerUtils.DrawConditionLine(target.events[i].nextEvent[j].condition, ressourcesFieldsLabels, conditionSignLabels);

                        EditorGUILayout.BeginHorizontal();
                        target.events[i].nextEvent[j].eventName = EditorGUILayout.TextField("Event Name", target.events[i].nextEvent[j].eventName);
                        EditorGUILayout.EndHorizontal();
                    }

                    DrawerUtils.AddAndRemoveButtons<EventSpawnEvent>(target.events[i].nextEvent);
                    EditorGUILayout.EndVertical();
                }
                else {
                    target.events[i].noConditionNextEventName = EditorGUILayout.TextField("Event Name", target.events[i].noConditionNextEventName);
                }
            }
            EditorGUI.indentLevel--;
            

            EditorGUI.indentLevel = originalIndentLevel;
        }

    }
}