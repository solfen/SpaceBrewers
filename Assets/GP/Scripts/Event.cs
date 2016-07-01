using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

[System.Serializable]
public class FieldModificator {
    public string field;
    public string sign;
    public float amount;
}

[System.Serializable]
public class RandomFieldModificator {
    public string field;
    public string sign;
    public string amount;
}

[System.Serializable]
public class Reward {
    public FieldModificator condition = new FieldModificator();
    public RandomFieldModificator reward = new RandomFieldModificator();
}
[System.Serializable]
public class EventSpawnEvent {
    public FieldModificator condition = new FieldModificator();
    public string eventName;
}
[System.Serializable]
public class EventSpawnPrefab {
    public FieldModificator condition = new FieldModificator();
    public Object prefab;
    public Vector3 position = new Vector3(0,0,0); 
}
[System.Serializable]
public class PopUpChoice {
    public FieldModificator condition = new FieldModificator();
    public string text;
}

public class UIEventChoice {
    public string text;
    public bool isLocked = false;
}

[System.Serializable]
public class SailorSpawn {
    public FieldModificator condition = new FieldModificator();
    public int nb;
}


[System.Serializable]
public class Event {
    public string name;
    public int probability;
    public float antenaProbabilityEnhancement;
    public float alienWrittenProbability;
    public float peremptionTime;
    public bool canHappendOnlyOnce = false;
    public bool isModal = false;
    public bool isKillable = false;
    public bool hasSpawningCondition = false;
    public List<FieldModificator> spawnConditions = new List<FieldModificator>();
    public bool hasPopUp = false;
    public string popUpTitle;
    public string popUpSender;
    public string popUpDescription;
    public Sprite popUpIcon;
    public bool hasChoices = false;
    public bool isChoicesConditional = false;
    public bool isLockedChoicesHidden = true;
    public List<PopUpChoice> choices = new List<PopUpChoice>();
    public bool doesSpawnSailor = false;
    public bool isSailorSpawnConditional = false;
    public List<SailorSpawn> sailorsToSpawn = new List<SailorSpawn>();
    public bool doesSpawnPrefab = false;
    public bool isPrefabSpawnConditional = false;
    public List<EventSpawnPrefab> prefabsSpawn = new List<EventSpawnPrefab>();
    public bool hasRewardCondition = false;
    public List<Reward> rewards = new List<Reward>();
    public bool doesSpawnAnotherEvent = false;
    public bool doesEventBypassConditions = false;
    public float eventSpawnDelay = 0;
    public bool isEventSpawnConditional = false;
    public List<EventSpawnEvent> nextEvent = new List<EventSpawnEvent>();
    public string noConditionNextEventName;
}
