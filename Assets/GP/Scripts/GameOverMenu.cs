using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using System.Collections;
using System.Collections.Generic;

public enum GameDeathReasons {
    NOMONEY,
    NOSAILORS
}

[RequireComponent(typeof(UIAnimator2))]
public class GameOverMenu : MonoBehaviour {
    public static GameOverMenu instance;

    public Text quote;
    public Text score;
    public Text explaination;

    public BlurOptimized blur;
    public ColorCorrectionCurves colorCurves;

    public List<string> quotes = new List<string>();
    public Dictionary<GameDeathReasons, string> eplainations = new Dictionary<GameDeathReasons, string>() {
        {GameDeathReasons.NOMONEY, "GAMEOVER_MSG_NOMONEY"},
        {GameDeathReasons.NOSAILORS, "GAMEOVER_MSG_SAILORS"}
    };

    private UIAnimator2 animator;

    void Awake() {
        instance = this;
        animator = GetComponent<UIAnimator2>();
    }

    public void Pop(GameDeathReasons reason) {
        blur.enabled = true;
        colorCurves.enabled = true;
        quote.text = SmartLocalization.LanguageManager.Instance.GetTextValue(quotes[Random.Range(0, quotes.Count)]);
        score.text = "Score: " + (int)RessourcesManager.instance.score;
        explaination.text = SmartLocalization.LanguageManager.Instance.GetTextValue(eplainations[reason]);
        animator.StartAnim("openSlide");
        GameManager.instance.GetComponent<LevelsManager>().LoadLevel(1);
    }
}
