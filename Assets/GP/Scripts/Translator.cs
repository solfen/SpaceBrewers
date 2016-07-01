using UnityEngine;
using System.Collections;

public class Translator : MonoBehaviour, ObjectInterface {

    public void OnBuilded() {
        RessourcesManager.instance.nbOfTranslatorConstructed++;
    }

    public void OnUpgraded() {

    }
    public void OnBroken() { }

    public void OnDestroyed() {
        RessourcesManager.instance.nbOfTranslatorConstructed--;
    }

    public void OnRepaired() { }
    public void OnUseBegin(Sailor sailor) { }
    public void OnUseEnd() { }
}
