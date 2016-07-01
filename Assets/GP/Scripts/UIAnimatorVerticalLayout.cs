using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIAnimatorVerticalLayout : MonoBehaviour {

    public string openSound;
    public string closeSound;
    public UIAnimationVerticalLayout[] animations;
    public delegate void UICallback(); // declare delegate type

    private Dictionary<string, UIAnimationVerticalLayout> animationsDictionary = new Dictionary<string, UIAnimationVerticalLayout>();
    private Dictionary<string, UICallback> callbackDictionary = new Dictionary<string, UICallback>();

    void Awake() {
        for (int i = 0; i < animations.Length; i++) {
            animationsDictionary.Add(animations[i].name, animations[i]);
        }
    }
    public void StartAnim(string name, UICallback callback) {
        callbackDictionary.Add(name, callback);
        StartCoroutine("Animation", name);
    }
    public void StartAnim(string name) {
        StartCoroutine("Animation", name);
    }

    IEnumerator Animation(string name) {
        UIAnimationVerticalLayout anim = animationsDictionary[name];

        if (closeSound != "" && anim.isReverted) {
            SoundManager.instance.PlaySound(closeSound);
        }
        else if (openSound != "" && !anim.isReverted) {
            SoundManager.instance.PlaySound(openSound);
        }

        while (anim.timeElapsed < anim.animDuration) {
            float timePercent = anim.timeElapsed / anim.animDuration;
            float animationCompletionPercent = anim.curve.Evaluate(timePercent);

            Vector2 currentSize = Vector2.Lerp(anim.startPreferedSize, anim.endPreferedSize, animationCompletionPercent);

            anim.element.preferredWidth = currentSize.x;
            anim.element.preferredHeight = currentSize.y;

            anim.timeElapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        anim.element.preferredWidth = anim.endPreferedSize.x;
        anim.element.preferredHeight = anim.endPreferedSize.y;

        anim.timeElapsed = 0;

        if (anim.isReversible) {
            Vector2 tmpSize = anim.startPreferedSize;
            anim.startPreferedSize = anim.endPreferedSize;
            anim.endPreferedSize = tmpSize;

            anim.isReverted = !anim.isReverted;
        }

        if (callbackDictionary.ContainsKey(name)) {
            callbackDictionary[name]();
            callbackDictionary.Remove(name);
        }
    }
}
