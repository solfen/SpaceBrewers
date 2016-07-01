using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomUISpriteSwap : MonoBehaviour {

    public Image targetGraphic;
    public Sprite hoverSprite;
    public Sprite pressedSprite;
    public Sprite activeSprite;

    private bool isActive = false;

    public void OnMouseEnter() {
        if (!isActive) {
            targetGraphic.overrideSprite = hoverSprite;
        }
    }

    public void OnMouseExit() {
        if (!isActive) {
            targetGraphic.overrideSprite = null;
        }
    }
     
    public void OnMouseDown() {
        if (!isActive) {
            targetGraphic.overrideSprite = pressedSprite;
        }
    }

    public void OnMouseUp() {
        targetGraphic.overrideSprite = activeSprite;
        isActive = true;
    }

    public void OnDeSelect() {
        targetGraphic.overrideSprite = null;
        isActive = false;
    }
}
