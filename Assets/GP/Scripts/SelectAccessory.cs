using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SelectAccessory : MonoBehaviour
{
    public GameObject           mesh;
    public GameObject           parent;
    //public List<Material>       accessoriesMaterials;
    public List<Material>       characterMaterials;
    public List<GameObject>     accessories;
    public List<Sprite>         stateSprite;
    public List<Sprite>         paneSprite;

    private GameObject          actualAccessory;
    private Material            actualAccessoryMaterial;
    private Material            actualCharacterMaterial;
    
	// Use this for initialization
	void Awake ()
    {
        Sailor sailorScript = GetComponent<Sailor>();
	    int rng = Random.Range(0, accessories.Count);

        sailorScript.iconSprite = stateSprite[rng];
        sailorScript.paneSprite = paneSprite[rng];

        if (accessories[rng] != null) {
            actualAccessory = GameObject.Instantiate(accessories[rng], Vector3.zero, Quaternion.identity) as GameObject;
            actualAccessory.transform.SetParent(parent.transform);
            actualAccessory.transform.localPosition = Vector3.zero;
        }

        rng = Random.Range(0, characterMaterials.Count);
        mesh.GetComponent<Renderer>().material = characterMaterials[rng];
        actualCharacterMaterial = characterMaterials[rng];

        //rng = Random.Range(0, accessoriesMaterials.Count);
        //actualAccessory.GetComponent<Renderer>().material = accessoriesMaterials[rng];
	}
	
}
