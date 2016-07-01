using UnityEngine;
using System.Collections;

public class WaitForSplashScreen : MonoBehaviour
{
    public string levelName = "empty";
    public float timeToWait = 3.0f;
    private float timer = 0.0f;

	// Use this for initialization
	void Start ()
    {
	    timer = timeToWait;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    timer -= Time.deltaTime;

        if (timer < 0.0f)
        {
            Application.LoadLevel(levelName);
        }
	}
}
