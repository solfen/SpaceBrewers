using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Building {
    public string name;
    public Sprite icon;
    public Sprite hoverIcon;
    public bool isUnlocked;
    public int moneyCost;
    public GameObject prefab;
}

[System.Serializable]
public class BuildingCategory {
    public string name;
    public Sprite icon;
    public Sprite iconHover;
    public List<Building> buildings;
    public Button.ButtonClickedEvent onClick;
}

public enum ObjectCategory {
    BREWERY,
    DEFENSE,
    COMMUNICATION,
    GENERAL,
    BAR,
    NONE
};
