using UnityEngine;
using System.Collections;

public class SoundManagerBinder : MonoBehaviour {

    public void PlaySound(string soundName) {
        SoundManager.instance.PlaySound(soundName);
    }

    public void PlaySound(string soundName, bool isPlaying) {
        SoundManager.instance.PlaySound(soundName, isPlaying);
    }

    public void PlaySound(string soundName, bool isPlaying, Vector3 pos) {
        SoundManager.instance.PlaySound(soundName, isPlaying, pos);
    }

    public void StopSound(string name) {
        SoundManager.instance.StopSound(name);
    }

    public void ChangeVolume(float volume) {
        SoundManager.instance.ChangeVolume(volume);
    }
}
