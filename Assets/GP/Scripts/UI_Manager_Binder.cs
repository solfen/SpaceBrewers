using UnityEngine;
using System.Collections;

public class UI_Manager_Binder : MonoBehaviour {

    public void ToggleRoomEditor() { UI_Manager.instance.ToggleRoomEditor(); }
    public void ShowCategory(int index) { UI_Manager.instance.ShowCategory(index); }
}
