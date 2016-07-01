using UnityEngine;
using System.Collections;

public class ResearchPost : MonoBehaviour, ObjectInterface {

    private GameObject ObjectPopUpPaneMesh;

    void Start() {
        ObjectPopUpPaneMesh = transform.FindChild("ObjectPopUpPaneMesh").gameObject;
    }
    public void OnBuilded() { }
    public void OnUpgraded() { }
    public void OnBroken() { }
    public void OnDestroyed() { }


    public void OnUseBegin(Sailor sailor) {
        //TODO : appear animation
        ObjectPopUpPaneMesh.SetActive(true);
    }

    public void OnUseEnd() {
        //TODO : disappear animation
        ObjectPopUpPaneMesh.SetActive(false);
    }

    public void OnRepaired() { }
}
