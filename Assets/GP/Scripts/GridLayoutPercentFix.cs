using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridLayoutPercentFix : MonoBehaviour {

    private GridLayoutGroup gridLayout;
    private float paddingLeft;
    private float paddingRight;
    private float paddingTop;
    private float paddingBottom;
    private Vector2 cellSize;
    private Vector2 spacing;
    private bool isInit = false;

    private RectTransform rectTransform;
    public bool isCellSizeOnlyWidthRelative = false;
	
	void SaveBaseSettings () {
        gridLayout = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();

        paddingLeft = gridLayout.padding.left;
        paddingRight = gridLayout.padding.right;
        paddingTop = gridLayout.padding.top;
        paddingBottom = gridLayout.padding.bottom;

        cellSize = gridLayout.cellSize / 100;
        spacing = gridLayout.spacing / 100;

        isInit = true;
	}

    //called when the rectTransform changes
    void OnRectTransformDimensionsChange() {
        if (!isInit) {
            SaveBaseSettings();
        }

        gridLayout.padding.left = (int)(paddingLeft/100 * rectTransform.rect.width);
        gridLayout.padding.right = (int)(paddingRight/100 * rectTransform.rect.width);
        gridLayout.padding.top = (int)(paddingTop/100 * rectTransform.rect.height);
        gridLayout.padding.bottom = (int)(paddingBottom/100 * rectTransform.rect.height);

        gridLayout.spacing = new Vector2(spacing.x * rectTransform.rect.width, spacing.y * rectTransform.rect.height);

        if (isCellSizeOnlyWidthRelative) {
            gridLayout.cellSize = new Vector2(cellSize.x * rectTransform.rect.width, cellSize.y * rectTransform.rect.width);
        }
        else {
            gridLayout.cellSize = new Vector2(cellSize.x * rectTransform.rect.width, cellSize.y * rectTransform.rect.height);
        }
    }
}
