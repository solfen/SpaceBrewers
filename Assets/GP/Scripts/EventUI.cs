using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EventUI : MonoBehaviour {
    public GameObject choicePrefab;
    public Transform content;
    public Transform choices;
    public Button quitBtn;
    public Text title;
    public Text description;
    public Text sender;
    public Image icon;
    [HideInInspector]
    public int eventIndex;

    private Event associatedEvent;
    private SmartLocalization.LanguageManager localization;
    private UIAnimatorVerticalLayout animator;
    private RectTransform choicesTransform;
    private RectTransform descriptionTransform;
    private List<GameObject> availableChoices = new List<GameObject>();
    private bool isOpen = false;
    private bool isAlien = false;
    private Font alienFont;

    public void Init(int pEventIndex) {
        localization = SmartLocalization.LanguageManager.Instance;
        associatedEvent = EventsManager.instance.events[pEventIndex];
        eventIndex = pEventIndex;
        animator = GetComponent<UIAnimatorVerticalLayout>();
        choicesTransform = choices.GetComponent<RectTransform>();
        descriptionTransform = description.GetComponent<RectTransform>();
        quitBtn.gameObject.SetActive(associatedEvent.isKillable);

        title.text = localization.GetTextValue(associatedEvent.popUpTitle);
        sender.text = localization.GetTextValue("MES_FROM") + " " + associatedEvent.popUpSender;
        icon.sprite = associatedEvent.popUpIcon;
        description.text = localization.GetTextValue(associatedEvent.popUpDescription);

        if (Random.Range(0, 100) < associatedEvent.alienWrittenProbability / (RessourcesManager.instance.nbOfTranslatorConstructed + 1)) {
            alienFont = EventUIManager.instance.alienFonts[Random.Range(0, EventUIManager.instance.alienFonts.Count)];
            title.font = alienFont;
            description.font = alienFont;
            isAlien = true;
        }

        StartCoroutine(NextFrame(true)); //need to do the size calculation at next frame because it's at 0 right now
        StartCoroutine(KillEvent());
    }

    public void Toggle() {
        isOpen = !isOpen;
        if (isOpen) {
            UIEventChoice[] currentChoices = EventsManager.instance.GetEventChoices(eventIndex);

            for (int i = 0; i < currentChoices.Length; i++) {
                if (associatedEvent.isLockedChoicesHidden && currentChoices[i].isLocked) {
                    continue;
                }

                GameObject choice =  i < availableChoices.Count ? availableChoices[i] : Instantiate(choicePrefab) as GameObject;
                Button btn = choice.GetComponent<Button>();
                int choiceIndex = i;
                choice.GetComponentInChildren<Text>().text = localization.GetTextValue(currentChoices[i].text);
                choice.transform.SetParent(choicesTransform, false);
                if (currentChoices[i].text != "MES_NO_COMM_POST") {
                    btn.onClick.AddListener(delegate { MakeChoice(choiceIndex); });
                    if (isAlien) {
                        choice.GetComponentInChildren<Text>().font = alienFont;
                    }
                }

                if (currentChoices[i].isLocked) {
                    btn.interactable = false;
                }
                else {
                    btn.interactable = true;
                }

                if(!availableChoices.Contains(choice)) {
                    availableChoices.Add(choice);
                }
            }

            for(int i = currentChoices.Length; i < availableChoices.Count; i++) {
                Destroy(availableChoices[i]);
            }

            StartCoroutine(NextFrame(false));
        }

        animator.StartAnim("expand");
    }

    public void Delete() {
        StopAllCoroutines();
        EventUIManager.instance.RemoveEventUI(this);
    }

    private void MakeChoice(int choiceIndex) {
        animator.StartAnim("expand", delegate { ChoicesConsequencies(choiceIndex); });
    }

    private void ChoicesConsequencies(int choiceIndex) {
        RessourcesManager.instance.SetEventChoice(choiceIndex);
        Delete();
    }

    IEnumerator NextFrame(bool isFirstTime) {
        yield return null;
        CalculateSize();

        if (isFirstTime && associatedEvent.isModal) {
            GetComponent<Button>().onClick.Invoke();
        }
    }

    IEnumerator KillEvent() {
        yield return new WaitForSeconds(associatedEvent.peremptionTime);
        Delete();
    }

    private void CalculateSize() {
        CustomVerticalListTools.SetElemPosUnderPreviousElem(choicesTransform, descriptionTransform, 20);
        float height = CustomVerticalListTools.CalculateHeight(content);
        animator.animations[0].endPreferedSize.y = height;
    }
}
