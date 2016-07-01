using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
public class CustomPreserveAspectPosition : MonoBehaviour {

    public RectTransform parent;
    public Vector2 parentInitialSize;
    public Vector2 pos;
    public Vector2 size;

    private RectTransform trans;

	void Update () {
        trans = GetComponent<RectTransform>();

        float ratio = parent.sizeDelta.x / parentInitialSize.x;
        trans.anchoredPosition = pos * ratio;
        trans.sizeDelta = size * ratio;
	}
	

}
