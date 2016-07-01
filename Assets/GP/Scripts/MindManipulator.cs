using UnityEngine;
using System.Collections;

public class MindManipulator : MonoBehaviour, ObjectInterface {

    public void OnBuilded() {
        RessourcesManager.instance.nbOfMindManipulatorConstructed++;
    }

    public void OnUpgraded() {

    }

    public void OnBroken() { }

    public void OnDestroyed() {
        RessourcesManager.instance.nbOfMindManipulatorConstructed--;
    }

    public void OnRepaired() { }
    public void OnUseBegin(Sailor sailor) { }
    public void OnUseEnd() { }
}
