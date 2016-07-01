using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SailorsOrdersCheat : MonoBehaviour {

    public SailorOrderType type;
    public int selectedSailorIndex = 0;
    public int selectedOrderIndex = 0;
    public int sailorNb;

    public Dropdown sailorSelect;
    public Dropdown orderSelect;
    public Text drunknessText;
	// Use this for initialization
	void Start () {
        string[] orderTypes = System.Enum.GetNames(typeof(SailorOrderType));
        for(int i = 0; i < orderTypes.Length; i++ ) {
            if (SailorManager.instance.sailorsConfig.sailorEvents.Exists(e => e.orderType == (SailorOrderType)i)) {
                orderSelect.options.Add(new Dropdown.OptionData());
                orderSelect.options[orderSelect.options.Count-1].text = orderTypes[i];
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (sailorSelect.options.Count != SailorManager.instance.sailorsList.Count) {
            sailorSelect.options = new List<Dropdown.OptionData>();

            for (int i = 0; i < SailorManager.instance.sailorsList.Count; i++) {
                sailorSelect.options.Add(new Dropdown.OptionData());
                sailorSelect.options[i].text = SailorManager.instance.sailorsList[i].sailorName;
            }
        }
	}

    public void OnSailorSelect(int index) {
        selectedSailorIndex = index;
    }

    public void OnOrderSelect(int index) {
        selectedOrderIndex = index;
    }

    public void GiveOrderToSailor() {
        SailorManager.instance.sailorsList[selectedSailorIndex].GiveOrder((SailorOrderType)System.Enum.Parse(typeof(SailorOrderType), orderSelect.options[selectedOrderIndex].text, true));
    }

    public void ResetSailor() {
        SailorManager.instance.sailorsList[selectedSailorIndex].ResetSailorState();
    }

    public void ToggleFreeWill(bool isChecked) {
        if (isChecked) {
            SailorManager.instance.sailorsList[selectedSailorIndex].StartCoroutine("EventsChecker");
            Debug.Log("HEY");
        }
        else {
            SailorManager.instance.sailorsList[selectedSailorIndex].StopCoroutine("EventsChecker");
        }

    }

    public void ChangeDrunkness(float drunkness) {
        drunknessText.text = drunkness.ToString();
        SailorManager.instance.sailorsList[selectedSailorIndex].drunkness = drunkness;
    }

    public void Genocide() {
        for (int i = 0; i < SailorManager.instance.sailorsList.Count; i++) {
            SailorManager.instance.sailorsList[i].GiveOrder(SailorOrderType.DIE);
        }
    }
}
