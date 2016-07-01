using UnityEngine;
using System.Collections;

public class MissonManagerBinder : MonoBehaviour {

    public void QuitMission() {
        MissionsManager.instance.QuitMission();
    }
}
