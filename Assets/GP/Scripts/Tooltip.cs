using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    public float delay = 0;
    public Color cantAffordColor;

    private RectTransform rectTranform;
    private Text tooltipText;

	void Awake () {
        rectTranform = GetComponent<RectTransform>();
        tooltipText = rectTranform.GetChild(0).GetComponent<Text>();
	}

    public void ShowTooltip(string message) {
        tooltipText.color = Color.white;
        tooltipText.text = message;
    }

    public void CantAffordFeedback() {
        tooltipText.color = cantAffordColor;
    }

    public void ClearTooltip() {
        tooltipText.text = "";
    }
}
