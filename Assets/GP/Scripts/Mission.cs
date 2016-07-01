using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

[System.Serializable]
public enum MissionType {
    DELIVERY,
    SABOTAGE,
    DIPLOMACY
}

[System.Serializable]
public class SectorConsequency {
    public FieldModificator condition = new FieldModificator();
    public RandomFieldModificator consequency = new RandomFieldModificator();
}

[System.Serializable]
public class MissionDescription {
    public string text;
}

[System.Serializable]
public class MissionTemplate {
    public string name;
    public MissionType type;
    public Sprite icon;
    public float successProbabilityFactor;
    public float durationFactor;
    public float beerCost;
    public float moneyCost;
    public bool hasRessourcesSpawnCondition;
    public List<FieldModificator> ressourcesSpawnConditions = new List<FieldModificator>();
    public bool hasSectorSpawnCondtions;
    public List<FieldModificator> sectorSpawnCondtions = new List<FieldModificator>();
    public bool hasFamilySpawnCondtions;
    public List<FieldModificator> familySpawnConditions = new List<FieldModificator>();
    public List<MissionDescription> descriptions = new List<MissionDescription>();
    public bool hasRessourcesReward;
    public bool isRessourcesRewardConditional;
    public List<Reward> ressourceRewards = new List<Reward>();
    public bool hasSectorConsequencies;
    public bool isSectorConsequenciesConditional;
    public List<SectorConsequency> sectorConsequencies = new List<SectorConsequency>();
    public bool hasSectorFailureConsequencies;
    public bool isSectorFailureConsequenciesConditional;
    public List<SectorConsequency> sectorFailureConsequencies = new List<SectorConsequency>();
    public bool hasFamilyConsequencies;
    public bool isFamilyConsequenciesConditional;
    public List<SectorConsequency> familyConsequencies = new List<SectorConsequency>();
    public bool hasFamilyFailureConsequencies;
    public bool isFamilyFailureConsequenciesConditional;
    public List<SectorConsequency> familyFailureConsequencies = new List<SectorConsequency>();
    public bool hasSailorsConsequencies;
    public bool isSailorsConsequenciesConditional;
    public List<SailorSpawn> sailorConsequencies = new List<SailorSpawn>();
    public bool hasSailorsFailureConsequencies;
    public bool isSailorsFailureConsequenciesConditional;
    public List<SailorSpawn> sailorsFailureConsequencies = new List<SailorSpawn>();
}

[System.Serializable]
public class Mission {
    public MissionTemplate templateRef;
    public Sector sector;
    public float successProbability;
    public float duration;
    public string description;
    public string name;
    public Sprite icon;
}
