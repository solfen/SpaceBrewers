using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EventUIManager : MonoBehaviour {
    public static EventUIManager instance;
    public Transform normalContentPannel;
    public Transform importantContentPannel;
    public Button normalBtn;
    public Button importantBtn;
    public Text normalEventCount;
    public Text urgentEventCount;
    public GameObject messagePrefab;
    public List<Font> alienFonts = new List<Font>();

    private List<EventUI> eventsUINormal = new List<EventUI>();
    private List<EventUI> eventsUIUrgent = new List<EventUI>();

    void Awake() {
        instance = this;
    }

    public void AddEventMessage(int eventIndex, bool isImportant) {
        GameObject eventUI = Instantiate(messagePrefab) as GameObject;
        EventUI script = eventUI.GetComponent<EventUI>();
        script.Init(eventIndex);
        eventUI.transform.SetParent(isImportant ? importantContentPannel : normalContentPannel , false);

        if (isImportant) {
            eventsUIUrgent.Add(script);
        }
        else {
            eventsUINormal.Add(script);
        }

        UpdateEventCount();
    }

    public void OpenTab(bool isImportantTab) {
        normalBtn.interactable = isImportantTab;
        importantBtn.interactable = !isImportantTab;
        normalContentPannel.parent.gameObject.SetActive(!isImportantTab);
        importantContentPannel.parent.gameObject.SetActive(isImportantTab);
    }

    public void RemoveEventUI(EventUI eventUI) {
        if (eventsUINormal.Contains(eventUI))
            eventsUINormal.Remove(eventUI);
        else
            eventsUIUrgent.Remove(eventUI);
        
        EventsManager.instance.EndEvent(eventUI.eventIndex);
        RessourcesManager.instance.SetEventChoice(-1);
        Destroy(eventUI.gameObject);
        UpdateEventCount();
    }

    private void UpdateEventCount() {
        normalEventCount.text = eventsUINormal.Count.ToString();
        urgentEventCount.text = eventsUIUrgent.Count.ToString();
    }
}

