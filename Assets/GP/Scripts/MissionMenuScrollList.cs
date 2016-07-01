using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MissionMenuMissionTypeSprites {
    public MissionType type;
    public Sprite highlightedSprite;
    public Sprite statBoxSprite;
}

//TODO: Object pooling ?
public class MissionMenuScrollList : MonoBehaviour {

    public GameObject missionPrefab;
    public GameObject textPrefab;
    public Color miscColor;
    public Color rewardColor;
    public Color costColor;
    public Color sectorColor;
    public Text timeLeftText;
    public Button deliveriesBtn;
    public Button diplomacyBtn;
    public Button sabotageyBtn;
    public GameObject quitBtn;
    public GameObject noSectorSelectedFeedback;
    public Transform contentPannel;
    public ScrollRect scrollRect;
    public Text sectorNameText;
    public Text sectorFamilyName;
    public Image sectorFamilySigil;
    public Text sectorBeerStatText;
    public Text sectorHostilityStatText;
    public Text sectorClientStatText;
    public List<MissionMenuMissionTypeSprites> specificMissionTypeSprites = new List<MissionMenuMissionTypeSprites>();

    private SmartLocalization.LanguageManager localization;
    private Sector currentSector;
    private Dictionary<MissionType, MissionMenuMissionTypeSprites> specificMissionTypeSpritesDictionary = new Dictionary<MissionType,MissionMenuMissionTypeSprites>();
    private MissionType currentType;

    void Awake() {
        localization = SmartLocalization.LanguageManager.Instance;

        for(int i=0; i< specificMissionTypeSprites.Count; i++) {
            specificMissionTypeSpritesDictionary.Add(specificMissionTypeSprites[i].type, specificMissionTypeSprites[i]);
        }
    }

    //Called at pop up opening
    public void StartTimeLeftUpdateCoroutine() {
        StartCoroutine("TimeLeftUpdate");
    }

    public void ShowSectorInfo(int index) {
        sectorNameText.text = localization.GetTextValue(SectorManager.instance.sectors[index].name);
        sectorBeerStatText.text = localization.GetTextValue("UI_MIS_PANE_STATS_REPUT") + " " + ((int)SectorManager.instance.sectors[index].reputationPercent) + "%";
        sectorClientStatText.text = localization.GetTextValue("UI_MIS_PANE_STATS_WEALTH") + " " + ((int)SectorManager.instance.sectors[index].wealthPercent) + "%";
        sectorHostilityStatText.text = localization.GetTextValue("UI_MIS_PANE_STATS_HOSTILITY") + " " + ((int)SectorManager.instance.sectors[index].hostilityPercent) + "%";
        sectorFamilyName.text = localization.GetTextValue(SectorManager.instance.sectors[index].beerFamilyName);
        sectorFamilySigil.sprite = FamiliesManager.instance.families[SectorManager.instance.sectors[index].beerFamilyName].sigil;
    }

    public void SelectSector(int index) {
        currentSector = SectorManager.instance.sectors[index];
        ShowSectorInfo(index);
        MissionsManager.instance.GenerateSectorMissionList(currentSector);

        ShowSectorMissions(currentType);
        SoundManager.instance.PlaySound("Choose Zone");

        deliveriesBtn.interactable = !diplomacyBtn.interactable || !sabotageyBtn.interactable;
        TutoManager.instance.SetState("isSectorSelected", true);
    }

