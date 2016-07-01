using UnityEngine;
using System.Collections;

public class CommunicationPost : MonoBehaviour, ObjectInterface {

    public void OnBuilded() {
        RessourcesManager.instance.nbOfCommPostConstructed++;
    }
    public void OnUpgraded() { }

    public void OnBroken() { }
    public void OnDestroyed() {
        RessourcesManager.instance.nbOfCommPostConstructed--;
    }

    public void OnUseBegin(Sailor sailor) {
        //TODO : appear animation
    }

    public void OnUseEnd() {
        //TODO : disappear animation
    }

    public void OnRepaired() { }
}
