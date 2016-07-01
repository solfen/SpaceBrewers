using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;

    public bool isMute = false;
    public List<string> soundsToMute = new List<string>();
    public float soundDistanceMultiplier = 0.1f;

    private FMOD_Event_Player[] fmod_player;
    private Dictionary<string, FMOD_Event_Player> soundList = new Dictionary<string, FMOD_Event_Player>();
    private Transform cameraTransform;
    private FMOD.Studio.Bus masterBus;

    void Awake() {
        instance = this;

        InitSoundList();
        cameraTransform = Camera.main.transform;

        masterBus = FMODUnity.RuntimeManager.GetBus("bus:/");
    }

    private void InitSoundList() {
        fmod_player = transform.GetComponentsInChildren<FMOD_Event_Player>();

        for (int i = 0; i < fmod_player.Length; i++) {
            if (fmod_player[i] == null) {
                continue;
            }

            for (int j = 0; j < fmod_player[i].sounds.Count; j++) {
                if (!soundList.ContainsKey(fmod_player[i].sounds[j].name)) {
                    soundList.Add(fmod_player[i].sounds[j].name, fmod_player[i]);
                    //Debug.Log(fmod_params[i].sounds[j].name, fmod_params[i]);
                }
            }
        }
    }

    private bool SoundChecks(string soundName) {
        if (!soundList.ContainsKey(soundName)) {
            Debug.LogError("The sound: " + soundName + " doesn't exists");
        }

        return !isMute && soundList.ContainsKey(soundName) && !soundsToMute.Contains(soundName);
    }

    public void PlaySound(string soundName) {
        if (!SoundChecks(soundName))
            return;

        soundList[soundName].PlaySound(soundName, false, Vector3.zero);
    }

    public void PlaySound(string soundName, bool isPlaying) {
        if (!SoundChecks(soundName))
            return;

        soundList[soundName].PlaySound(soundName, isPlaying, Vector3.zero);
    }

    public FMOD_Event_Player PlaySound(string soundName, bool isPlaying, Vector3 pos) {
        if (!SoundChecks(soundName))
            return null;

        GameObject obj = Instantiate(soundList[soundName].gameObject) as GameObject;
        FMOD_Event_Player sound = obj.GetComponent<FMOD_Event_Player>();
        sound.PlaySound(soundName, isPlaying, cameraTransform.position + (pos - cameraTransform.position) * soundDistanceMultiplier, true);

        return sound;
    }

    public void SetSoundParam(string soundName, float value) {
        soundList[soundName].SetSoundParam(soundName, value);
    }

    public void StopSound(string soundName) {
        if (!SoundChecks(soundName))
            return;

        soundList[soundName].StopSound();
    }

    public void ChangeVolume(float volume) {
        if (masterBus != null) {
            masterBus.setFaderLevel(volume);
        }
    }
}