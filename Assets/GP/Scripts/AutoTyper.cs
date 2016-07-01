using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class AutoTyper : MonoBehaviour {

    public float charsPerSecond = 30;
    public string soundTyping;
    public float soundInterval = 0.5f;
    public Text text;
    public bool typeAtStart = false;
	void Start () {
        text = GetComponent<Text>();
        if (typeAtStart)
            StartTyping();
	}

    public void StartTyping(string overrideText = null) {
        StartCoroutine(TypeRoutine(overrideText));
    }

    IEnumerator TypeRoutine(string overrideText = null) {

        string finalText = overrideText == null ? text.text : overrideText;
        float duration = finalText.Length / charsPerSecond;
        float soundTimer = soundInterval;

        for (float t=0f; t<duration; t+=Time.unscaledDeltaTime ) {
            soundTimer -= Time.unscaledDeltaTime;
            if (soundTyping != "" && soundTimer < 0) {
                soundTimer = soundInterval;
                SoundManager.instance.PlaySound(soundTyping);
            }

            text.text = finalText.Substring(0, (int)(finalText.Length * t / duration));
            yield return null;
        }

        text.text = finalText;
    }
}
