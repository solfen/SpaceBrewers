using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData : MonoBehaviour {
    public static GameData instance;

    [Tooltip("The duration of a game in s")]
    public float gameDuration;
    public List<BuildingCategory> buildingsCategories;
    public List<InfoMessageStyle> infoMessageStyles;
    public List<InfoMessage> infoMessages;

    [HideInInspector]
    public MercenaryTeam mercenaryTeam;

    public Dictionary<InfoMessageType, InfoMessageStyle> infoMessageStylesDictionary = new Dictionary<InfoMessageType, InfoMessageStyle>();
    public Dictionary<string, InfoMessage> infoMessagesDictionary = new Dictionary<string, InfoMessage>();

    [HideInInspector]
    public bool isControlsBlocked = false;

    void Awake() {
        instance = this;

        //Unity doesnt serialize Dictionaries so we must create them ourselves (or make a custom inspector but I'm too lazy for that)
        for (int i = 0; i < infoMessageStyles.Count; i++) {
            infoMessageStylesDictionary.Add(infoMessageStyles[i].type, infoMessageStyles[i]);
        }
        for (int i = 0; i < infoMessages.Count; i++) {
            infoMessagesDictionary.Add(infoMessages[i].name, infoMessages[i]);
        }

    }

    public void SetIsControlsBlocked(bool state) {
        isControlsBlocked = state;
    }

}
