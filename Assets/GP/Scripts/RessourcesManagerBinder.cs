using UnityEngine;
using System.Collections;

public class RessourcesManagerBinder : MonoBehaviour {

    public void AddBeer(float amount) { RessourcesManager.instance.AddBeer(amount); }
    public void AddMoney(float amount) { RessourcesManager.instance.AddMoney(amount); }
}
