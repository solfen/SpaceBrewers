using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour 
{
    public RectTransform objToMove;


    public float speed = 10.0f;
    public float timeToReachLimit = 0.0f;
    public float timer = 0.0f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.anyKeyDown)
        {
            Application.LoadLevel("Menu");
        }
        else
        {
           timer += Time.deltaTime;

           if (timer < timeToReachLimit)
           {
                objToMove.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }
	}
}
