using UnityEngine;
using System.Collections;

public class SetLang : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SmartLocalization.LanguageManager.Instance.ChangeLanguage(PlayerPrefs.GetString("Lang", "en"));
	}
}
