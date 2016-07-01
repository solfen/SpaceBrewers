using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SailorIcon : MonoBehaviour {
    private Sailor sailorRef;
    private float refreshRate = 0.5f;

    public Image sailorIcon;
    public Image alcoolFill;
    public Image carvingFill;
    public Text nameText;
    public GameObject selectFeedback;

    IEnumerator SlowUpdate() {
        while (true) {
            alcoolFill.fillAmount = Mathf.Max(0, sailorRef.drunkness / 100);
            carvingFill.fillAmount = Mathf.Max(0, -sailorRef.drunkness / 100);
            yield return new WaitForSeconds(refreshRate);
        }
    }

    public void Onclick() {
        SailorManager.instance.SelectSailor(sailorRef);
        selectFeedback.SetActive(true);
    }

    public void Init(Sailor sailor) {
        sailorRef = sailor;
        nameText.text = sailor.sailorName;
        sailorIcon.sprite = sailor.iconSprite;

        StartCoroutine(SlowUpdate());
    }
}
