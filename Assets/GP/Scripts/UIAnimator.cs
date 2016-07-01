using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIAnimator : MonoBehaviour {

    public string openSound = "Pop Up";
    public string closeSound = "Pop Down";
    public UIAnimation[] animations;
    public delegate void UICallback(); // declare delegate type

    public Dictionary<string, UIAnimation> animationsDictionary = new Dictionary<string, UIAnimation>();
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
        UIAnimation anim = animationsDictionary[name];

        if (name == "openSlide") {
            if (closeSound != "" && anim.isReverted) {
                SoundManager.instance.PlaySound(closeSound);
            }
            else if (openSound != "" && !anim.isReverted) {
                SoundManager.instance.PlaySound(openSound);
            }
        }

        while (anim.timeElapsed < anim.animDuration) {
            float timePercent = anim.timeElapsed / anim.animDuration;
            float animationCompletionPercent = anim.curve.Evaluate(timePercent);

            Vector3 currentPos = Vector3.Lerp(anim.startPos, anim.endPos, animationCompletionPercent);
            anim.element.position = new Vector3(Screen.width * anim.element.anchorMax.x + currentPos.x, Screen.height * anim.element.anchorMax.y + currentPos.y, 0);
            anim.element.sizeDelta = Vector2.Lerp(anim.startSize, anim.endSize, animationCompletionPercent);

            anim.timeElapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        anim.element.position = new Vector3(Screen.width * anim.element.anchorMax.x + anim.endPos.x, Screen.height * anim.element.anchorMax.y + anim.endPos.y, 0);
        anim.element.sizeDelta = anim.endSize;

        anim.timeElapsed = 0;

        if (anim.isReversible) {

            Vector3 tmpPos = anim.startPos;
            anim.startPos = anim.endPos;
            anim.endPos = tmpPos;

            Vector2 tmpSize = anim.startSize;
            anim.startSize = anim.endSize;
            anim.endSize = tmpSize;

            anim.isReverted = !anim.isReverted;
        }

        if (callbackDictionary.ContainsKey(name)) {
            callbackDictionary[name]();
            callbackDictionary.Remove(name);
        }
    }
}
