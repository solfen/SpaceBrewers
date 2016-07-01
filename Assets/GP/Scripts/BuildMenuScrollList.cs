using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class BuildMenuScrollList : MonoBehaviour {

    public GameObject iconPrefab;
    public GameObject containerPrefab;
    public Transform contentPannel;
    public Tooltip tooltip;
    public Sprite returnSprite;
    public Sprite returnSpriteHover;

    private GameObject categoriesList;
    private Dictionary<int, GameObject> buildingsList = new Dictionary<int, GameObject>();
    private Button.ButtonClickedEvent onReturnClick;
    private SmartLocalization.LanguageManager localization;

    // TODO : make a generic class by using reflection and/or Interfaces
    void Start() {
        localization = SmartLocalization.LanguageManager.Instance;

        onReturnClick = new Button.ButtonClickedEvent();
        onReturnClick.AddListener(ShowCategoryList);
        onReturnClick.AddListener(delegate { SoundManager.instance.PlaySound("Previous Click"); });

        InitCategoriesList();
    }

    private void EmptyContentPannel() {
        foreach (Transform t in contentPannel) {
            t.gameObject.SetActive(false);
        }
    }

    private void CreateIcon(Transform parent, string name, Sprite icon, Sprite hoverIcon, Button.ButtonClickedEvent onclick, string tooltipMessage) {
        GameObject instance = Instantiate(iconPrefab) as GameObject;
        instance.name = name;
        instance.GetComponent<Image>().sprite = icon;
        instance.GetComponent<Button>().onClick = onclick;
        SpriteState st = new SpriteState();
        st.highlightedSprite = hoverIcon;
        instance.GetComponent<Button>().spriteState = st;
        instance.transform.SetParent(parent, false);

        EventTrigger eventTrigger = instance.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener(delegate { tooltip.ShowTooltip(tooltipMessage); });
        eventTrigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener(delegate { tooltip.ClearTooltip(); });
        eventTrigger.triggers.Add(entry);

    }

    public void InitBuildingList(int categoryID) {
        if (buildingsList.ContainsKey(categoryID)) {
            Destroy(buildingsList[categoryID]);
            buildingsList.Remove(categoryID);
        }

        buildingsList.Add(categoryID, Instantiate(containerPrefab) as GameObject);
        buildingsList[categoryID].SetActive(false);
        buildingsList[categoryID].transform.SetParent(contentPannel, false);

        CreateIcon(buildingsList[categoryID].transform, localization.GetTextValue("OBJ_RETURN"), returnSprite, returnSpriteHover, onReturnClick, "");

        for (int i=0; i < GameData.instance.buildingsCategories[categoryID].buildings.Count; i++) {
            Building building = GameData.instance.buildingsCategories[categoryID].buildings[i];
            if (!building.isUnlocked) {
                continue;
            }

            int cpt = i;

            Button.ButtonClickedEvent onBuildingClick = new Button.ButtonClickedEvent();
            onBuildingClick.AddListener(delegate { UI_Manager.instance.OrderToBuild(cpt, (ObjectCategory)categoryID); });

            string name = localization.GetTextValue(building.name);
            CreateIcon(buildingsList[categoryID].transform, name, building.icon, building.hoverIcon, onBuildingClick, (name + ", " + localization.GetTextValue("OBJ_COST") + " " + building.moneyCost));
        }
    }

    private void InitCategoriesList() {
        categoriesList = Instantiate(containerPrefab) as GameObject;
        categoriesList.transform.SetParent(contentPannel, false);
        foreach (var category in GameData.instance.buildingsCategories) {
            category.onClick.AddListener(delegate { SoundManager.instance.PlaySound("Category Click"); });

            CreateIcon(categoriesList.transform, localization.GetTextValue(category.name), category.icon, category.iconHover, category.onClick, (localization.GetTextValue("OBJ_CATEGORY") + " " + localization.GetTextValue(category.name)));
        }
    }

    public void ShowCategoryList() {
        EmptyContentPannel();
        categoriesList.SetActive(true);
    }

    public void ShowBuildings(int categoryID) {
        EmptyContentPannel();

        if(!buildingsList.ContainsKey(categoryID)) {
            InitBuildingList(categoryID);
        }

        buildingsList[categoryID].SetActive(true);
    }

    public void CantAffordFeedback() {
        tooltip.CantAffordFeedback();
    }

}
