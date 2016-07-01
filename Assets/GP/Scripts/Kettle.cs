using UnityEngine;
using System.Collections;

public class Kettle : MonoBehaviour, ObjectInterface {
    public float beerProductionRate;
    public float productionUpgradeMultiplier;

    public void OnBuilded() {
        //Maybe reputatiton+
        RessourcesManager.instance.IncreaseBeerProductionRate(beerProductionRate);
        TutoManager.instance.SetState("isKeetleConstructed", true);
    }

    public void OnBroken() { }

    public void OnUpgraded() {
        RessourcesManager.instance.IncreaseBeerProductionRate(beerProductionRate * productionUpgradeMultiplier - beerProductionRate);
        beerProductionRate *= productionUpgradeMultiplier; //to ensure that the destroy will remove all the capacity
    }

    public void OnDestroyed() {
        RessourcesManager.instance.IncreaseBeerProductionRate(-beerProductionRate);
    }

    public void OnUseBegin(Sailor sailor) { }

    public void OnUseEnd() {}

    public void OnRepaired() {}
}
