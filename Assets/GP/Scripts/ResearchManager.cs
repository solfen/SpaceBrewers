using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResearchManager : MonoBehaviour {
    public static ResearchManager instance;
    public float precentUpdateInterval;

    public List<ResearchTemplate> researches = new List<ResearchTemplate>();
    public Dictionary<ResearchType, Dictionary<string, Research>> availableResearches = new Dictionary<ResearchType, Dictionary<string, Research>>();
    public string currentResearchName;

    private IEnumerator researchRoutine;
    private float lastResearchTime;

    void Awake() {
        instance = this;

        availableResearches.Add(ResearchType.BASE, new Dictionary<string, Research>());
        availableResearches.Add(ResearchType.BEER, new Dictionary<string, Research>());
        availableResearches.Add(ResearchType.MERCENARIES, new Dictionary<string, Research>());
        availableResearches.Add(ResearchType.OBJECTS, new Dictionary<string, Research>());
        availableResearches.Add(ResearchType.SAILORS, new Dictionary<string, Research>());
    }

    public void GenerateResearchList(ResearchType researchType) {
        for (int i = 0; i < researches.Count; i++) {
            if (!CheckSpawnConditions(i, researchType)) {
                continue;
            }

            Research research = new Research();
            research.templateRef = researches[i];
            research.name = researches[i].name + " Mark: " + (researches[i].nbAugemented+1);
            research.completionPercent = 0;
            research.cost = researches[i].baseCost * (researches[i].nbAugemented+1) * researches[i].costMultiplierEachTime;
            research.duration = researches[i].baseDuration * (researches[i].nbAugemented+1) * researches[i].costMultiplierEachTime;
            research.timeLeft = research.duration;

            availableResearches[researchType].Add(researches[i].name, research);
        }
    }

    public void StartResearch(ResearchType type, string name) {
        if (RessourcesManager.instance.moneyNb >= availableResearches[type][name].cost) {
            currentResearchName = name;
            researchRoutine = DoResearch(type, name);
            StartCoroutine(researchRoutine);
        }
    }

    public void StopResearch() {
        if (researchRoutine != null) {
            StopCoroutine(researchRoutine);

            currentResearchName = null;
        }
    }

    IEnumerator DoResearch(ResearchType type, string name) {
        Research research = availableResearches[type][name];
        lastResearchTime = Time.time;
        RessourcesManager.instance.AddMoney(-research.cost);
        research.cost = 0;

        //TODO : no loop for updating, just save a startTime in research and Do a GetResearchCompletionPercent() that calculates it when needed !
        //But then how can we stop the research ???
        while (true) {
            research.timeLeft -= Time.time - lastResearchTime;
            research.completionPercent = 100 - research.timeLeft / research.duration * 100;
            if (research.completionPercent >= 100) {
                break;
            }

            lastResearchTime = Time.time;

            yield return new WaitForSeconds(research.duration / 100 * precentUpdateInterval);
        }

        FinnishResearch(type, name);
    }

    private void FinnishResearch(ResearchType type, string name) {
        Research research = availableResearches[type][name];

        if (research.templateRef.hasRessourceRewards) {
            for (int i = 0; i < research.templateRef.ressourcesRewards.Count; i++) {
                ReflectionUtils.AddAmount<RessourcesManager>(RessourcesManager.instance, research.templateRef.ressourcesRewards[i].field, ReflectionUtils.GenerateRandomFromRewardString(research.templateRef.ressourcesRewards[i].amount));
            }
        }

        if (research.templateRef.hasObjectRewards) {
            for (int i = 0; i < research.templateRef.objectRewards.Count; i++) {
                for(int j=0; j<GameData.instance.buildingsCategories.Count; j++) {
                    Building building = GameData.instance.buildingsCategories[j].buildings.Find(x => x.name == research.templateRef.objectRewards[i].objectName);
                    if (building != null) {
                        building.isUnlocked = true;
                        UI_Manager.instance.RefreshBuildingList(j);
                        break;
                    }
                }
            }
        }

        if (research.templateRef.hasMercenariesRewards) {
            for (int i = 0; i < research.templateRef.mercenariesRewards.Count; i++) {
                ReflectionUtils.AddAmount<MercenaryTeam>(GameData.instance.mercenaryTeam, research.templateRef.mercenariesRewards[i].field, ReflectionUtils.GenerateRandomFromRewardString(research.templateRef.mercenariesRewards[i].amount));
            }
        }

        currentResearchName = null;
        research.templateRef.nbAugemented++;
        availableResearches[type].Remove(name);

        InfoMessagesList.instance.AddMessage("ReseachFinished");
    }

    private bool CheckSpawnConditions(int i, ResearchType researchType) {
        if (researches[i].type != researchType) {
            return false;
        }

        // research is already in availableResearches
        if (availableResearches[researchType].ContainsKey(researches[i].name)) {
            return false;
        }

        if (researches[i].nbAugemented >= researches[i].nbOfAugments) {
            return false;
        }

        if (researches[i].hasRessourcesSpawnCondition) {
            for (int j = 0; j < researches[i].ressourcesSpawnConditions.Count; j++) {
                if (!ReflectionUtils.CheckCondition<RessourcesManager>(RessourcesManager.instance, researches[i].ressourcesSpawnConditions[j])) {
                    return false;
                }
            }
        }

        return true;
    }
}
