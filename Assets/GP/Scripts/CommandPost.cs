using UnityEngine;
using System.Collections;

public class CommandPost : MonoBehaviour, ObjectInterface {

    public void OnBuilded() {
        if (RessourcesManager.instance.nbOfComandPostConstructed == 0)
            UI_Manager.instance.ToggleCommandPost();

        TutoManager.instance.SetState("isCommandPostConstructed", true);
        RessourcesManager.instance.nbOfComandPostConstructed++;
    }
    public void OnUpgraded() {}

    public void OnBroken() { }
    public void OnDestroyed() {
        if (RessourcesManager.instance.nbOfComandPostConstructed == 1)
            UI_Manager.instance.ToggleCommandPost();

        RessourcesManager.instance.nbOfComandPostConstructed--;
    }


    public void OnUseBegin(Sailor sailor) {
        //TODO : appear animation

    }

    public void OnUseEnd() {
        //TODO : disappear animation  
    }

    public void OnRepaired() {}
}
