using UnityEngine;
using System.Collections;

public class LevelsManager : MonoBehaviour {
    public int sceneToLoadAtStart = -1;
    private AsyncOperation loading;

    void Start() {
        if (sceneToLoadAtStart != -1) {
            LoadLevel(sceneToLoadAtStart);
        }
    }

    public void UserSceneChangeConfirmation() {
        loading.allowSceneActivation = true;
        Time.timeScale = 1; // so that the next scene starts with a clean timeScale;
    }

    public void LoadLevel(int index) {
        loading =  Application.LoadLevelAsync(index);
        loading.allowSceneActivation = false;
    }

    public void LoadLevel(int index, bool allowSceneActivation) {
        loading = Application.LoadLevelAsync(index);
        loading.allowSceneActivation = allowSceneActivation;
    }

    public void LoadLevelNormal(int index) {
        Application.LoadLevel(index);
        Time.timeScale = 1;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
