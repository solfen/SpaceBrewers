using UnityEngine;
using System.Collections;

public enum InfoMessageType {
    BASIC,
    SUCCESS,
    DANGER,
    MESSAGE
}

[System.Serializable]
public class InfoMessage {
    public string name;
    public InfoMessageType type;
    public string text;
}

[System.Serializable]
public class InfoMessageStyle {
    public InfoMessageType type;
    public Sprite backgroundSprite;
    public int fontSize;
    public Color fontColor;
    public string textHeader;
    public string soundName;
}
