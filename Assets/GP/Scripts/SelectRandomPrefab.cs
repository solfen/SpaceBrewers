using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectRandomPrefab : MonoBehaviour
{
    public GameObject       actualPrefab;
    public GameObject       parent;
    public List<GameObject> prefabs;

	// Use this for initialization
	void Start ()
    {
	    
	}

    public void SelectMesh()
    {
        int rng = Random.Range(0, prefabs.Count - 1);

        parent.transform.position = prefabs[rng].transform.position;
        actualPrefab = GameObject.Instantiate(prefabs[rng], Vector3.zero, Quaternion.identity) as GameObject;
        actualPrefab.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        actualPrefab.transform.SetParent(parent.transform, true);
    }
	
}
