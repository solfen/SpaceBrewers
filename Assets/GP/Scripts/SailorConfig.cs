using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public enum SailorOrderType {
    NONE,
    DRINK,
    USE,
    BUILD,
    UPGRADE,
    DESTROY,
    REPAIR,
    MOVE,
    IGNORE_ORDER,
    FIGHT,
    FIGHTBACK,
    MAD,
    KILL,
    DIE,
    COMA,
    QUIT,
    GO_DRINK
}

[System.Serializable]
public class SailorActionMessage {
    public SailorOrderType type;
    public List<string> texts = new List<string>();
}

[System.Serializable]
public class SailorEvent {
    public SailorOrderType orderType;
    public float minDrunkness;
    public float maxDrunkness;
    public float probability;
    public bool cantHappendWhileDrinking;
}

[System.Serializable]
public class SailorOderPriority {
    public SailorOrderType type;
    public int priority;
}

[System.Serializable]
public class SailorColorFeedback {
    public float minDrunkness;
    public float maxDrunkness;
    public Color color;
    public float flashSpeed;
}

[System.Serializable]
public class SailorsConfig {
    public List<SailorOderPriority> ordersPriorityList = new List<SailorOderPriority>();
    public Dictionary<SailorOrderType, int> ordersPriority = new Dictionary<SailorOrderType, int>();
    public List<SailorEvent> sailorEvents = new List<SailorEvent>();
    public float eventCheckerInterval = 1;
    public List<SailorActionMessage> actionMessageTextsList = new List<SailorActionMessage>();
    public Dictionary<SailorOrderType, List<string>> actionMessageTexts = new Dictionary<SailorOrderType,List<string>>();
    public List<string> sailorNames = new List<string>();
    public List<SailorColorFeedback> sailorColorFeedbacks = new List<SailorColorFeedback>();
    [HideInInspector]
    public List<Transform> barRefilingStations = new List<Transform>();
    [HideInInspector]
    public List<Transform> barWanderPoints = new List<Transform>();
    [HideInInspector]
    public List<Transform> spawnPoints = new List<Transform>();
}
