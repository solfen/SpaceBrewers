using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ResearchTemplate {
    public string name;
    public ResearchType type;
    public Sprite icon;
    public float baseDuration;
    public float baseCost;
    public float nbOfAugments;
    public float costMultiplierEachTime;
    public string description;
    public string summary;
    public bool hasRessourcesSpawnCondition;
    public List<FieldModificator> ressourcesSpawnConditions = new List<FieldModificator>();
    public bool hasRessourceRewards = false;
    public List<RandomFieldModificator> ressourcesRewards = new List<RandomFieldModificator>();
    public bool hasObjectRewards = false;
    public List<ObjectReward> objectRewards = new List<ObjectReward>();
    public bool hasMercenariesRewards = false;
    public List<RandomFieldModificator> mercenariesRewards = new List<RandomFieldModificator>();

    public int nbAugemented = 1;
}

[System.Serializable]
public class Research {
    public ResearchTemplate templateRef;
    public string name;
    public float completionPercent;
    public float cost;
    public float duration;
    public float timeLeft;
}

[System.Serializable]
public class ObjectReward {
    public string objectName;
}

[System.Serializable]
public enum ResearchType {
    OBJECTS,
    MERCENARIES,
    BEER,
    SAILORS,
    BASE
}
