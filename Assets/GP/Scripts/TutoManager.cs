using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TutorialPart {
    public string name;
    public string text = null;
    public Sprite personaImage = null;
    public string animation = null;
    public GameObject focus = null;
    public List<string> endConditions = new List<string>();
    public bool needUserInput = false;
    public float endDelay = 0;
    public float moneyReward = 0;
}

[RequireComponent(typeof(UIAnimator))]
public class TutoManager : MonoBehaviour {
    public static TutoManager instance;

    [HideInInspector]
    public bool isHappening = false;

    [Header("bools")]
    public bool isEnabled = false;
    public Dictionary<string, bool> tutoStates = new Dictionary<string, bool>() {
        {"isFirstSailorSelection", false},
        {"isFirstBuildIconSelected", false},
        {"isBeerCategorySelected", false},
        {"isKettleSelected", false},
        {"isKettlePlaced", false},
        {"isKeetleConstructed", false},
        {"isCommandPostConstructed", false},
        {"isCommandPostOpen", false},
        {"isSectorSelected", false},
        {"isMissionStarted", false},
        {"isCommandPostClosed", false}
    };

    [Header("Time vars")]
    public float textDelayAfterAnim = 0.25f;

    [Header("GameObjects")]
    public AutoTyper typer;
    public Image persona;

    [Header("Config")]
    public List<TutorialPart> tutoList = new List<TutorialPart>();
    private UIAnimator anim;
    private int currentPopUp = 0;

    void Awake() {
        instance = this;
        anim = GetComponent<UIAnimator>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Delete)) {
            if (RessourcesManager.instance.moneyNb == 0) {
                RessourcesManager.instance.AddMoney(tutoList[4].moneyReward);
            }

            EndTutorial();
        }
    }

    public void StartTuto() {
        if (isEnabled) {
            isHappening = true;
            StartCoroutine(Tutorial());
            tutoList[4].moneyReward = ReflectionUtils.GenerateRandomFromRewardString(FamiliesManager.instance.playerFamilyTemplate.startMoney);
            RessourcesManager.instance.moneyNb = 0;
            SailorManager.instance.drunknessRateMultiplier = 0;
        }
    }

    private void EndTutorial() {
        StopAllCoroutines();
        isHappening = false;
        gameObject.SetActive(false);
        EventsManager.instance.StartEvents();
        SoundManager.instance.StopSound("Robot Voices 2D");
        SailorManager.instance.drunknessRateMultiplier = 1;
        RessourcesManager.instance.Init();
    }

    public void SetState(string key, bool state) {
        if (tutoStates.ContainsKey(key)) {
            tutoStates[key] = state;
        }
        else {
            Debug.LogError("no such state: " + key);
        }
    }

    //those three methods exists because UI events can only have one parameter
    public void SetStateToTrue(string state) {
        if (tutoStates.ContainsKey(state)) {
            tutoStates[state] = true;
        }
        else {
            Debug.LogError("no such state: " + state);
        }
    }

    public void SetStateToFalse(string state) {
        if (tutoStates.ContainsKey(state)) {
            tutoStates[state] = false;
        }
        else {
            Debug.LogError("no such state: " + state);
        }
    }
    public void ToggleState(string state) {
        if (tutoStates.ContainsKey(state)) {
            tutoStates[state] = !tutoStates[state];
        }
        else {
            Debug.LogError("no such state: " + state);
        }
    }

    IEnumerator Tutorial() {
        while (currentPopUp < tutoList.Count) {
            RessourcesManager.instance.AddMoney(tutoList[currentPopUp].moneyReward);

            yield return StartCoroutine(PopUp(currentPopUp));

            while (!CanEnd()) {
                yield return null;
            }
            yield return new WaitForSeconds(tutoList[currentPopUp].endDelay);

            currentPopUp++;
        }

        EndTutorial();
    }

    IEnumerator PopUp(int index) {
        persona.sprite = tutoList[index].personaImage != null ? tutoList[index].personaImage : persona.sprite;

        if (tutoList[index].animation != "") {
            typer.text.text = "";
            anim.StartAnim(tutoList[index].animation);
            yield return new WaitForSeconds(anim.animationsDictionary[tutoList[index].animation].animDuration + textDelayAfterAnim);
        }

        if (tutoList[index].focus != null) {
            tutoList[index].focus.SetActive(true);
        }

        if (index > 0 && tutoList[index - 1].focus != null)
            tutoList[index - 1].focus.SetActive(false);

        yield return typer.StartCoroutine("TypeRoutine", SmartLocalization.LanguageManager.Instance.GetTextValue(tutoList[index].text));
    }

    private bool CanEnd() {
        for (int i = 0; i < tutoList[currentPopUp].endConditions.Count; i++) {
            if (!tutoStates[tutoList[currentPopUp].endConditions[i]]) {
                return false;
            }
        }

        if (tutoList[currentPopUp].needUserInput && !Input.GetMouseButtonDown(0)) {
            return false;
        }

        return true;
    }

}