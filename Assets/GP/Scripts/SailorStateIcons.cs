using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SailorStateIcons : MonoBehaviour {
    public static SailorStateIcons instance;

    public GameObject sailorIconPrefab;
    private Dictionary<Sailor, SailorIcon> sailorsIcons = new Dictionary<Sailor, SailorIcon>();

    void Awake() {
        instance = this;
    }

    public void SelectFeedback(Sailor sailor) {
        DesactivateAllSelectFeedback();
        sailorsIcons[sailor].selectFeedback.SetActive(true);
    }

    public void CreateIcon(Sailor sailor) {
       GameObject obj = Instantiate(sailorIconPrefab) as GameObject;
       SailorIcon icon = obj.GetComponent<SailorIcon>();
       obj.transform.SetParent(transform, false);
       icon.Init(sailor);
       sailorsIcons.Add(sailor, icon);
    }

    public void DesactivateAllSelectFeedback() {
        foreach (SailorIcon icon in sailorsIcons.Values) {
            icon.selectFeedback.SetActive(false);
        }
    }

    public void DestroyIcon(Sailor sailor) {
        Destroy(sailorsIcons[sailor].gameObject);
        sailorsIcons.Remove(sailor);
    }
}
