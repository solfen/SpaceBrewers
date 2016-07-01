using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;

public class Lang : Singleton<Lang>
{
    public enum language
    {
        FRENCH,
        ENGLISH
    };
    private Dictionary<string, string> _gameTexts;

    public string this[string key]
    {
        get { return GetText(key); }
    }

    public string[] this[string[] keys]
    {
        get { return GetText(keys); }
    }

    void Awake()
    {
        string lang = Application.systemLanguage.ToString();
        LoadNewLanguage(lang);
    }

    public void LoadNewLanguage(string name)
    {
        string jsonString = string.Empty;

        if (name == "French")
        {
            TextAsset ta = Resources.Load<TextAsset>("TextAsset/lang.fr");
            if (ta != null)
            {
                jsonString = ta.text;
            }
            else
            {
                Debug.Log("TextAsset is null");
            }
        }
        else
        {
            TextAsset ta = Resources.Load<TextAsset>("TextAsset/lang.en");
            if (ta != null)
            {
                jsonString = ta.text;
            }
            else
            {
                Debug.Log("TextAsset is null");
            }
        }

        JSONNode json = JSON.Parse(jsonString);
        int size = json.Count;

        _gameTexts = new Dictionary<string, string>(size);

        JSONArray array;
        for (int i = 0; i < size; i++)
        {
            array = json[i].AsArray;
            _gameTexts.Add(array[0].Value, array[1].Value);
        }
    }

    public static void LoadLanguage(language name)
    {
        if (name == language.FRENCH)
        {
            Instance.LoadNewLanguage("French");
        }
        if (name == language.ENGLISH)
        {
            Instance.LoadNewLanguage("English");
        }
    }

    public static string Get(string key)
    {
        return Instance.GetText(key);
    }

    public static string[] Get(string[] keys)
    {
        return Instance.GetText(keys);
    }

    public string GetText(string key)
    {
        if (_gameTexts.ContainsKey(key))
            return _gameTexts[key];

        return key;
    }

    public string[] GetText(string[] keys)
    {
        int size = keys.Length;
        string[] results = new string[size];

        for (int i = 0; i < size; i++)
            results[i] = GetText(keys[i]);

        return results;
    }
}