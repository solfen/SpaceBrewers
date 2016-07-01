using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ResearchMenuScrollList : MonoBehaviour {

    public GameObject researchPrefab;
    public Transform contentPannel;
    public Image mainIcon;
    public Text mainName;
    public Text mainCost;
    public Text mainDuration;
    public Text mainDescription;
    public Slider progressBar;
    public Button startBtn;
    public Button stopBtn;
    public float refreshSliderRate;

    private Dictionary<ResearchType, Dictionary<string, GameObject>> researchesGameObjects = new Dictionary<ResearchType, Dictionary<string, GameObject>>();
    private ResearchType currentResearchTab;

    void Start() {
        researchesGameObjects.Add(ResearchType.BASE, new Dictionary<string, GameObject>());
        researchesGameObjects.Add(ResearchType.BEER, new Dictionary<string, GameObject>());
        researchesGameObjects.Add(ResearchType.MERCENARIES, new Dictionary<string, GameObject>());
        researchesGameObjects.Add(ResearchType.OBJECTS, new Dictionary<string, GameObject>());
        researchesGameObjects.Add(ResearchType.SAILORS, new Dictionary<string, GameObject>());
    }

    public void ShowAvailableResearches(ResearchType type) {
        EmptyResearchList();
        currentResearchTab = type;
        ResearchManager.instance.GenerateResearchList(type);

        foreach (KeyValuePair<string, Research> entry in ResearchManager.instance.availableResearches[type]) {
            if (!researchesGameObjects[type].ContainsKey(entry.Key)) {
                GameObject instance = Instantiate(researchPrefab) as GameObject;
                instance.transform.SetParent(contentPannel, false);
                researchesGameObjects[type].Add(entry.Key, instance);
            }

            string localName = entry.Key;

            researchesGameObjects[type][entry.Key].transform.GetComponent<Button>().onClick.AddListener(delegate { SelectResearch(type, localName); });
            researchesGameObjects[type][entry.Key].transform.FindChild("Icon").GetComponent<Image>().sprite = entry.Value.templateRef.icon;
            researchesGameObjects[type][entry.Key].transform.FindChild("Title").GetComponent<Text>().text = entry.Value.name;
            researchesGameObjects[type][entry.Key].transform.FindChild("Summary").GetComponent<Text>().text = entry.Value.templateRef.summary;

            researchesGameObjects[type][entry.Key].SetActive(true);
        }

        //Can't delete while in foreach
        List<string> keysToDelete = new List<string>();
        if (ResearchManager.instance.availableResearches[type].Count != researchesGameObjects[type].Count) {
            foreach (KeyValuePair<string, GameObject> entry in researchesGameObjects[type]) {
                if (!ResearchManager.instance.availableResearches[type].ContainsKey(entry.Key)) {
                    keysToDelete.Add(entry.Key);
                    Destroy(entry.Value);
                }
            }

            for (int i = 0; i < keysToDelete.Count; i++) {
                researchesGameObjects[type].Remove(keysToDelete[i]);
            }
        }
    }

    public void SelectResearch(ResearchType type, string name) {
        StopAllCoroutines();

        Research research = ResearchManager.instance.availableResearches[type][name];
        IEnumerator routine = UpdateResearch(type, name);

        mainIcon.sprite = research.templateRef.icon;
        mainName.text = research.name;
        mainCost.text = research.cost + "Bc";
        mainDescription.text = research.templateRef.description;

        UpdateTimeLeft(research.timeLeft);
        UpdatePercentBar(ResearchManager.instance.availableResearches[type][name].completionPercent);

        SoundManager.instance.PlaySound("Type");

        if (research.cost > RessourcesManager.instance.moneyNb) {
            startBtn.interactable = false;
            stopBtn.interactable = false;
            return;
        }

        startBtn.interactable = true;
        stopBtn.interactable = true;

        stopBtn.onClick.RemoveAllListeners();
        stopBtn.onClick.AddListener(delegate { startBtn.gameObject.SetActive(true); stopBtn.gameObject.SetActive(false); });
        stopBtn.onClick.AddListener(delegate { ResearchManager.instance.StopResearch(); StopCoroutine(routine); });

        startBtn.onClick.RemoveAllListeners();
        startBtn.onClick.AddListener(delegate { startBtn.gameObject.SetActive(false); stopBtn.gameObject.SetActive(true); SoundManager.instance.PlaySound("Activate Research"); });
        startBtn.gameObject.SetActive(true);
        stopBtn.gameObject.SetActive(false);


        if (ResearchManager.instance.currentResearchName == name) {
            startBtn.onClick.AddListener(delegate { ResearchManager.instance.StartResearch(type, name); StartCoroutine(routine); });
            startBtn.gameObject.SetActive(false);
            stopBtn.gameObject.SetActive(true);
            StartCoroutine(routine);
        }
        else {
            startBtn.onClick.AddListener(delegate { ResearchManager.instance.StopResearch(); ResearchManager.instance.StartResearch(type, name); StartCoroutine(routine); });
        }
    }

    IEnumerator UpdateResearch(ResearchType type, string name) {
        while (true) {
            if (ResearchManager.instance.currentResearchName == null) {
                if(currentResearchTab != null) {
                    ShowAvailableResearches(currentResearchTab);
                }
                break;
            }

            UpdateTimeLeft(ResearchManager.instance.availableResearches[type][name].timeLeft);
            UpdatePercentBar(ResearchManager.instance.availableResearches[type][name].completionPercent);

            yield return new WaitForSeconds(refreshSliderRate);
        }

        UpdateTimeLeft(0);
        UpdatePercentBar(100);
        startBtn.gameObject.SetActive(false);
        stopBtn.gameObject.SetActive(false);
        SoundManager.instance.StopSound("Activate Research");
    }

    private void UpdatePercentBar(float value) {
        progressBar.value = value / 100;
        progressBar.transform.FindChild("Text").GetComponent<Text>().text = "Progress: " + ((int)value) + "%";
    }

    private void UpdateTimeLeft(float time) {
        mainDuration.text = ((int)time / 60) + "m" + ":" + ((int)time % 60) + "s";
    }

    private void EmptyResearchList() {
        foreach (Transform t in contentPannel) {
            t.gameObject.SetActive(false);
        }
    }
}
