using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BarmanAnimEvent {
    public string animName;
    public int probability;
}
public class Barman : MonoBehaviour {

    public Animator anim;
    public float checkInterval = 5;
    public List<BarmanAnimEvent> events = new List<BarmanAnimEvent>();

	void Start () {
        StartCoroutine(EventChecker());
	}

    IEnumerator EventChecker() {
        while (true) {
            List<int> eventsToCheck = new List<int>();
            eventsToCheck.AddRange(System.Linq.Enumerable.Range(0, events.Count)); // so that we have a list like [0,1,2,3 ... count-1]

            while (eventsToCheck.Count > 0) {
                int i = eventsToCheck[Random.Range(0, eventsToCheck.Count)];

                if (Random.Range(0,100) < events[i].probability) {
                    anim.SetTrigger(events[i].animName);
                    break;
                }

                eventsToCheck.Remove(i);
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }
}
