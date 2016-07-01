using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public enum FamilyAIType {
    NORMAL = 0,
    SLOW = 1,
    STRONG = 2,
    WEAK = 3,
    RANDOM = 4
}

[System.Serializable]
public class FamilyAI {
    public FamilyAIType type;
    public AnimationCurve curve;
}

[System.Serializable]
public class Family {
    public string name;
    public Sprite sigil;
    public string history;
    public float reputationPercent;
    public float reputationModifications;
    public FamilyAIType AIType;
}

[System.Serializable]
public class PlayableFamily {
    [Header("Family Infos")]
    public string name;
    public string history;
    public Sprite sigil;
    public string reputationPercent;

    [Header("Sector Infos")]
    public string sectorName;
    public string sectorWealth;
    public string sectorHostility;

    [Header("Ressources Infos")]
    public string startMoney;
    public string startBeer;
    public string startMaxBeer;

    [Header("Buildings Infos")]
    public GameObject baseBrewery;
    //TODO Buildings

    //TODO Research

    [Header("Mercenaries Infos")]
    public string mercenariesDefenseSkill;
    public string mercenariesNegociationSkill;
    public string mercenariesSneakSkill;

    public bool isUnlocked = false;
}

public class FamiliesManager : MonoBehaviour {
    public static FamiliesManager instance;

    public float beerContestInterval;
    public List<PlayableFamily> playableFamilies = new List<PlayableFamily>();
    public List<string> familiesNames = new List<string>();
    public List<Sprite> familiesSigils = new List<Sprite>();
    public List<FamilyAI> familiesAI = new List<FamilyAI>();

    [HideInInspector]
    public List<Family> reputationOrderedFamilies = new List<Family>();

    [HideInInspector]
    public Dictionary<FamilyAIType, FamilyAI> familieAIDictionary = new Dictionary<FamilyAIType, FamilyAI>();

    [HideInInspector]
    public Dictionary<string, Family> families = new Dictionary<string, Family>();

    [HideInInspector]
    public PlayableFamily playerFamilyTemplate;

    private List<Sprite> usedSigils = new List<Sprite>();

    void Awake() {
        instance = this;

        for (int i = 0; i < familiesAI.Count; i++) {
            familieAIDictionary.Add(familiesAI[i].type, familiesAI[i]);
        }
    }

    public void SelectPlayableFamily(int index) {
        playerFamilyTemplate = playableFamilies[index];

        Family playerFamily = new Family();
        playerFamily.name = playerFamilyTemplate.name;
        playerFamily.sigil = playerFamilyTemplate.sigil;
        playerFamily.reputationModifications = ReflectionUtils.GenerateRandomFromRewardString(playerFamilyTemplate.reputationPercent);
        playerFamily.reputationPercent = playerFamily.reputationModifications;
        RessourcesManager.instance.AddReputation(playerFamily.reputationModifications);

        if (playerFamilyTemplate.baseBrewery != null) {
            MapEditor.instance.preconstructRooms = new List<MapEditor.PreconstructRoom>();
            foreach(Transform child in playerFamilyTemplate.baseBrewery.transform) {
                MapEditor.PreconstructRoom room = new MapEditor.PreconstructRoom();
                room.prefab = child.gameObject;
                room.isBar = child.name == "bar";
                MapEditor.instance.preconstructRooms.Add(room);
            }
            MapEditor.instance.BuildPreconstructRoom();
        }

        families.Add(playerFamily.name, playerFamily);
        reputationOrderedFamilies.Add(playerFamily);
    }

    //TODO : encapsulation, it's not right that sector manager calls this
    public string CreateFamily(FamilyAIType AIType, float baseReputation) {
        if (familieAIDictionary.Count >= familiesNames.Count) {
            Debug.LogError("All families name are used ! can't generate a new family !");
            return "";
        }

        if (usedSigils.Count >= familiesSigils.Count) {
            Debug.LogError("All families sigils are used ! can't generate a new family !");
            return "";
        }

        Family family = new Family();

        do {
            family.name = familiesNames[Random.Range(0, familiesNames.Count)];

        } while (families.ContainsKey(family.name));

        do {
            family.sigil = familiesSigils[Random.Range(0, familiesSigils.Count)];

        } while (usedSigils.Contains(family.sigil));

        usedSigils.Add(family.sigil);

        family.reputationModifications = baseReputation;
        family.reputationPercent = baseReputation;
        family.AIType = AIType == FamilyAIType.RANDOM ? (FamilyAIType)Random.Range(0, 4) : AIType;

        families.Add(family.name, family);
        reputationOrderedFamilies.Add(family);

        return family.name;
    }

    public void StartGalacticalBeerContest() {
        StartCoroutine("UpdateFamiliesReputaion");
    }

    IEnumerator UpdateFamiliesReputaion() {
        float timer = beerContestInterval;

        while (true) {
            if (timer < 0) {
                float timeRatio =  Time.time / GameData.instance.gameDuration;

                //player doesn't have an AI so there's no interpolation on animation curve
                families[playerFamilyTemplate.name].reputationPercent = RessourcesManager.instance.reputation;

                foreach (Family family in families.Values) {
                    if (family.name == playerFamilyTemplate.name) {
                        continue;
                    }
                    family.reputationPercent = Mathf.Lerp(0, 100, familieAIDictionary[family.AIType].curve.Evaluate(timeRatio)) + family.reputationModifications;
                }

                reputationOrderedFamilies.Sort(delegate(Family a, Family b) {
                    return (int)(b.reputationPercent - a.reputationPercent);
                });

                SectorManager.instance.UpdateSectorsReputation();

                //UI_Manager.instance.OpenBeerContestPane();

                timer = beerContestInterval;
            }

            timer -= Time.deltaTime;

            yield return null;
        }
    }
}
