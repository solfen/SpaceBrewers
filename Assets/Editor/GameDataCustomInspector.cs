using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(GameData))]
public class GameDataCustomInspector : Editor {

    private GameData myTarget;

    public override void OnInspectorGUI() {
        myTarget = (GameData)target;
        GameData.instance = myTarget;
        DrawDefaultInspector();
    }
}
