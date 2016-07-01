using UnityEngine;
using System.Collections;

public class Detox : MonoBehaviour, ObjectInterface {

    public float speedUndrunkMultiplier = 2;
    public Transform benchParent;
    private Sailor currentSailor;

    public void OnBuilded() {}

    public void OnUpgraded() {}

    public void OnBroken() {
        if (currentSailor != null) {
            OnUseEnd();
            currentSailor.GiveOrder(SailorOrderType.GO_DRINK);
        }
    }

    public void OnDestroyed() {}

    public void OnRepaired() { }

    public void OnUseBegin(Sailor sailor) {
        currentSailor = sailor;
        StartCoroutine(FallOnCouch());
    }

    IEnumerator FallOnCouch() {
        currentSailor.anim.SetBool("Build", false);
        yield return currentSailor.StartCoroutine("LookTowardTarget", currentSailor.currentOrder.furnitureTarget.sailorTarget.rotation * Quaternion.Euler(0,180,0));
        currentSailor.anim.SetBool("Coma", true);
        yield return new WaitForSeconds(1.6f);
        currentSailor.skeleton.transform.SetParent(benchParent, true);
        currentSailor.skeleton.transform.localPosition = new Vector3(-0.22f, 0.7f, -1.452f);
        SoundManager.instance.PlaySound("Fall Couch", false, transform.position);
        currentSailor.speedUndrunkMultiplier = speedUndrunkMultiplier;
    }

    public void OnUseEnd() {
        if (currentSailor != null) {
            currentSailor.anim.SetBool("Coma", false);
            currentSailor.speedUndrunkMultiplier = 1;
        }
    }
}
