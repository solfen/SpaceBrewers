using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CursorHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Texture2D cursorTexture;
    public Vector2 hotSpot = Vector2.zero;
    private Vector2 defaultHotSpot;

    public void OnPointerEnter(PointerEventData data) {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData data) {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
