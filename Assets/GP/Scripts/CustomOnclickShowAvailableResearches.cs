using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CustomOnclickShowAvailableResearches : MonoBehaviour {

    public ResearchType researchType;
    public ResearchMenuScrollList researchMenuScrollList;

    private void Start() {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { researchMenuScrollList.ShowAvailableResearches(researchType); });
    }
}
