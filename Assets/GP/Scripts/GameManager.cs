using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    void Awake() {
        instance = this;
        ReflectionUtils.Init();
        Time.timeScale = 0;
    }

    void Start() {
        SoundManager.instance.PlaySound("Play PT1");
        SmartLocalization.LanguageManager.Instance.ChangeLanguage(PlayerPrefs.GetString("Lang", "en"));
        SoundManager.instance.ChangeVolume(PlayerPrefs.GetFloat("SoundVolume", 1));
    }
    
    public void StartGame () {
        Time.timeScale = 1;
        SailorManager.instance.InitSailors();
        RessourcesManager.instance.InitPlayerRessources();
        SectorManager.instance.GenerateGalaxy();
        FamiliesManager.instance.StartGalacticalBeerContest();
        MissionsManager.instance.InitMissionsDictionary();
        //EventsManager.instance.StartEvents();
        SoundManager.instance.PlaySound("Play_AMB");
        SailorManager.instance.StartMusicCheck();
        TutoManager.instance.StartTuto();
	}

    public void GameOver(GameDeathReasons reason) {
        Time.timeScale = 0;
        GameData.instance.SetIsControlsBlocked(true);
        UI_Manager.instance.HideAllPanes();
        SoundManager.instance.StopSound("Play_AMB");
        SoundManager.instance.StopSound("Play PT1");
        SoundManager.instance.PlaySound("End");
        GameOverMenu.instance.Pop(reason);
    }
	
}
