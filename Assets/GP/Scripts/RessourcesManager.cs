using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RessourcesManager : MonoBehaviour {
    public static RessourcesManager instance;

    public float score = 0;
    public float scorePerSecond = 10;
    [Range(0,100)]
    public float reputation;
    public float beerNb;
    public float maxBeerNb;
    public float beerProductionRate;
                 
    public float moneyNb;
    public float gameTime;
    public float licenceCost = 10;
    public float licenceMultiplier = 1.5f;
    public float licenceCostInterval = 60;
    public float minMoney = -100;
    public float licenceTimeLeft;
    [Tooltip("Ex  money from destruction of a 50% state objet equals to: this var * 0.5 * base price of object")]
    public float destructionRecuperationRate;

    [HideInInspector]
    public float energyNb;
    [HideInInspector]
    public float maxEnergyNb;

    [HideInInspector]
    public float eventChoice = -1;

    //I know I could store this informations in a dictionary. But that way, these var can be used as conditions in the events and missions tools.
    [HideInInspector]
    public float nbOfMindManipulatorConstructed = 0;
    [HideInInspector]
    public float nbOfTranslatorConstructed = 0;
    [HideInInspector]
    public float nbOfAntenaConstructed = 0;
    [HideInInspector]
    public float nbOfCommPostConstructed = 0;
    [HideInInspector]
    public float nbOfComandPostConstructed = 0;

    void Awake() {
        instance = this;
        SetEventChoice(-1);
    }

    public void InitPlayerRessources() {
        beerNb = ReflectionUtils.GenerateRandomFromRewardString(FamiliesManager.instance.playerFamilyTemplate.startBeer);
        maxBeerNb = ReflectionUtils.GenerateRandomFromRewardString(FamiliesManager.instance.playerFamilyTemplate.startMaxBeer);
        moneyNb = ReflectionUtils.GenerateRandomFromRewardString(FamiliesManager.instance.playerFamilyTemplate.startMoney);

        UI_Manager.instance.UpdateRessources();
    }

    public void Init() {
        StartCoroutine(RessourcesUpdate());
    }

    IEnumerator RessourcesUpdate() {
        licenceTimeLeft = licenceCostInterval;

        while (true) {
            AddBeer(beerProductionRate * Time.deltaTime);
            AddScore(scorePerSecond * Time.deltaTime);
            beerNb = Mathf.Min(beerNb, maxBeerNb);
            gameTime = Time.time; // so that events and missions can check for time elapsed

            if (licenceTimeLeft <= 0) {
                InfoMessagesList.instance.AddMessage("LicencePayed");
                licenceTimeLeft = licenceCostInterval;
                AddMoney(-licenceCost);
                licenceCost *= licenceMultiplier;
            }

            licenceTimeLeft -= Time.deltaTime;

            yield return null;
        }
    }

    // ---------- Seters methods so that the ressources are only modified here and not anywhere else in the code (except from reflection events) ---------- 
    public void AddBeer(float amount) {
        beerNb += amount;
    }

    public void IncreaseBeerMaxNb(float amount) {
        maxBeerNb += amount;
    }

    public void IncreaseBeerProductionRate(float amount) {
        beerProductionRate += amount;
    }

    public void AddMoney(float amount) {
        // reminder : fric = pognon && pogon = fric (http://www.jeuxvideo.com/chroniques-video/00000345/3615-usul-les-boites-00108816.htm)
        moneyNb += amount;
       /* if (moneyNb <= 0) {
            InfoMessagesList.instance.AddMessage("LowMoney"); // BUG
        }*/

        if (moneyNb < minMoney) {
            UI_Manager.instance.UpdateRessources();
            GameManager.instance.GameOver(GameDeathReasons.NOMONEY);
        }
    }

    public void IncreaseDestructionRecuperationRate(float amount) {
        destructionRecuperationRate += amount;
    }

    public void SetDestructionRecuperationRate(float rate) {
        destructionRecuperationRate = rate;
    }

    public void AddEnergy(float amount) {
        energyNb += amount;
    }

    public void IncreaseMaxEnergy(float amount) {
        maxEnergyNb += amount;
    }

    public void SetEventChoice(float choice) {
        eventChoice = choice;
    }

    public void AddReputation(float amount) {
        reputation += amount;
    }

    public void AddScore(float amount) {
        score += amount;
    }
}
