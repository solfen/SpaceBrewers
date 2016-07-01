using UnityEngine;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class FMOD_Sound {
    public string name;
    public string parameterName;
    public float valuePlay;
}

[RequireComponent(typeof(StudioEventEmitter))]
public class FMOD_Event_Player : MonoBehaviour {

    private Transform _transform;
    private StudioEventEmitter eventEmmiter;
    private Dictionary<string, FMOD_Sound> soundsDictionary = new Dictionary<string, FMOD_Sound>();
    public List<FMOD_Sound> sounds = new List<FMOD_Sound>();

	void Awake() {
        _transform = GetComponent<Transform>();
        eventEmmiter = GetComponent<StudioEventEmitter>();

        for (int i = 0; i < sounds.Count; i++) {
            soundsDictionary.Add(sounds[i].name, sounds[i]);
        }
	}

    public void PlaySound(string soundName, bool isAlreadyPlaying, Vector3 pos, bool destroyOnEnd = false) {
        if (!soundsDictionary.ContainsKey(soundName)) {
            Debug.LogError("Sound: " + soundName + " is not present in FMOD_Event_Player dictionary");
            return;
        }

        _transform.position = pos;
        FMOD_Sound sound = soundsDictionary[soundName];
        //Debug.Log(soundName);
        
        eventEmmiter.DestroyOnEnd = destroyOnEnd;
        eventEmmiter.SetParameter(sound.parameterName, sound.valuePlay);

        if (!isAlreadyPlaying)
            eventEmmiter.Play();

    }

    public void SetSoundParam(string soundName, float value) {
        eventEmmiter.SetParameter(soundsDictionary[soundName].parameterName, value);
    }

    public void StopSound() {
        if (eventEmmiter != null)
            eventEmmiter.Stop();
    }
}