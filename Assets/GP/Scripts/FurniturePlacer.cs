using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class FurniturePlacer : MonoBehaviour {

    public static FurniturePlacer instance;
    public bool isConstructing;
    public Color canPlaceColor;
    public Color canotPlaceColor;

    private Transform currentTransform;
    private Furniture currentFurniture;
    private float offsetX;
    private float offsetZ;
    private int width;
    private int height;

    void Awake() {
        instance = this;
    }

    public void StartPlacement(Building building) {
        currentTransform = (GameObject.Instantiate(building.prefab) as GameObject).transform;
        currentFurniture = currentTransform.GetComponent<Furniture>();
        currentFurniture.moneyCost = building.moneyCost;
        currentFurniture.life = 0;
        offsetX = currentTransform.position.x;
        offsetZ = currentTransform.position.z;
        width = (int)currentFurniture.sizePlaneTransform.localScale.x;
        height = (int)currentFurniture.sizePlaneTransform.localScale.z;

        MapEditor.instance.AddFurniture(currentTransform.gameObject);

        StartCoroutine("MouseObjectOnCursor");
        isConstructing = true;

        if(building.name == "OBJ_NAME_3") {
            TutoManager.instance.SetState("isKettleSelected", true);
        }
    }

    public void CancelConstruction() {
        if (isConstructing) {
            StopCoroutine("MouseObjectOnCursor");

            MapEditor.instance.RemoveFurniture(currentTransform.gameObject);

            Destroy(currentTransform.gameObject);
            isConstructing = false;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    private void FinishPlacement() {
        if (isConstructing) {
            SoundManager.instance.PlaySound("DropObject");
            currentFurniture.isPlaced = true;
            currentFurniture.sizePlaneTransform.gameObject.SetActive(false);
            RessourcesManager.instance.AddMoney(-currentFurniture.moneyCost);
            StopCoroutine("MouseObjectOnCursor");
            isConstructing = false;
            SailorManager.instance.OnObjectHit(currentFurniture);

            if (currentFurniture.name == "Kettle(Clone)") {
                TutoManager.instance.SetState("isKettlePlaced", true);
            }
        }
    }

    IEnumerator MouseObjectOnCursor() {
        while (true) {
            if (Input.GetKeyDown(KeyCode.R)) {
                currentTransform.Rotate(currentTransform.up, 90);
                float tmp = offsetX;
                offsetX = offsetZ;
                offsetZ = tmp;
                int tmp2 = width;
                width = height;
                height = tmp2;
            }
            if (Input.GetKeyDown(KeyCode.Escape)) {
                CancelConstruction();
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            int layerMask = 1 << 8;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask)) {
                Vector3 pos = hitInfo.transform.position;
                currentTransform.position = new Vector3(pos.x + offsetX - 0.5f, 0, pos.z + offsetZ - 0.5f);
            }

            if (EventSystem.current.IsPointerOverGameObject()) { // souris au dessus de l'UI
                yield return null;
                continue;
            }

            bool canPutFurnitureOnMap = CanPutFurnitureOnMap();
            if (canPutFurnitureOnMap && Input.GetMouseButtonDown(0)) {
                FinishPlacement();
            }

            currentFurniture.sizePlaneRenderer.material.SetColor("_TintColor", canPutFurnitureOnMap ? canPlaceColor : canotPlaceColor);

            yield return null;
        }
    }

    private bool CanPutFurnitureOnMap() {
        //  - 0.5 * plane size to take into acount the object size, + 0.5f because the pivot point is in the middle of the tiles
        int objectRectSizeX = (int)(currentTransform.position.x - 0.5f * width + 0.5f);
        int objectRectSizeZ = (int)(currentTransform.position.z - 0.5f * height + 0.5f);
        int roomIndex = MapEditor.instance.GetRoomIndex(objectRectSizeX, objectRectSizeZ, width, height);
        ObjectCategory roomCategory = roomIndex == -1 ? ObjectCategory.NONE : MapEditor.instance.GetRoomCategory(roomIndex);

        return (roomIndex != -1 && roomCategory != ObjectCategory.BAR /*&& roomCategory == currentFurniture.category*/ && 
                MapEditor.instance.CheckOverFurniture(currentFurniture.gameObject));
    }

}