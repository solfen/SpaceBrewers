using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FamiliesMenuScrollList : MonoBehaviour {

    public Sprite lockedSigil;
    public Image sigil;
    public Text familyName;
    public Text startBeerStat;
    public Text startMoneyStat;
    public Text startReputationStat;
    public Text history;

    public Button startGameButton;

    private int selectIndex = 0;
    private int familyIndex = 0;
    private PlayableFamily familyRef;
    private SmartLocalization.LanguageManager localization;

    void Start() {
        localization = SmartLocalization.LanguageManager.Instance;
        familyRef = FamiliesManager.instance.playableFamilies[0];
        ShowFamily();
    }

    public void ShowNextFamily(int dir) {
        selectIndex = (selectIndex + dir) % FamiliesManager.instance.playableFamilies.Count;
        familyIndex = Mathf.Abs(selectIndex);
        ShowFamily();
    }

    public void ShowFamily() {
        if (FamiliesManager.instance.playableFamilies[familyIndex].isUnlocked) {
            PlayableFamily newFamily = FamiliesManager.instance.playableFamilies[familyIndex];
            familyName.text = localization.GetTextValue(newFamily.name);
            sigil.sprite = newFamily.sigil;

            startBeerStat.text = localization.GetTextValue("UI_FAM_PANE_STATS_BEER") + GetStatSymbol(ReflectionUtils.GenerateRandomFromRewardString(newFamily.startBeer) / ReflectionUtils.GenerateRandomFromRewardString(familyRef.startBeer));
            startMoneyStat.text = localization.GetTextValue("UI_FAM_PANE_STATS_MONEY") + GetStatSymbol(ReflectionUtils.GenerateRandomFromRewardString(newFamily.startMoney) / ReflectionUtils.GenerateRandomFromRewardString(familyRef.startMoney));
            startReputationStat.text = localization.GetTextValue("UI_FAM_PANE_STATS_REPUT") + GetStatSymbol(ReflectionUtils.GenerateRandomFromRewardString(newFamily.reputationPercent) / ReflectionUtils.GenerateRandomFromRewardString(familyRef.reputationPercent));
            history.text = localization.GetTextValue(newFamily.history);

            startGameButton.interactable = true;
        }
        else {
            familyName.text = localization.GetTextValue("FAMILY_PLAY_NAME_LOCKED");
            sigil.sprite = lockedSigil;

            startBeerStat.text = localization.GetTextValue("UI_FAM_PANE_STATS_BEER") + " ???";
            startMoneyStat.text = localization.GetTextValue("UI_FAM_PANE_STATS_MONEY") + " ???";
            startReputationStat.text = localization.GetTextValue("UI_FAM_PANE_STATS_REPUT") + " ???";
            history.text = localization.GetTextValue("???");

            startGameButton.interactable = false;
        }
    }

    public void SelectFamily() {
        FamiliesManager.instance.SelectPlayableFamily(familyIndex);
    }

    private string GetStatSymbol(float value) {
        if(value > 3) {
            return " <color=\"#fFFT\">+ + +</color>";
        }
        if(value > 2) {
            return " <color=\"#fFFT\">+ +</color>";
        }
        if(value > 1.5) {
            return " <color=\"#fFFT\">+</color>";
        }

        if(value < 0.33) {
            return " <color=\"#fFFT\">- - -</color>";
        }
        if(value < 0.5) {
            return " <color=\"#fFFT\">- -</color>";
        }
        if(value < 0.65) {
            return " <color=\"#fFFT\">-</color>";
        }

        return " <color=\"#fFFT\">~ =</color>";
    }
}
