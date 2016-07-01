using UnityEngine;
using System.Collections;

public class BeerKeg : MonoBehaviour, ObjectInterface {
    public float capacity;
    public float capacityUpgradeMultiplier;

    public void OnBuilded() {
        RessourcesManager.instance.IncreaseBeerMaxNb(capacity);
    }

    public void OnBroken() { }

    public void OnUpgraded() {
        RessourcesManager.instance.IncreaseBeerMaxNb(capacity * capacityUpgradeMultiplier - capacity);
        capacity *= capacityUpgradeMultiplier; //to ensure that the destroy will remove all the capacity
    }

    public void OnDestroyed() {
        RessourcesManager.instance.IncreaseBeerMaxNb(-capacity);
    }

    public void OnRepaired() {}
    public void OnUseBegin(Sailor sailor) {}
    public void OnUseEnd() {}
}
