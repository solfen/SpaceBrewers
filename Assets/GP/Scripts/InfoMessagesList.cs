using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InfoMessagesList : MonoBehaviour {
    public static InfoMessagesList instance;

    public int maxNbOfMessages;
    public GameObject messagePrefab;
    public Transform messageContainer;

    private List<GameObject> messages = new List<GameObject>();
    private List<string> waitingList = new List<string>();
    private float currentTopPos = 0;
    private float messageHeight;
    private bool isClosing = false;
    private bool isOpening = false;

    void Awake() {
        instance = this;
        StartCoroutine(ManagerWaitingList());
    }

    public void AddMessage(string messageName) {
        waitingList.Add(messageName);
    }

    IEnumerator ManagerWaitingList() {
        while (true) {
            if (waitingList.Count > 0 && !isClosing) {
                if (messages.Count >= maxNbOfMessages) {
                    if (!isOpening) {
                        CloseMessage(0);
                    }
                }
                else {
                    CreateMsg(waitingList[0]);
                    waitingList.RemoveAt(0);
                }

            }

            yield return null;
        }
    }

    public void CreateMsg(string messageName) {
        InfoMessage messageTemplate = GameData.instance.infoMessagesDictionary[messageName];
        InfoMessageStyle style = GameData.instance.infoMessageStylesDictionary[messageTemplate.type];

        GameObject message = Instantiate(messagePrefab) as GameObject;
        message.GetComponent<Image>().sprite = style.backgroundSprite;

        message.GetComponent<Button>().onClick.AddListener(delegate { CloseMessage(messages.FindIndex(x => x == message)); });

        Text text = message.GetComponentInChildren<Text>();
        text.fontSize = style.fontSize;
        text.color = style.fontColor;
        text.text = SmartLocalization.LanguageManager.Instance.GetTextValue(style.textHeader) + " " + SmartLocalization.LanguageManager.Instance.GetTextValue(messageTemplate.text);

        UIAnimator anim = message.GetComponent<UIAnimator>();
        SetAnimPos(anim, currentTopPos);

        messageHeight = message.GetComponent<RectTransform>().sizeDelta.y;
        currentTopPos += messageHeight;
        message.transform.SetParent(messageContainer, false);
        messages.Add(message);
        anim.StartAnim("reveal", delegate { isOpening = false; });

        if (style.soundName != "") {
            SoundManager.instance.PlaySound(style.soundName);
        }

        isOpening = true;
    }

    public void CloseMessage(int index) {
        if (index == -1 || index > messages.Count) {
            Debug.LogError("The index: " + index + "is not present in messages list");
            return;
        }

        isClosing = true;
        GameObject msg = messages[index];
        msg.GetComponent<UIAnimator>().StopAllCoroutines();
        msg.GetComponent<UIAnimator>().StartAnim("close", delegate { Destroy(msg); LowerMessages(index); isClosing = false; });
        RemoveMessage(index);
    }

    private void RemoveMessage(int index) {
        messages.RemoveAt(index);
        currentTopPos -= messageHeight;
    }

    private void LowerMessages(int startIndex) {
        for (int i = startIndex; i < messages.Count; i++) {
            UIAnimator anim = messages[i].GetComponent<UIAnimator>();
            SetAnimPos(anim, -messageHeight);
            anim.StartAnim("down");
        }
    }

    private void SetAnimPos(UIAnimator anim, float yPos) {
        anim.animations[0].startPos.y += yPos;
        anim.animations[0].endPos.y += yPos;
        anim.animations[1].startPos.y += yPos;
        anim.animations[1].endPos.y += yPos;
        anim.animations[2].startPos.y += yPos;
        anim.animations[2].endPos.y += yPos;
    }
}
