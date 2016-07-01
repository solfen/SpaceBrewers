using UnityEngine;
using System.Collections;

public class Antenna : MonoBehaviour, ObjectInterface {

    public void OnBuilded() {
        RessourcesManager.instance.nbOfAntenaConstructed++;
    }

    public void OnUpgraded() {

    }

    public void OnBroken() { }

    public void OnDestroyed() {
        RessourcesManager.instance.nbOfAntenaConstructed--;
    }

    public void OnRepaired() { }
    public void OnUseBegin(Sailor sailor) { }
    public void OnUseEnd() { }
}
