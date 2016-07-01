using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EventsManager : MonoBehaviour {
    public static EventsManager instance;
    public List<Event> events;
    public float eventsCheckInterval;

    private List<int> currentEvents = new List<int>();
    private List<int> happendEvents = new List<int>();

    void Awake() {
        instance = this;
    }

    public void StartEvents() {
        StartCoroutine("EventGenrator");
    }

    private bool CanEventHappened(int index, bool canHappendOnlyOnce, int probability) {
        return !currentEvents.Contains(index)
               && !(canHappendOnlyOnce && happendEvents.Contains(index))
               && Random.Range(0, 100) < probability;
    }

    IEnumerator EventGenrator() {
        yield return new WaitForSeconds(eventsCheckInterval);

        while(true) {
            List<int> eventsToCheck = new List<int>(); 
            eventsToCheck.AddRange(System.Linq.Enumerable.Range(0, events.Count)); // so that we have a list like [0,1,2,3 ... count-1]

            while(eventsToCheck.Count > 0) {
                int i = eventsToCheck[Random.Range(0, eventsToCheck.Count)];

                if (CanEventHappened(i, events[i].canHappendOnlyOnce, (int)(events[i].probability + RessourcesManager.instance.nbOfAntenaConstructed * events[i].antenaProbabilityEnhancement))) {
                    HappenedEvent(i);
                    break;   
                }

                eventsToCheck.Remove(i);
            }

            yield return new WaitForSeconds(eventsCheckInterval);
        }
    }

    private void HappenedEvent(int i, bool force = false) {
        if (i < 0 || i >= events.Count) {
            Debug.LogError("The event of index: " + i + " doesn't exist");
            return;
        }

        if (!force && events[i].hasSpawningCondition) {
            for (int j = 0; j < events[i].spawnConditions.Count; j++) {
                if (!ReflectionUtils.CheckCondition<RessourcesManager>(RessourcesManager.instance, events[i].spawnConditions[j])) {
                    return;
                }
            }
        }

        currentEvents.Add(i);
        happendEvents.Add(i);

        if (events[i].doesSpawnPrefab) {
            for (int j = 0; j < events[i].prefabsSpawn.Count; j++) {
                if (events[i].isPrefabSpawnConditional && !ReflectionUtils.CheckCondition<RessourcesManager>(RessourcesManager.instance, events[i].prefabsSpawn[j].condition)) {
                    continue;
                }
                Instantiate(events[i].prefabsSpawn[j].prefab, events[i].prefabsSpawn[j].position, Quaternion.identity);
            }
        }

        if (events[i].hasPopUp) {
            UI_Manager.instance.AddEventMessage(i);
        }
        else {
            EndEvent(i); // if the event doesn't have any popup, then we can terminate it right away. Otherwise we have to wait that the user interacts with the popUp
        }
    }

    public void EndEvent(int eventIndex) {
        if (!currentEvents.Contains(eventIndex)) {
            Debug.LogError("The event of index: " + eventIndex + " is not happening");
            return;
        }

        SoundManager.instance.PlaySound("Answer Message");

        for (int j = 0; j < events[eventIndex].rewards.Count; j++) {
            if (events[eventIndex].hasRewardCondition && !ReflectionUtils.CheckCondition<RessourcesManager>(RessourcesManager.instance, events[eventIndex].rewards[j].condition)) {
                continue;
            }

            ReflectionUtils.AddAmount<RessourcesManager>(RessourcesManager.instance, events[eventIndex].rewards[j].reward.field, ReflectionUtils.GenerateRandomFromRewardString(events[eventIndex].rewards[j].reward.amount));
        }

        if (events[eventIndex].doesSpawnSailor) {
            for (int j = 0; j < events[eventIndex].sailorsToSpawn.Count; j++) {
                if (events[eventIndex].isSailorSpawnConditional && !ReflectionUtils.CheckCondition<RessourcesManager>(RessourcesManager.instance, events[eventIndex].sailorsToSpawn[j].condition)) {
                    continue;
                }

                SailorManager.instance.SailorRH(events[eventIndex].sailorsToSpawn[j].nb);
            }
        }

        if (events[eventIndex].doesSpawnAnotherEvent) {
            if (events[eventIndex].isEventSpawnConditional) {
                for (int j = 0; j < events[eventIndex].nextEvent.Count; j++) {
                    int index = events.FindIndex(x => x.name == events[eventIndex].nextEvent[j].eventName);
                    if (CanEventHappened(index, events[index].canHappendOnlyOnce, 100) && ReflectionUtils.CheckCondition<RessourcesManager>(RessourcesManager.instance, events[eventIndex].nextEvent[j].condition)) {
                        StartCoroutine(WaitBeforeHappendEvent(index, events[eventIndex].eventSpawnDelay, events[eventIndex].doesEventBypassConditions));
                        break; // only one event can be instanciated
                    }
                }
            }
            else {
                int index = events.FindIndex(x => x.name == events[eventIndex].noConditionNextEventName);
                if (CanEventHappened(index, events[index].canHappendOnlyOnce, 100))
                    StartCoroutine(WaitBeforeHappendEvent(index, events[eventIndex].eventSpawnDelay, events[eventIndex].doesEventBypassConditions));
            }
        }

        currentEvents.Remove(eventIndex);
    }

    public UIEventChoice[] GetEventChoices(int i) {
        if (events[i].hasChoices) {
            UIEventChoice[] popupChoices = new UIEventChoice[events[i].choices.Count];

            for (int j = 0; j < events[i].choices.Count; j++) {
                popupChoices[j] = new UIEventChoice();

                if (events[i].isChoicesConditional && !ReflectionUtils.CheckCondition<RessourcesManager>(RessourcesManager.instance, events[i].choices[j].condition)) {
                    popupChoices[j].isLocked = true;
                }
                popupChoices[j].text = RessourcesManager.instance.nbOfCommPostConstructed > 0 ? events[i].choices[j].text : "MES_NO_COMM_POST";
            }

            return popupChoices;
        }

        return new UIEventChoice[0];
    }

    IEnumerator WaitBeforeHappendEvent(int i, float delay, bool force = false) {
        yield return new WaitForSeconds(delay);
        HappenedEvent(i, force);
    }
}
