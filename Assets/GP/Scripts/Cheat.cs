using UnityEngine;
using System.Collections;

public class Cheat : MonoBehaviour {
    public UIAnimator CheatPannel;
    public UIAnimator CheatSailorOrder;
    private bool isFrench = false;

	void Update () {
        if (Input.GetButtonDown("Cheat")) {
            CheatPannel.StartAnim("openSlide");
        }
        if (Input.GetButtonDown("CheatSailorOrder")) {
            CheatSailorOrder.StartAnim("openSlide");
        }
        if (Input.GetKeyDown(KeyCode.T)) {
            string lang = isFrench ? "en" : "fr";
            isFrench = !isFrench;
            SmartLocalization.LanguageManager.Instance.ChangeLanguage(lang);
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
	}
}
