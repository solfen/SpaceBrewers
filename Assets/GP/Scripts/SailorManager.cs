using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class SailorManager : MonoBehaviour
{
    public static SailorManager instance;
    [Range(0,100)]
    public int selectSoundProba = 50;
    public float drunknessRateMultiplier = 1; // setting it to 0 freeze all sailors drunkness
    public int startSailorNb = 2;
    public List<GameObject> sailorsPrefabs = new List<GameObject>();
    public List<Sailor> sailorsList = new List<Sailor>();
    public SailorsConfig sailorsConfig = new SailorsConfig();
    private Sailor selectedSailor;
    private SailorOrderType selectedOrder = SailorOrderType.USE;
    private List<string> availablesNames;

    //TODO: Upgrade constraints
    void Awake() {
        instance = this;
        for (int i = 0; i < sailorsConfig.ordersPriorityList.Count; i++) {
            sailorsConfig.ordersPriority[sailorsConfig.ordersPriorityList[i].type] = sailorsConfig.ordersPriorityList[i].priority;
        }
        for (int i = 0; i < sailorsConfig.actionMessageTextsList.Count; i++) {
            sailorsConfig.actionMessageTexts[sailorsConfig.actionMessageTextsList[i].type] = sailorsConfig.actionMessageTextsList[i].texts;
        }

        availablesNames = new List<string>(sailorsConfig.sailorNames);
    }

    public void InitSailors() {
        GameObject[] stations = GameObject.FindGameObjectsWithTag("barRefilingStations");
        for (int i = 0; i < stations.Length; i++ ) {
            sailorsConfig.barRefilingStations.Add(stations[i].transform);
        }

        GameObject[] wanderPoints = GameObject.FindGameObjectsWithTag("barWanderPoints");
        for (int i = 0; i < wanderPoints.Length; i++) {
            sailorsConfig.barWanderPoints.Add(wanderPoints[i].transform);
        }

        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("sailorSpawnPoint");
        for (int i = 0; i < spawnPoints.Length; i++) {
            sailorsConfig.spawnPoints.Add(spawnPoints[i].transform);
        }

        for (int i = 0; i < sailorsList.Count; i++) {
            sailorsList[i].gameObject.SetActive(true);
            SailorStateIcons.instance.CreateIcon(sailorsList[i]);
        }
        SailorRH(startSailorNb);
    }
	
    void Update() {
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                //Debug.Log("object :" + "name = " + hitInfo.transform.name + ", tag = " + hitInfo.transform.gameObject.tag);
                if (hitInfo.transform.tag == "Activable") {
                    OnObjectHit(hitInfo.transform.gameObject.GetComponent<Furniture>());
                }
                else if(hitInfo.transform.tag == "DrunkenSailor") {
                    SelectSailor(hitInfo.transform.gameObject.GetComponent<Sailor>());
                }
                else if (selectedSailor && hitInfo.transform.tag == "Bar") {
                    selectedSailor.GiveOrder(SailorOrderType.GO_DRINK);
                }
                else if (selectedSailor) {
                    UI_Manager.instance.CloseSailorPane();
                    selectedSailor.selectedFeedback.SetActive(false);
                    selectedSailor = null;
                }
                else {
                    UI_Manager.instance.CloseObjectStatsPane();
                }
            }
        }
    }


    public void SailorRH(int nb) {
        if (nb > 0) {
            for(int i=0; i < nb; i++) {
                CreateSailor();
            }
        }
        else {
            int cpt = 0;
            while (cpt < -nb && sailorsList.Count > 0) {
                RemoveSailor(sailorsList[Random.Range(0, sailorsList.Count)]);
                cpt++;
            }
        }
    }

    public void CreateSailor() {
        Sailor sailor = (Instantiate(sailorsPrefabs[Random.Range(0, sailorsPrefabs.Count)]) as GameObject).GetComponent<Sailor>();
        sailorsList.Add(sailor);
        if(availablesNames.Count > 0) {
            int random = Random.Range(0, availablesNames.Count);
            sailor.sailorName = availablesNames[random];
            availablesNames.RemoveAt(random);
        }
        else {
            sailor.sailorName = sailorsConfig.sailorNames[Random.Range(0, sailorsConfig.sailorNames.Count)];
        }

        SailorStateIcons.instance.CreateIcon(sailor);
    }

    public void RemoveSailor(Sailor sailor) {
        UI_Manager.instance.OnSailorDelete(sailor);
        SailorStateIcons.instance.DestroyIcon(sailor);
        sailorsList.Remove(sailor);
        Destroy(sailor.gameObject);

        if (sailorsList.Count == 0) {
            GameManager.instance.GameOver(GameDeathReasons.NOSAILORS);
        }
    }

    public void SetSelectedOrder(SailorOrderType orderType) {
        selectedOrder = orderType;
    }

    public void SetDefaultOrder() {
        selectedOrder = SailorOrderType.USE;
    }

    public void SelectSailor(Sailor newSailor) {
        TutoManager.instance.SetState("isFirstSailorSelection", true);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        if (selectedSailor != null) {
            selectedSailor.selectedFeedback.SetActive(false);
        }

        selectedSailor = newSailor;
        selectedSailor.selectedFeedback.SetActive(true);
        SailorStateIcons.instance.SelectFeedback(selectedSailor);
        SetDefaultOrder();

        UI_Manager.instance.OpenSailorPane(selectedSailor);

        if (Random.Range(0, 100) < selectSoundProba) {
            string sound;
            if (selectedSailor.drunkness >= 75)
                sound = "High";
            else if (selectedSailor.drunkness >= 50)
                sound = "Medium";
            else if (selectedSailor.drunkness >= -10)
                sound = "Neutral";
            else if (selectedSailor.drunkness >= -50)
                sound = "Low";
            else
                sound = "Farts";
            SoundManager.instance.PlaySound(sound, false, selectedSailor.transform.position);

        }
    }

    public void OnObjectHit(Furniture objectHit) {
        if (!objectHit.isPlaced) {
            return;
        }

        objectHit.OnSelected();

        if (selectedSailor != null) {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

            if (!objectHit.isBuilt && selectedOrder != SailorOrderType.DESTROY) { // if the objet isn't built, BUILD takes priority over REPAIR and UPGRADE (but not DESTROY)
                selectedSailor.GiveOrder(SailorOrderType.BUILD, objectHit.sailorTarget.position, objectHit);
            }
            else if (selectedOrder == SailorOrderType.BUILD) { //if object is built but we still try to build it, the default order is aplied
                selectedSailor.GiveOrder(SailorOrderType.USE, objectHit.sailorTarget.position, objectHit);
            }
            else if (CanGiveOrder(objectHit)) {
                selectedSailor.GiveOrder(selectedOrder, objectHit.sailorTarget.position, objectHit);
            }
        }
        else {
            UI_Manager.instance.OpenObjectStatsPane(objectHit);
        }
    }

    private bool CanGiveOrder(Furniture objectHit) {
        if (!objectHit.isIdle && objectHit.currentSailor != selectedSailor) {
            InfoMessagesList.instance.AddMessage("FurnitureUsed");
            return false;
        }

        switch (selectedOrder) {
            case SailorOrderType.REPAIR:
                if(objectHit.life >= objectHit.maxLife) 
                    InfoMessagesList.instance.AddMessage("FurnitureFullLife");
                return objectHit.life < objectHit.maxLife;

            case SailorOrderType.UPGRADE:
                if (objectHit.currentUpgradeLvl > objectHit.maxUpgradeNb)
                    InfoMessagesList.instance.AddMessage("MaxUpgradeNb");
                if (RessourcesManager.instance.moneyNb < objectHit.moneyCost * objectHit.costUpgradeMutiplier)
                    InfoMessagesList.instance.AddMessage("NotEnoughMoney");

                return objectHit.currentUpgradeLvl < objectHit.maxUpgradeNb && RessourcesManager.instance.moneyNb >= objectHit.moneyCost * objectHit.costUpgradeMutiplier;

            default:
                return true;
        }
    }

    public void StartMusicCheck() {
        StartCoroutine(MusicCheck());
    }

    IEnumerator MusicCheck() {
        yield return new WaitForSeconds(1);

        float oldGeneralDrunkness = 0;

        while (true) {
            float generalDrunkness = 0;
            for (int i = 0; i < sailorsList.Count; i++) {
                generalDrunkness += sailorsList[i].drunkness;
            }
            generalDrunkness /= sailorsList.Count;

            string soundToPlay = "";

            if (generalDrunkness > 50 && oldGeneralDrunkness < 50 && oldGeneralDrunkness > -50) {
                soundToPlay = "PT1/PT3";
            }
            else if (generalDrunkness < 50 && oldGeneralDrunkness > 50) {
                soundToPlay = "PT3/PT1";
            }
            else if (generalDrunkness < -50 && oldGeneralDrunkness < 50 && oldGeneralDrunkness > -50) {
                soundToPlay = "PT1/PT2";
            }
            else if (generalDrunkness > -50 && oldGeneralDrunkness < -50) {
                soundToPlay = "PT2/PT1";
            }

            if (soundToPlay != "")
                SoundManager.instance.PlaySound(soundToPlay, true);

            oldGeneralDrunkness = generalDrunkness;
            yield return new WaitForSeconds(5);
        }
    }
}
