using UnityEngine;
using System.Collections;

public static class CustomVerticalListTools {

	public static float CalculateHeight (Transform transform) {
        float lowerElemHeight = 0;
        float lowerKnowPos = 0;

        foreach (RectTransform child in transform) {
            if (child.localPosition.y < lowerKnowPos) {
                lowerKnowPos = child.localPosition.y;
                lowerElemHeight = child.sizeDelta.y;
            }
        }

        return -lowerKnowPos + lowerElemHeight;
	}

    public static void SetElemHeigth(RectTransform trans, float height) {
        trans.sizeDelta = new Vector2(trans.sizeDelta.x, height);
    }

    public static void SetElemPosUnderPreviousElem(RectTransform trans, RectTransform previousElem, float margin) {
        trans.localPosition = new Vector3(trans.localPosition.x, previousElem.localPosition.y - previousElem.sizeDelta.y - margin, 0);
    }
	
}
