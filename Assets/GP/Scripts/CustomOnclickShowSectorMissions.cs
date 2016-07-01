using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CustomOnclickShowSectorMissions : MonoBehaviour {
    public MissionType missionType;
    public MissionMenuScrollList missionMenuScrollList;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { missionMenuScrollList.ShowSectorMissions(missionType); });
    }
}
