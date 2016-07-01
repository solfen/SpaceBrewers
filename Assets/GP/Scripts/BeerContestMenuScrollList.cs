using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BeerContestMenuScrollList : MonoBehaviour {

    private class PositionLine {
        public Image sigil;
        public Text familyName;
        public Image background;
    }

    public Text playerPosition;
    public Text playerPositionFeedBack;
    public Transform leaderBoardContainer;

    public Sprite playerPositionLineBackground;

    private UIAnimator animator;
    private List<PositionLine> positionLines = new List<PositionLine>();

    void Awake() {
        animator = GetComponent<UIAnimator>();
    }

    public void ShowBeerContest() {
        if (positionLines.Count == 0) {
            InitPositionLines();
        }

        for (int i = 0; i < FamiliesManager.instance.reputationOrderedFamilies.Count; i++) {
            positionLines[i].sigil.sprite = FamiliesManager.instance.reputationOrderedFamilies[i].sigil;
            positionLines[i].familyName.text = SmartLocalization.LanguageManager.Instance.GetTextValue(FamiliesManager.instance.reputationOrderedFamilies[i].name) + " Score: " + (int)FamiliesManager.instance.reputationOrderedFamilies[i].reputationPercent + "%";

            if (FamiliesManager.instance.reputationOrderedFamilies[i].name == FamiliesManager.instance.playerFamilyTemplate.name) {
                positionLines[i].background.overrideSprite = playerPositionLineBackground;
                playerPosition.text = (i+1).ToString();
                playerPositionFeedBack.text = SmartLocalization.LanguageManager.Instance.GetTextValue("UI_RANK_PANE_POS_" + (i+1));

                if (i > 4) {
                    SoundManager.instance.PlaySound("Fail Victory");
                }
                else {
                    SoundManager.instance.PlaySound("Success");
                }
            }
            else {
                positionLines[i].background.overrideSprite = null;
            }
        }

        animator.StartAnim("openSlide");

    }

    private void InitPositionLines() {
        for (int i = 0; i < FamiliesManager.instance.reputationOrderedFamilies.Count; i++) {
            Transform positionLineTransform = leaderBoardContainer.GetChild(i);
            PositionLine positionLine = new PositionLine();

            positionLine.sigil = positionLineTransform.GetChild(1).GetChild(0).GetComponent<Image>();
            positionLine.familyName = positionLineTransform.GetChild(2).GetComponent<Text>();
            positionLine.background = positionLineTransform.GetComponent<Image>();

            positionLines.Add(positionLine);
        }
    }
}
