using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public float slowUpdateRate = 1;

    public GameObject sailorPane;
    public Text sailorNameText;
    public Text sailorActionText;
    public Image sailorImg;
    public GameObject objectStatsPane;
    public GameObject actionPane;
    public GameObject playTimeBtn;
    public Image timeBar;

    public BeerContestMenuScrollList BeerContestContainer;
    public EventUIManager PopUpsContainer;
    public BuildMenuScrollList buildScrollList;
    public MissionMenuScrollList missionMenu;
    public UIAnimator missionMenuAnimator;
    public UIAnimator researchMenuAnimator;
    public UIAnimator eventsMenuAnimator;
    public UIAnimator pauseMenuAnimator;
    public UIAnimator topBarAnimator;
    public UIAnimator ressourcesPaneAnimator;
    public UIAnimator infoMessagesPaneAnimator;
    public UIAnimator roomEditorValidAnimator;
    public UIAnimator roomEditorCloseAnimator;
    public UIAnimator commandPostBtnAnimator;
    public UIAnimator sailorIconsAnimator;
    public GameObject buildingShop;
    public GameObject upgradeShop;

    public Slider drunkSlider;
    public Text drunkSliderText;

    public Slider enegySlider;
    public Text beerNbText;
    public Text moneyNbText;
    public Text nextTaxesTime;
    public Text nextTaxesPrice;

    public Image buildBtnImg;
    public Image RepairBtnImg;
    public Image UpgradeBtnImg;
    public Image DestroyBtnImg;
    public Texture2D buildCursor;
    public Texture2D repairCursor;
    public Texture2D upgradeCursor;
    public Texture2D destroyCursor;

    public Slider objectLifeSlider;
    public Text objectUpgradesText;
    public Text objectDescriptionText;

    public float warningInterval = 30;
    private float warningBeerTimer = 0;
    private float warningFricTimer = 0;

    private UIAnimator sailorPaneAnimator;
    private UIAnimator objectStatsPaneAnimator;
    private UIAnimator actionPaneAnimator;

    private SmartLocalization.LanguageManager langManager;
    private Sailor selectedSailor;
    private Furniture currentObject;
    private bool isSailorPaneOpen = false;
    private bool isObjectStatsPaneOpen = false;
    private bool isActionPaneOpen = false;
    private bool isUpgradeButtonSelected = false;
    private bool isRepairButtonSelected = false;
    private bool isDestructButtonSelected = false;
    private bool isRoomEditorOpen = false;
    private bool isMessagePaneOpen = false;
    private bool isMissionPaneOpen = false;

    void Awake() {
        instance = this;

        sailorPaneAnimator = sailorPane.GetComponent<UIAnimator>();
        objectStatsPaneAnimator = objectStatsPane.GetComponent<UIAnimator>();
        actionPaneAnimator = actionPane.GetComponent<UIAnimator>();
        langManager = SmartLocalization.LanguageManager.Instance;
    }

    void Start() {
        StartCoroutine("SlowUpdate");
    }

    void Update() {
        if (selectedSailor != null && isSailorPaneOpen) {
            drunkSlider.value = selectedSailor.drunkness / 100;
            drunkSliderText.text = langManager.GetTextValue("UI_SAIL_PANE_ALCHOL") + " " + ((int)selectedSailor.drunkness).ToString() + "%";
            sailorActionText.text = langManager.GetTextValue(selectedSailor.currentActionText);
        }

        if(currentObject != null) {
            objectLifeSlider.value = currentObject.life / currentObject.maxLife;
        }

        warningBeerTimer -= Time.deltaTime;
        warningFricTimer -= Time.deltaTime;
    }

    IEnumerator SlowUpdate() {
        yield return new WaitForSeconds(slowUpdateRate);

        while(true) {
            UpdateRessources();
            yield return new WaitForSeconds(slowUpdateRate);
        }
    }
    
    public void UpdateRessources() {
        beerNbText.text = ((int)RessourcesManager.instance.beerNb) + " / " + ((int)RessourcesManager.instance.maxBeerNb);
        moneyNbText.text = ((int)RessourcesManager.instance.moneyNb).ToString();
        nextTaxesTime.text = langManager.GetTextValue("WORD_NEXT") + " " + ((int)RessourcesManager.instance.licenceTimeLeft / 60) + "m" + ":" + ((int)RessourcesManager.instance.licenceTimeLeft % 60) + "s";
        nextTaxesPrice.text = langManager.GetTextValue("UI_MIS_PANE_STAT_COST") + " " + ((int)RessourcesManager.instance.licenceCost).ToString();

        if (warningBeerTimer < 0 && RessourcesManager.instance.beerNb < RessourcesManager.instance.maxBeerNb * 10 / 100) {
            InfoMessagesList.instance.AddMessage("LowBeerStock");
            warningBeerTimer = warningInterval;
        }
        if (warningFricTimer < 0 && !TutoManager.instance.isHappening && RessourcesManager.instance.moneyNb < RessourcesManager.instance.licenceCost) {
            InfoMessagesList.instance.AddMessage("LowMoney");
            warningFricTimer = warningInterval;
        }
    }

    private void ToggleObjectStatPane() {
        objectStatsPaneAnimator.StartAnim("openSlide");
        isObjectStatsPaneOpen = !isObjectStatsPaneOpen;
    }

    public void OpenObjectStatsPane(Furniture objectStats) {
        if (isSailorPaneOpen) {
            return;
        }

        currentObject = objectStats;
        objectUpgradesText.text = langManager.GetTextValue("UI_OBJ_PANE_UPGRADES") + " " + currentObject.currentUpgradeLvl + "/" + currentObject.maxUpgradeNb;
        objectDescriptionText.text = langManager.GetTextValue(objectStats.description);

        if (!isObjectStatsPaneOpen) {
            ToggleObjectStatPane();
        }
    }
    public void CloseObjectStatsPane() {
        if (isObjectStatsPaneOpen) {
            ToggleObjectStatPane();
        }

        currentObject = null;
    }

    public void OpenSailorPane(Sailor sailor) {

        selectedSailor = sailor;
        sailorNameText.text = selectedSailor.sailorName;
        sailorActionText.text = langManager.GetTextValue(selectedSailor.currentActionText);
        sailorImg.sprite = selectedSailor.paneSprite;

        if (!isSailorPaneOpen && !isRoomEditorOpen) {
            actionPane.SetActive(true);
            sailorPane.SetActive(true);

            if (isObjectStatsPaneOpen) {
                objectStatsPaneAnimator.StartAnim("openSlide", OpenSailorPaneAnimation);
                isObjectStatsPaneOpen = false;
            }
            else {
                OpenSailorPaneAnimation();
            }
        }

        ResetUpgradeBtn();
        ResetRepairBtn();
        ResetDestructBtn();
    }

    private void OpenSailorPaneAnimation() {
        actionPaneAnimator.StartAnim("openSlide");
        sailorPaneAnimator.StartAnim("openSlide");
        isSailorPaneOpen = true;
    }

    public void CloseSailorPane() {
        if (!isSailorPaneOpen) {
            return;
        }

        if (isActionPaneOpen) {
            actionPaneAnimator.StartAnim("revealAction", CloseSailorPanePart2);
            isActionPaneOpen = false;
        }
        else {
            CloseSailorPanePart2();
        }
    }

    private void CloseSailorPanePart2() {
        actionPaneAnimator.StartAnim("openSlide");
        sailorPaneAnimator.StartAnim("openSlide");

        isSailorPaneOpen = false;
        selectedSailor = null;
        SailorStateIcons.instance.DesactivateAllSelectFeedback();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void ToggleBuildPane() {
        if (isUpgradeButtonSelected) {
            ResetUpgradeBtn();
        }
        if (isRepairButtonSelected) {
            ResetRepairBtn();
        }
        if (isDestructButtonSelected) {
            ResetDestructBtn();
        }

        if (isActionPaneOpen && upgradeShop.activeSelf) {
            actionPaneAnimator.StartAnim("revealAction", ToggleBuildPane);
            isActionPaneOpen = false;
            return;
        }

        if (!buildingShop.activeSelf) {
            upgradeShop.SetActive(false);
            buildingShop.SetActive(true);
        }

        buildScrollList.ShowCategoryList();
        TutoManager.instance.SetState("isFirstBuildIconSelected", true);
        actionPaneAnimator.StartAnim("revealAction");
        isActionPaneOpen = !isActionPaneOpen;
    }

    public void ToggleUpgradePane() {
        if (isRepairButtonSelected) {
            ResetRepairBtn();
        }
        if (isDestructButtonSelected) {
            ResetDestructBtn();
        }

        if (isActionPaneOpen && buildingShop.activeSelf) {
            actionPaneAnimator.StartAnim("revealAction", ToggleUpgradePane);
            isActionPaneOpen = false;
            return;
        }

        if (!upgradeShop.activeSelf) {
            buildingShop.SetActive(false);
            upgradeShop.SetActive(true);
        }

        actionPaneAnimator.StartAnim("revealAction");
        isActionPaneOpen = !isActionPaneOpen;
    }

    public void OrderToBuild(int objectID, ObjectCategory category) {
        if (GameData.instance.buildingsCategories[(int)category].buildings[objectID].moneyCost > RessourcesManager.instance.moneyNb) {
            InfoMessagesList.instance.AddMessage("NotEnoughMoney");
            buildScrollList.CantAffordFeedback();
            return;
        }

        if (isRoomEditorOpen) {
            ToggleRoomEditor();
        }

        ToggleBuildPane();

        SailorManager.instance.SetSelectedOrder(SailorOrderType.BUILD);
        if (FurniturePlacer.instance.isConstructing) {
            FurniturePlacer.instance.CancelConstruction();
        }
        FurniturePlacer.instance.StartPlacement(GameData.instance.buildingsCategories[(int)category].buildings[objectID]);

        SoundManager.instance.PlaySound("DragObject");
        Cursor.SetCursor(buildCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OrderToUpgrade() {
        if (isRepairButtonSelected) {
            ResetRepairBtn();
        }
        if (isDestructButtonSelected) {
            ResetDestructBtn();
        }

        if (isActionPaneOpen) {
            actionPaneAnimator.StartAnim("revealAction", OrderToUpgrade);
            isActionPaneOpen = false;
            return;
        }

        if (!isUpgradeButtonSelected) {
            Cursor.SetCursor(upgradeCursor, Vector2.zero, CursorMode.Auto);
            UpgradeBtnImg.color = new Color(0, 198, 255);
            isUpgradeButtonSelected = true;
            SailorManager.instance.SetSelectedOrder(SailorOrderType.UPGRADE);
        }
        else {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            ResetUpgradeBtn();
            SailorManager.instance.SetDefaultOrder();
        }
    }


    public void OrderToRepair() {
        if (isUpgradeButtonSelected) {
            ResetUpgradeBtn();
        }
        if (isDestructButtonSelected) {
            ResetDestructBtn();
        }

        if (isActionPaneOpen) {
            actionPaneAnimator.StartAnim("revealAction", OrderToRepair);
            isActionPaneOpen = false;
            return;
        }

        if (!isRepairButtonSelected) {
            Cursor.SetCursor(repairCursor, Vector2.zero, CursorMode.Auto);
            RepairBtnImg.color = new Color(0, 198, 255);
            isRepairButtonSelected = true;
            SailorManager.instance.SetSelectedOrder(SailorOrderType.REPAIR);
        }
        else {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            ResetRepairBtn();
            SailorManager.instance.SetDefaultOrder();
        }
    }

    public void OrderToDestroy() {
        if (isUpgradeButtonSelected) {
            ResetUpgradeBtn();
        }
        if (isRepairButtonSelected) {
            ResetRepairBtn();
        }

        if (isActionPaneOpen) {
            actionPaneAnimator.StartAnim("revealAction", OrderToDestroy);
            isActionPaneOpen = false;
            return;
        }

        if (!isDestructButtonSelected) {
            Cursor.SetCursor(destroyCursor, Vector2.zero, CursorMode.Auto);
            DestroyBtnImg.color = new Color(255, 0, 0);
            isDestructButtonSelected = true;
            SailorManager.instance.SetSelectedOrder(SailorOrderType.DESTROY);
        }
        else {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            ResetDestructBtn();
            SailorManager.instance.SetDefaultOrder();
        }

    }

    public void ToggleRoomEditor() {
        StartCoroutine("RoomEditorTimed");
        isRoomEditorOpen = !isRoomEditorOpen;
        //TutoManager.instance.ToggleState("isRoomEditorSelected");
    }

    IEnumerator RoomEditorTimed() {
        CloseSailorPane();
        topBarAnimator.StartAnim("hide");
        sailorIconsAnimator.StartAnim("hide");

        yield return new WaitForSeconds(1);
        roomEditorValidAnimator.StartAnim("openSlide");
        roomEditorCloseAnimator.StartAnim("openSlide");

        MapEditor.instance.SetIsInEditor();
        MapEditor.instance.SetIsPhaseRoom();
    }

    public void HideAllPanes() {
        CloseSailorPane();
        topBarAnimator.StartAnim("hide");
        sailorIconsAnimator.StartAnim("hide");
        ressourcesPaneAnimator.StartAnim("hide");
        infoMessagesPaneAnimator.StartAnim("hide");

        if (isObjectStatsPaneOpen) {
            ToggleObjectStatPane();
        }
        if (isMessagePaneOpen) {
            OpenMessagesPane();
        }
        if (isMissionPaneOpen) {
            OpenMissionPane();
        }
    }

    public void ResetRepairBtn() {
        RepairBtnImg.color = new Color(255, 255, 255);
        isRepairButtonSelected = false;
    }

    public void ResetUpgradeBtn() {
        UpgradeBtnImg.color = new Color(255, 255, 255);
        isUpgradeButtonSelected = false;
    }

    public void ResetDestructBtn() {
        DestroyBtnImg.color = new Color(255, 255, 255);
        isDestructButtonSelected = false;
    }

    public void SetGameSpeed(float speed) {
        Time.timeScale = speed;

        timeBar.fillAmount = speed / 4;
        timeBar.color = Color.Lerp(Color.cyan, Color.yellow, speed / 4);
    }
    public void AddEventMessage(int eventIndex) {
        InfoMessagesList.instance.AddMessage("NewEvent");
        PopUpsContainer.AddEventMessage(eventIndex, EventsManager.instance.events[eventIndex].isModal);
        if (!isMessagePaneOpen && EventsManager.instance.events[eventIndex].isModal) {
            OpenMessagesPane();
            PopUpsContainer.OpenTab(true);
        }
    }

    public void RefreshBuildingList(int categoryID) {
        CloseSailorPane();
        buildScrollList.InitBuildingList(categoryID);
    }

    public void OpenBeerContestPane() {
        BeerContestContainer.ShowBeerContest();
    }

    public void SpecialOpenObjectPopUP(bool isCommandPost, bool isCommPost, bool isResearchPost) {
        if (isCommandPost) {
            OpenMissionPane();
        }
        else if (isResearchPost) {
            OpenResearchPane();
        }
        else if (isCommPost) {
            OpenMessagesPane();
        }
    }

    public void TogglePausePane() {
        pauseMenuAnimator.StartAnim("openSlide");
        int speed = pauseMenuAnimator.animationsDictionary["openSlide"].isReverted ? 1 : 0;
        SetGameSpeed(speed);
        GameData.instance.SetIsControlsBlocked(!GameData.instance.isControlsBlocked);

        //SoundManager.instance.PlaySound(speed == 0 ? "Pause On" : "Pause Off");
    }

    public void OpenMissionPane() {
        isMissionPaneOpen = !isMissionPaneOpen;
        missionMenuAnimator.StartAnim("openSlide");
        if (!GameData.instance.isControlsBlocked)
            missionMenu.StartTimeLeftUpdateCoroutine();
        GameData.instance.SetIsControlsBlocked(!GameData.instance.isControlsBlocked);
        TutoManager.instance.SetState("isCommandPostOpen", isMissionPaneOpen);
        TutoManager.instance.SetState("isCommandPostClosed", !isMissionPaneOpen);
    }

    public void OpenResearchPane() {
        researchMenuAnimator.StartAnim("openSlide");
        GameData.instance.SetIsControlsBlocked(true);
    }

    public void OpenMessagesPane() {
        GameData.instance.SetIsControlsBlocked(!isMessagePaneOpen);
        isMessagePaneOpen = !isMessagePaneOpen;
        eventsMenuAnimator.StartAnim("openSlide");
    }

    public void ToggleCommandPost() {
        commandPostBtnAnimator.StartAnim("openSlide");
    }

    public void ShowCategory(int index) {
        buildScrollList.ShowBuildings(index);

        if (index == 0) {
            TutoManager.instance.SetState("isBeerCategorySelected", true);
        }
    }

    public void OnSailorDelete(Sailor sailor) {
        if (selectedSailor == sailor && isSailorPaneOpen) {
            CloseSailorPane();
        }
    }

    public void FireSailor() {
        if (selectedSailor != null) {
            SailorManager.instance.RemoveSailor(selectedSailor);
        }
    }
}
