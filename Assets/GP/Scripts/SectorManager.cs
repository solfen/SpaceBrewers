using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Sector {
    public string name;
    public string beerFamilyName;
    public float distance;
    public float reputationPercent;
    public float hostilityPercent;
    public float wealthPercent;
}

[System.Serializable]
public class SectorTemplate {
    public List<string> possibleNames;
    public string hostilityPercent;
    public string wealthPercent;
    public FamilyAIType AIType;
    public string baseFamilyReputation;
}

[System.Serializable]
public class Scenario {
    public List<SectorTemplate> AISectors = new List<SectorTemplate>();
}


public class SectorManager : MonoBehaviour {
    public static SectorManager instance;

    public GameObject scenariosUI;

    public int scenariosNb = 1;
    public int AIsectorsPerScenario = 7;
    public List<Scenario> scenarios = new List<Scenario>();
    public int chosenScenario;

    public List<Sector> sectors = new List<Sector>();


    void Awake() {
        instance = this;
    }

    public void GenerateGalaxy() {
        sectors.Clear();

        chosenScenario = Random.Range(0, scenariosNb);
        CreatePlayerSector();
        CreateAISectors();
    }

    public void UpdateSectorsReputation() {
        sectors[0].reputationPercent = RessourcesManager.instance.reputation;
        for (int i = 1; i < sectors.Count; i++) {
            sectors[i].reputationPercent = FamiliesManager.instance.families[sectors[i].beerFamilyName].reputationPercent;
        } 
    }

    private void CreatePlayerSector() {
        Sector sector = new Sector();
        sector.name = FamiliesManager.instance.playerFamilyTemplate.sectorName;
        sector.beerFamilyName = FamiliesManager.instance.playerFamilyTemplate.name;
        sector.reputationPercent = RessourcesManager.instance.reputation;
        sector.hostilityPercent = ReflectionUtils.GenerateRandomFromRewardString(FamiliesManager.instance.playerFamilyTemplate.sectorHostility);
        sector.wealthPercent = ReflectionUtils.GenerateRandomFromRewardString(FamiliesManager.instance.playerFamilyTemplate.sectorWealth);
        sector.distance = 0;

        sectors.Add(sector);
    }

    private void CreateAISectors() {
        Transform scenarioUI = scenariosUI.transform.GetChild(chosenScenario);
        scenarioUI.gameObject.SetActive(true);

        Transform map = scenarioUI.GetChild(Random.Range(0, scenarioUI.childCount));
        map.gameObject.SetActive(true);

        Transform sectorsUi = map.GetChild(0);

        for (int i = 0; i < AIsectorsPerScenario; i++) {
            Sector sector = new Sector();
            sector.name = scenarios[chosenScenario].AISectors[i].possibleNames[Random.Range(0, scenarios[chosenScenario].AISectors[i].possibleNames.Count)];
            sector.hostilityPercent = ReflectionUtils.GenerateRandomFromRewardString(scenarios[chosenScenario].AISectors[i].hostilityPercent);
            sector.wealthPercent = ReflectionUtils.GenerateRandomFromRewardString(scenarios[chosenScenario].AISectors[i].wealthPercent);
            sector.distance = sectorsUi.GetChild(i).GetComponent<SectorDistanceFromPlayer>().distanceFromPlayer;
            sector.beerFamilyName = FamiliesManager.instance.CreateFamily(scenarios[chosenScenario].AISectors[i].AIType, ReflectionUtils.GenerateRandomFromRewardString(scenarios[chosenScenario].AISectors[i].baseFamilyReputation));

            sectors.Add(sector);
        }

        UpdateSectorsReputation();
    }
}
