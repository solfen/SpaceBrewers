using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayLang : MonoBehaviour
{
     public Text   language;
     private string baseText;

	// Use this for initialization
	void Start ()
    {
	    baseText = language.text;
        language.text = baseText + Lang.Get("language");
	}
	
	// Update is called once per frame
	void Update ()
    {
       language.text = baseText + Lang.Get("language");
	}
}
