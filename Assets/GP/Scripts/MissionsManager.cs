using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class MissionsManager : MonoBehaviour {
    public static MissionsManager instance;

    public float sectorHostilityCoef;
    public float sectorDistanceCoef;
    public float sectorReputationCoef;
    public float mercenaryDefenseCoef;
    public float mercenaryNegociationCoef;
    public float mercenarySneakCoef;
    public float mindManipulationCoef;

    public List<MissionTemplate> missions;

    //Missions are classed by type and by sector
    public Dictionary<Sector, Dictionary<MissionType, List<Mission>>> availableMissions = new Dictionary<Sector, Dictionary<MissionType, List<Mission>>>();
    public bool isDoingMission = false;
    public float timeMissionStarted;
    public float missionDuration;

    void Awake() {
        instance = this;
    }

    public void InitMissionsDictionary() {
        for (int i = 0; i < SectorManager.instance.sectors.Count; i++) {
            availableMissions.Add(SectorManager.instance.sectors[i], new Dictionary<MissionType, List<Mission>>());
            availableMissions[SectorManager.instance.sectors[i]].Add(MissionType.DELIVERY, new List<Mission>());
            availableMissions[SectorManager.instance.sectors[i]].Add(MissionType.DIPLOMACY, new List<Mission>());
            availableMissions[SectorManager.instance.sectors[i]].Add(MissionType.SABOTAGE, new List<Mission>());
        }
    }

    public void GenerateSectorMissionList(Sector sector) {
        availableMissions[sector][MissionType.DELIVERY].Clear();
        availableMissions[sector][MissionType.DIPLOMACY].Clear();
        availableMissions[sector][MissionType.SABOTAGE].Clear();

        for (int i = 0; i < missions.Count; i++) {
            if (!CheckMissionConditions(i, sector)) {
                continue;
            }

            Mission mission = new Mission();
            mission.templateRef = missions[i];
            mission.name = missions[i].name;
            mission.sector = sector;
            mission.successProbability = CalculateSuccessRate(missions[i].successProbabilityFactor, mission.templateRef.type, sector);
            mission.duration = missions[i].durationFactor + missions[i].durationFactor * sector.distance/100;
            mission.description = missions[i].descriptions[Random.Range(0, missions[i].descriptions.Count)].text;
            //missions[i].description.Replace("{{familyName}}", sector.familyName) // TODO texts snipets

            availableMissions[sector][missions[i].type].Add(mission);
        }
    }

    public void StartMission(Mission mission) {
        if (!isDoingMission && RessourcesManager.instance.beerNb >= mission.templateRef.beerCost && (RessourcesManager.instance.moneyNb >= mission.templateRef.moneyCost ||  mission.templateRef.moneyCost <= 0)) {
            StartCoroutine("DoMission", mission);
            isDoingMission = true;
            TutoManager.instance.SetState("isMissionStarted", true);
        }
    }

    IEnumerator DoMission(Mission mission) {
        timeMissionStarted = Time.time;
        missionDuration = mission.duration;
        RessourcesManager.instance.AddMoney(-mission.templateRef.moneyCost);
        RessourcesManager.instance.AddBeer(-mission.templateRef.beerCost);

        yield return new WaitForSeconds(mission.duration);
        EndMission(mission);
    }

    public void QuitMission() {
        StopCoroutine("DoMission");
        isDoingMission = false;
    }

    private bool CheckMissionConditions(int i, Sector sector) {
        if (missions[i].hasSectorSpawnCondtions) {
            for (int j = 0; j < missions[i].sectorSpawnCondtions.Count; j++) {
                if (!ReflectionUtils.CheckCondition<Sector>(sector, missions[i].sectorSpawnCondtions[j])) {
                    return false;
                }
            }
        }

        if (missions[i].hasRessourcesSpawnCondition) {
            for (int j = 0; j < missions[i].ressourcesSpawnConditions.Count; j++) {
                if (!ReflectionUtils.CheckCondition<RessourcesManager>(RessourcesManager.instance, missions[i].ressourcesSpawnConditions[j])) {
                    return false;
                }
            }
        }

        if (missions[i].hasFamilySpawnCondtions) {
            for (int j = 0; j < missions[i].familySpawnConditions.Count; j++) {
                if (!ReflectionUtils.CheckCondition<Family>(FamiliesManager.instance.families[sector.beerFamilyName], missions[i].familySpawnConditions[j])) {
                    return false;
                }
            }
        }

        return true;
    }

    private void EndMission(Mission mission) {
            
        int diceThrow = Random.Range(0, 100);

        if (diceThrow < mission.successProbability) {
            WinMission(mission);
        }
        else {
            FailMission(mission);
        }
        isDoingMission = false;
        SectorManager.instance.UpdateSectorsReputation();
    }

    private void WinMission(Mission mission) {
        if (mission.templateRef.hasRessourcesReward) {
            for (int i = 0; i < mission.templateRef.ressourceRewards.Count; i++) {
                if (mission.templateRef.isRessourcesRewardConditional && !ReflectionUtils.CheckCondition<Sector>(mission.sector, mission.templateRef.ressourceRewards[i].condition)) {
                    continue;
                }
                float baseAmount = ReflectionUtils.GenerateRandomFromRewardString(mission.templateRef.ressourceRewards[i].reward.amount);
                ReflectionUtils.AddAmount<RessourcesManager>(RessourcesManager.instance, mission.templateRef.ressourceRewards[i].reward.field, baseAmount + baseAmount * mission.sector.wealthPercent/100);
            }
        }

        if (mission.templateRef.hasSectorConsequencies) {
            for (int i = 0; i < mission.templateRef.sectorConsequencies.Count; i++) {
                if (mission.templateRef.isSectorConsequenciesConditional && !ReflectionUtils.CheckCondition<Sector>(mission.sector, mission.templateRef.sectorConsequencies[i].condition)) {
                    continue;
                }
                ReflectionUtils.AddAmount<Sector>(mission.sector, mission.templateRef.sectorConsequencies[i].consequency.field, ReflectionUtils.GenerateRandomFromRewardString(mission.templateRef.sectorConsequencies[i].consequency.amount));
            }
        }

        if (mission.templateRef.hasFamilyConsequencies) {
            for (int i = 0; i < mission.templateRef.familyConsequencies.Count; i++) {
                if (mission.templateRef.isFamilyConsequenciesConditional && !ReflectionUtils.CheckCondition<Family>(FamiliesManager.instance.families[mission.sector.beerFamilyName], mission.templateRef.familyConsequencies[i].condition)) {
                    continue;
                }
                ReflectionUtils.AddAmount<Family>(FamiliesManager.instance.families[mission.sector.beerFamilyName], mission.templateRef.familyConsequencies[i].consequency.field, ReflectionUtils.GenerateRandomFromRewardString(mission.templateRef.familyConsequencies[i].consequency.amount));
            }
        }

        if (mission.templateRef.hasSailorsConsequencies) {
            for (int i = 0; i < mission.templateRef.sailorConsequencies.Count; i++) {
                if (mission.templateRef.isSailorsConsequenciesConditional && !ReflectionUtils.CheckCondition<RessourcesManager>(RessourcesManager.instance, mission.templateRef.sailorConsequencies[i].condition)) {
                    continue;
                }

                SailorManager.instance.SailorRH(mission.templateRef.sailorConsequencies[i].nb);
            }
        }

        InfoMessagesList.instance.AddMessage("MissionSuccess");
    }

    private void FailMission(Mission mission) {
       if (mission.templateRef.hasSectorFailureConsequencies) {
            for (int i = 0; i < mission.templateRef.sectorFailureConsequencies.Count; i++) {
                if (mission.templateRef.isSectorFailureConsequenciesConditional && !ReflectionUtils.CheckCondition<Sector>(mission.sector, mission.templateRef.sectorFailureConsequencies[i].condition)) {
                    continue;
                }
                ReflectionUtils.AddAmount<Sector>(mission.sector, mission.templateRef.sectorFailureConsequencies[i].consequency.field, ReflectionUtils.GenerateRandomFromRewardString(mission.templateRef.sectorFailureConsequencies[i].consequency.amount));
            }
        }

       if (mission.templateRef.hasFamilyFailureConsequencies) {
           for (int i = 0; i < mission.templateRef.familyFailureConsequencies.Count; i++) {
               if (mission.templateRef.isFamilyFailureConsequenciesConditional && !ReflectionUtils.CheckCondition<Family>(FamiliesManager.instance.families[mission.sector.beerFamilyName], mission.templateRef.familyFailureConsequencies[i].condition)) {
                   continue;
               }
               ReflectionUtils.AddAmount<Family>(FamiliesManager.instance.families[mission.sector.beerFamilyName], mission.templateRef.familyFailureConsequencies[i].consequency.field, ReflectionUtils.GenerateRandomFromRewardString(mission.templateRef.familyFailureConsequencies[i].consequency.amount));
           }
       }

       if (mission.templateRef.hasSailorsFailureConsequencies) {
           for (int i = 0; i < mission.templateRef.sailorsFailureConsequencies.Count; i++) {
               if (mission.templateRef.isSailorsFailureConsequenciesConditional && !ReflectionUtils.CheckCondition<RessourcesManager>(RessourcesManager.instance, mission.templateRef.sailorsFailureConsequencies[i].condition)) {
                   continue;
               }

               SailorManager.instance.SailorRH(mission.templateRef.sailorsFailureConsequencies[i].nb);
           }
       }

        if (mission.templateRef.type == MissionType.DELIVERY) {
            InfoMessagesList.instance.AddMessage("DeliveryMissionFail");
        }
        else if (mission.templateRef.type == MissionType.DIPLOMACY) {
            InfoMessagesList.instance.AddMessage("DiplomacyMissionFail");
        }
        else {
            InfoMessagesList.instance.AddMessage("SabotageMissionFail");
        }
    }

    private int CalculateSuccessRate(float successFactor, MissionType type, Sector sector) {
        if (type == MissionType.DELIVERY) {
            return (int)(successFactor / 100 * ((100 - sector.hostilityPercent) * sectorHostilityCoef + sector.distance * sectorDistanceCoef + sector.reputationPercent * sectorReputationCoef + GameData.instance.mercenaryTeam.defenseSkill * mercenaryDefenseCoef) / (sectorHostilityCoef + sectorDistanceCoef + sectorReputationCoef + mercenaryDefenseCoef));
        }
        else if (type == MissionType.DIPLOMACY) {
            float hasMindManipulation = RessourcesManager.instance.nbOfMindManipulatorConstructed >= 1 ? 100 : 0;
            return (int)(successFactor / 100 * (hasMindManipulation * mindManipulationCoef + sector.reputationPercent * sectorReputationCoef + GameData.instance.mercenaryTeam.negociationSkill * mercenaryNegociationCoef) / (mindManipulationCoef + sectorReputationCoef + mercenaryNegociationCoef));
        }
        else if (type == MissionType.SABOTAGE) {
            return (int)(successFactor / 100 * (sector.hostilityPercent * sectorHostilityCoef + GameData.instance.mercenaryTeam.sneakSkill * mercenarySneakCoef) / (sectorHostilityCoef + mercenarySneakCoef));
        }

        return 0;
    }
}
