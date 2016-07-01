using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
    public string levelName = "empty";
    public Texture2D emptyProgressBar; // Set this in inspector.
    public Texture2D fullProgressBar; // Set this in inspector.
    public bool loadAtStart = false;
    private AsyncOperation async = null; // When assigned, load is in progress.


    public void Start ()
    {
        if (loadAtStart)
        {
            StartCoroutine(LoadALevel(levelName));
        }
    }

    public void LoadLevelAsync()
    {
        StartCoroutine(LoadALevel(levelName));
    }

    private IEnumerator LoadALevel(string levelName)
    {
        async = Application.LoadLevelAsync(levelName);
        yield return async;
    }

    void OnGUI()
    {
        /*if (async != null)
        {
            GUI.DrawTexture(new Rect(0, Screen.height - 50, Screen.width, 50), emptyProgressBar);
            GUI.DrawTexture(new Rect(0, Screen.height - 50, Screen.width * async.progress, 50), fullProgressBar);
        }*/
    }
}
