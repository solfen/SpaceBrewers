using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class OptionsPane : MonoBehaviour {

    public Slider volumeSlider;
    public Dropdown languageSelect;
    public string[] languageDropdown;
    public string[] langIndexes;

    void Start() {
        GenerateDropdown();
        volumeSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1);
    }

    void GenerateDropdown() {
        languageSelect.options = new List<Dropdown.OptionData>();
        for (int i = 0; i < languageDropdown.Length; i++) {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = SmartLocalization.LanguageManager.Instance.GetTextValue(languageDropdown[i]);
            languageSelect.options.Add(option);
        }
    }

    public void SelectLanguage(int index) {
        SmartLocalization.LanguageManager.Instance.ChangeLanguage(langIndexes[index]);
        PlayerPrefs.SetString("Lang", langIndexes[index]);
        GenerateDropdown();
    }

    public void SaveVolume(float volume) {
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }

}