    public void ShowSectorMissions(MissionType type) {
        EmptyMissionList();
        currentType = type;

        if (currentSector == null) {
            noSectorSelectedFeedback.SetActive(true);
            return;
        }


        int missionsNb = MissionsManager.instance.availableMissions[currentSector][type].Count;
        for(int i=0; i<missionsNb; i++) {
            Mission mission = MissionsManager.instance.availableMissions[currentSector][type][i];
            GameObject instance = Instantiate(missionPrefab) as GameObject;
            Transform content = instance.transform.FindChild("Content");

            SpriteState swapTransition = new SpriteState();
            swapTransition.highlightedSprite = specificMissionTypeSpritesDictionary[type].highlightedSprite;
            swapTransition.pressedSprite = specificMissionTypeSpritesDictionary[type].highlightedSprite;
            instance.GetComponent<Button>().spriteState = swapTransition; 

            content.FindChild("Name").GetComponent<Text>().text = localization.GetTextValue(mission.name);
            content.FindChild("Icon").GetComponent<Image>().sprite = mission.icon;

            Transform description = content.FindChild("Description");
            description.GetComponent<Text>().text = localization.GetTextValue(mission.description);
            
            Transform stats = content.FindChild("Stats");
            stats.gameObject.GetComponent<Image>().sprite = specificMissionTypeSpritesDictionary[type].statBoxSprite;

            AddStat(stats, miscColor, localization.GetTextValue("UI_MIS_PANE_STAT_SUCCESS"), mission.successProbability + "%", "");
            AddStat(stats, miscColor, localization.GetTextValue("UI_MIS_PANE_STAT_DURATION"), secondsToString(mission.duration), "");

            if (mission.templateRef.beerCost != 0) {
                AddStat(stats, costColor, localization.GetTextValue("UI_MIS_PANE_STAT_COST"), mission.templateRef.beerCost.ToString(), "Beer");
            }

            if (mission.templateRef.moneyCost != 0) {
                AddStat(stats, costColor, localization.GetTextValue("UI_MIS_PANE_STAT_COST"), mission.templateRef.moneyCost.ToString(), "BeerCoins");
            }
            
            if (mission.templateRef.hasRessourcesReward) {
                for (int j = 0; j < mission.templateRef.ressourceRewards.Count; j++) {
                    AddStat(stats, rewardColor, localization.GetTextValue("UI_MIS_PANE_STAT_REWARD"), mission.templateRef.ressourceRewards[j].reward.amount, mission.templateRef.ressourceRewards[j].reward.field + " + " + mission.sector.wealthPercent + "%");
                }
            }
            
            if (mission.templateRef.hasSectorConsequencies) {
                for (int j = 0; j < mission.templateRef.sectorConsequencies.Count; j++) {
                    AddStat(stats, sectorColor, localization.GetTextValue("UI_MIS_PANE_STAT_REWARD"), mission.templateRef.sectorConsequencies[j].consequency.amount + "%", mission.templateRef.sectorConsequencies[j].consequency.field);
                }
            }

            Transform actionBtn = content.FindChild("ActionBtn");

            if (MissionsManager.instance.isDoingMission || mission.templateRef.beerCost > RessourcesManager.instance.beerNb || mission.templateRef.moneyCost > RessourcesManager.instance.moneyNb && mission.templateRef.moneyCost > 0) {
                actionBtn.GetComponent<Button>().interactable = false;
            }
            else {
                actionBtn.GetComponent<Button>().onClick.AddListener(delegate { MissionsManager.instance.StartMission(mission); StartCoroutine("TimeLeftUpdate"); });
            }

            instance.transform.SetParent(contentPannel, false);

            //need to do the size calculation at next frame because it's at 0 right now
            IEnumerator coroutine = NextFrame(stats.GetComponent<RectTransform>(), description.GetComponent<RectTransform>(), actionBtn.GetComponent<RectTransform>(), instance);
            StartCoroutine(coroutine);

            SoundManager.instance.PlaySound("Choose Mission Type");
        }
    }

    public void EndMission() {
        timeLeftText.gameObject.SetActive(false);
        quitBtn.SetActive(false);

        if (contentPannel.childCount > 0) {
            ShowSectorMissions(currentType);
        }
    }

    public void ExpandMission() {
        SoundManager.instance.PlaySound("Select Mission");
    }

    private void EmptyMissionList() {
        foreach (Transform t in contentPannel) {
            Destroy(t.gameObject);
        }

        noSectorSelectedFeedback.SetActive(false);
    }

    IEnumerator TimeLeftUpdate() {
        timeLeftText.gameObject.SetActive(true);
        quitBtn.SetActive(true);

        while (true) {
            if (!MissionsManager.instance.isDoingMission) {
                break;
            }
            
            float secondsLeft = MissionsManager.instance.missionDuration - (Time.time - MissionsManager.instance.timeMissionStarted);
            timeLeftText.text = localization.GetTextValue("WORD_TIME_LEFT") + " " + secondsToString(secondsLeft);

            yield return new WaitForSeconds(1/Mathf.Max(Time.timeScale, 0));
        }

        EndMission();
    }

    IEnumerator NextFrame(RectTransform stats, RectTransform description, RectTransform actionBtn, GameObject mission) {
        yield return null;

        CustomVerticalListTools.SetElemPosUnderPreviousElem(stats.GetComponent<RectTransform>(), description.GetComponent<RectTransform>(), 10);
        CustomVerticalListTools.SetElemPosUnderPreviousElem(actionBtn.GetComponent<RectTransform>(), stats.GetComponent<RectTransform>(), 25);
        mission.GetComponent<UIAnimatorVerticalLayout>().animations[0].endPreferedSize.y = CustomVerticalListTools.CalculateHeight(mission.transform.FindChild("Content"));
        scrollRect.verticalNormalizedPosition = 1;
    }

    private void AddStat(Transform parent, Color textColor, string textHeader, string amount, string field) {
        GameObject rewardText = Instantiate(textPrefab) as GameObject;
        rewardText.GetComponent<Text>().text = textHeader + " " + amount + " " + field;
        rewardText.GetComponent<Text>().color = textColor;
        rewardText.transform.SetParent(parent, false);
    }

    private string secondsToString(float secNb) {
        return ((int)secNb / 60) + "m" + ":" + ((int)secNb % 60) + "s";
    }
}
