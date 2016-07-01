using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Sailor : MonoBehaviour {
    private SailorsConfig configRef;
    private NavMeshAgent agent;
    private string currentFurnitureAnim = "Build";
    public class SailorOrder {
        public SailorOrderType type;
        public Vector3? destination; //nullifiable type so that it can be null
        public Furniture furnitureTarget;
        public Sailor sailorTarget;
        public float alocatedTime;
    }
    private Dictionary<SailorOrderType, string> orderRoutines = new Dictionary<SailorOrderType, string>() {
        {SailorOrderType.DRINK, "Drink"},
        {SailorOrderType.GO_DRINK, "Go_Drink"},
        {SailorOrderType.USE, "Use"},
        {SailorOrderType.BUILD, "Build"},
        {SailorOrderType.UPGRADE, "Upgrade"},
        {SailorOrderType.DESTROY, "Destroy"},
        {SailorOrderType.REPAIR, "Repair"},
        {SailorOrderType.IGNORE_ORDER, "IgnorePlayerOrder"},
        {SailorOrderType.MAD, "GetMad"},
        {SailorOrderType.FIGHT, "FightSailor"},
        {SailorOrderType.FIGHTBACK, "FightBack"},
        {SailorOrderType.KILL, "GoKillSailor"},
        {SailorOrderType.QUIT, "Quit"},
        {SailorOrderType.COMA, "PassOut"},
        {SailorOrderType.DIE, "Die"},
    };
    private Material matRef;
    private Transform _transform;

    public GameObject mesh;
    public int colorFeedbackMatIndex;
    public Transform skeleton;
    public GameObject selectedFeedback;
    public GameObject drunkenFeedback;
    public GameObject beerGlass;
    public GameObject screwDriver;
    public GameObject hammer;
    public GameObject wrench;
    public GameObject vomitFX;
    public GameObject fightFX;
    public Transform vomitPos;
    public Sprite iconSprite;
    public Sprite paneSprite;

    [Header("Animation Stats")]
    public Animator anim;
    [Range(0, 1)]
    public float normalWalkAnimRatio;
    [Range(0, 1)]
    public float angryWalkAnimRatio;
    [Range(0, 1)]
    public float drunkWalkAnimRatio;

    [Header("Generic Stats")]
    public string sailorName;
    [HideInInspector]
    public string currentActionText;
    public float maxLife = 100;
    public float regenrationSpeed = 5;
    [Range(0,10)]
    public float walkSpeed;

    [Header("Drink Stats")]
    public float drinkSoundCheckInterval = 5;
    public float pukeCheckInterval = 2.5f;
    public float beerDrunkenPerSecond = 0.5f;
    public float beerDrinkingIncreasePerSecond = 0.01f;
    public float speedDrunk = 3.0f;
    public float speedDrunkIncreasePerSecond = 0.01f;
    public float speedUndrunk = 1.0f;
    [HideInInspector]
    public float speedUndrunkMultiplier = 1;
    public float speedUndrunkIncreasePerSecond = 0.01f;
    public float minTimeBeteweenWanderMoves = 1;
    public float maxTimeBeteweenWanderMoves = 5;
    [Range(-100, 100)]
    public float minDrunknessForHapiness = 25; //maybe just take the max for ignore order event ?
    [Range(-100, 100)]
    public float minDrunknessToBeDrunk = 50; //maybe just take the min for fight event ?
    [Range(-100, 100)]
    public float minDrunknessToReallyBeDrunk = 50;
    [Range(0, 10)]
    public float barWalkSpeed;
    [Range(0,100)]
    public float throwUpProba = 50;
    [Range(0, 100)]
    public float drinkSoundProba = 50;

    [Header("Fight Stats")]
    public float fightSoundInterval = 0.5f;
    public float minFightDuration = 1;
    public float maxFightDuration = 3;
    public float fightDamage = 10;
    public float fightBackDamage = 5;

    [Header("Coma Stats")]
    public float minPassOutDuration = 1;
    public float maxPassOutDuration = 5;

    [Header("Mad Stats")]
    public int objectDestroyNb = 3;
    public float minOjectDestroyDuration = 1;
    public float maxOjectDestroyDuration = 4;

    [Header("Sailor State")]
    public float life = 100;
    [Range(-100, 100)]
    public float drunkness = 0;
    [HideInInspector]
    public SailorOrder currentOrder = new SailorOrder();
    private bool isAtBar;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        configRef = SailorManager.instance.sailorsConfig;
        life = maxLife;
        matRef = mesh.GetComponent<Renderer>().materials[colorFeedbackMatIndex];
        _transform = GetComponent<Transform>();
        _transform.position = configRef.spawnPoints[Random.Range(0, configRef.spawnPoints.Count)].position;
        StartCoroutine("EventsChecker");
    }

    void Update() {
        if (currentOrder.type == SailorOrderType.DIE) {
            return;
        }

        beerDrunkenPerSecond += beerDrinkingIncreasePerSecond * Time.deltaTime * SailorManager.instance.drunknessRateMultiplier;
        speedDrunk += speedDrunkIncreasePerSecond * Time.deltaTime * SailorManager.instance.drunknessRateMultiplier;
        speedUndrunk += speedUndrunkIncreasePerSecond * Time.deltaTime * SailorManager.instance.drunknessRateMultiplier;


        if (isAtBar && RessourcesManager.instance.beerNb > 0) {
            drunkness += Time.deltaTime * speedDrunk * SailorManager.instance.drunknessRateMultiplier;
            life = Mathf.Min(maxLife, life + regenrationSpeed * Time.deltaTime);
            RessourcesManager.instance.AddBeer(-beerDrunkenPerSecond * Time.deltaTime * SailorManager.instance.drunknessRateMultiplier);
        }
        else {
            drunkness -= Time.deltaTime * speedUndrunk * speedUndrunkMultiplier * SailorManager.instance.drunknessRateMultiplier;
        }

        drunkness = Mathf.Clamp(drunkness, -100, 100);

        if (life <= 0) {
            StopAllCoroutines();
            GiveOrder(SailorOrderType.DIE);
        }

        anim.SetFloat("NormalWalkSpeed", agent.speed * normalWalkAnimRatio);
        anim.SetFloat("AngryWalkSpeed", agent.speed * angryWalkAnimRatio);
        anim.SetFloat("DrunkWalkSpeed", agent.speed * drunkWalkAnimRatio);

        anim.SetBool("Angry", drunkness < minDrunknessForHapiness);
        anim.SetBool("Drunk", drunkness > minDrunknessToReallyBeDrunk);
        drunkenFeedback.SetActive(drunkness > minDrunknessToBeDrunk);


        //putain c'est pas opti tout ça...
        matRef.SetFloat("_Enable", 0);
        for (int i = 0; i < configRef.sailorColorFeedbacks.Count; i++) {
            if (drunkness > configRef.sailorColorFeedbacks[i].minDrunkness && drunkness < configRef.sailorColorFeedbacks[i].maxDrunkness) {
                matRef.SetColor("_FresnelColor", configRef.sailorColorFeedbacks[i].color);
                matRef.SetFloat("_PulsingSpeed", configRef.sailorColorFeedbacks[i].flashSpeed);
                matRef.SetFloat("_Enable", 1);
                break;
            }
        }
    }

    public void GiveOrder(SailorOrderType type, Vector3? destination = null, Furniture objectTarget = null, Sailor sailorTarget = null, float alocatedTime = 9001) {
        if (!orderRoutines.ContainsKey(type)) {
            Debug.LogError("Behaviour not implmented! Order:" + type);
            return;
        }

        if (configRef.ordersPriority[type] >= configRef.ordersPriority[currentOrder.type]) {
            ResetSailorState();

            currentOrder.type = type;
            currentOrder.destination = destination;
            currentOrder.furnitureTarget = objectTarget;
            currentOrder.sailorTarget = sailorTarget;
            currentOrder.alocatedTime = alocatedTime;

            currentActionText = configRef.actionMessageTexts[type][Random.Range(0, configRef.actionMessageTexts[type].Count)];

            StartCoroutine(orderRoutines[type]);
        }
    }

    public void ResetSailorState() {
        speedUndrunkMultiplier = 1;
        isAtBar = false;
        beerGlass.SetActive(false);
        screwDriver.SetActive(false);
        hammer.SetActive(false);
        wrench.SetActive(false);
        fightFX.SetActive(false);
        anim.SetBool("Drink", false);
        anim.SetBool(currentFurnitureAnim, false);
        anim.SetBool("Walk", false);
        anim.SetBool("Fight", false);
        anim.SetBool("Stab", false);
        anim.SetBool("Ignore", false);
        anim.SetBool("Destroy", false);
        agent.speed = walkSpeed;

        StopCoroutine("MoveTowardDestination");
        StopCoroutine("MoveTowardMovingTarget");
        StopCoroutine("ObjectAction");
        agent.Stop();

        skeleton.SetParent(_transform, true);
        skeleton.localPosition = Vector3.zero;
        skeleton.localRotation = Quaternion.identity;

        if (orderRoutines.ContainsKey(currentOrder.type))
            StopCoroutine(orderRoutines[currentOrder.type]);

        if(currentOrder.furnitureTarget != null) 
            currentOrder.furnitureTarget.OnActionEnd(currentOrder.type);

        currentOrder.type = SailorOrderType.NONE;
    }

    private Sailor GetCloserSailor() {
        Sailor sailorSelectToFight = null;
        float minDist = Mathf.Infinity;

        if (SailorManager.instance.sailorsList.Count > 1) {
            foreach (Sailor s in SailorManager.instance.sailorsList) {
                if (s != this && configRef.ordersPriority[s.currentOrder.type] <= configRef.ordersPriority[currentOrder.type]) {
                    float dist = Vector3.Distance(_transform.position, s.gameObject.transform.position);

                    if (dist < minDist) {
                        minDist = dist;
                        sailorSelectToFight = s;
                    }
                }
            }
        }
        return sailorSelectToFight;
    }

    IEnumerator EventsChecker() {
        while (true) {
            List<int> eventsToCheck = new List<int>();
            eventsToCheck.AddRange(System.Linq.Enumerable.Range(0, configRef.sailorEvents.Count)); // the list then contains all the events indexes
            while (eventsToCheck.Count > 0) {
                int randIndex = eventsToCheck[Random.Range(0, eventsToCheck.Count)];
                SailorEvent randomEvent = configRef.sailorEvents[randIndex];

                if (drunkness >= randomEvent.minDrunkness && drunkness <= randomEvent.maxDrunkness && !(randomEvent.cantHappendWhileDrinking && currentOrder.type == SailorOrderType.DRINK && RessourcesManager.instance.beerNb > 0) && currentOrder.type != randomEvent.orderType) {
                    if(Random.Range(0,100) < randomEvent.probability) {
                        GiveOrder(randomEvent.orderType);
                        break;
                    }
                }

                eventsToCheck.Remove(randIndex);
            }

            yield return new WaitForSeconds(configRef.eventCheckerInterval);
        }
    }

    IEnumerator LookTowardTarget(Quaternion targetRotation) {
        agent.updateRotation = false;
        Quaternion myRot = Quaternion.Euler(_transform.rotation.eulerAngles);
        float rotationDuration = Mathf.Abs((myRot.eulerAngles.y - targetRotation.eulerAngles.y)) / (agent.angularSpeed * agent.speed);
        float elapsedTime = 0;

        while (elapsedTime < rotationDuration) {
            elapsedTime += Time.deltaTime;
            _transform.rotation = Quaternion.Slerp(myRot, targetRotation, elapsedTime / rotationDuration);
            yield return null;
        }

        _transform.rotation = targetRotation;
        agent.updateRotation = true;
    }
    
    IEnumerator MoveTowardDestination(Vector3 dest) {
        anim.SetBool("Walk", true);
        agent.SetDestination(dest);
        agent.Resume();
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance) {
            yield return null;
        }
        anim.SetBool("Walk", false);
    }
    
    IEnumerator MoveTowardMovingTarget(Transform target) {
        anim.SetBool("Walk", true);
        agent.Resume();
        do {
            agent.SetDestination(target.position);
            yield return null;
        } while (target.position != null && (agent.pathPending || agent.remainingDistance > agent.stoppingDistance));
        anim.SetBool("Walk", false);
    }

    IEnumerator Go_Drink() {
        ResetSailorState();
        GiveOrder(SailorOrderType.DRINK);
        yield return null;
    }

    IEnumerator Drink() {
        yield return StartCoroutine("MoveTowardDestination", configRef.barRefilingStations[Random.Range(0, configRef.barRefilingStations.Count)].position);
        isAtBar = true;
        agent.speed = barWalkSpeed;
        float soundTimer = drinkSoundCheckInterval;
        float pukeTimer = pukeCheckInterval;

        while(true) {
            beerGlass.SetActive(false);
            anim.SetBool("Drink", false);
            yield return new WaitForSeconds(1);
            yield return StartCoroutine("MoveTowardDestination", configRef.barWanderPoints[Random.Range(0, configRef.barWanderPoints.Count)].position);
            anim.SetBool("Drink", true);
            beerGlass.SetActive(true);

            float nextPointTimer = Random.Range(minTimeBeteweenWanderMoves, maxTimeBeteweenWanderMoves);

            while (nextPointTimer > 0) {
                nextPointTimer -= Time.deltaTime;
                if (RessourcesManager.instance.beerNb <= 0) {
                    break;
                }

                soundTimer -= Time.deltaTime;
                if (soundTimer < 0) {
                    soundTimer = drinkSoundCheckInterval;

                    if (Random.Range(0, 100) < drinkSoundProba) {
                        SoundManager.instance.PlaySound("Drink", false, _transform.position);
                    }
                }

                pukeTimer -= Time.deltaTime;
                if (pukeTimer < 0) {
                    pukeTimer = pukeCheckInterval;
                    if (drunkness > minDrunknessToReallyBeDrunk && Random.Range(0, 100) < throwUpProba) {
                        StartCoroutine(Puke());
                    }
                }

                yield return null;
            }
        }
    }

    IEnumerator Puke() {
        anim.SetTrigger("Puke");
        SoundManager.instance.PlaySound("Puke", false, _transform.position);
        yield return new WaitForSeconds(1);
        Instantiate(vomitFX, vomitPos.position, Quaternion.Euler(90, 270, 0));
    }

    IEnumerator Use() {

        if (currentOrder.furnitureTarget.life / currentOrder.furnitureTarget.maxLife > currentOrder.furnitureTarget.brokenStateLifePercent) {
            currentFurnitureAnim = "Build";
            StartCoroutine("ObjectAction");
        }
        else {
            currentOrder.type = SailorOrderType.NONE;
        }
        yield return null;
    }

    IEnumerator Build() {
        hammer.SetActive(true);
        currentFurnitureAnim = "Build";
        yield return StartCoroutine("ObjectAction");
        hammer.SetActive(false);
    }

    IEnumerator Repair() {
        wrench.SetActive(true);
        currentFurnitureAnim = "Repair";
        SoundManager.instance.PlaySound("Repair Begin");
        yield return StartCoroutine("ObjectAction");
        wrench.SetActive(false);
    }

    IEnumerator Upgrade() {
        hammer.SetActive(true);
        currentFurnitureAnim = "Build";
        yield return StartCoroutine("ObjectAction");
        hammer.SetActive(false);
    }

    IEnumerator Destroy() {
        wrench.SetActive(true);
        SoundManager.instance.PlaySound("Destroy Begin");
        currentFurnitureAnim = "Remove";
        yield return StartCoroutine("ObjectAction");
        wrench.SetActive(false);
    }

    IEnumerator ObjectAction() {
        if (currentOrder.destination == null || currentOrder.furnitureTarget == null) {
            Debug.LogError("Object Action with invalid order. order: " + currentOrder.ToString());
            currentOrder.type = SailorOrderType.NONE;
            yield break;
        }

        yield return StartCoroutine("MoveTowardDestination", (Vector3)currentOrder.destination);
        yield return StartCoroutine(LookTowardTarget(currentOrder.furnitureTarget.sailorTarget.rotation));

        if (currentOrder.furnitureTarget != null) {
            anim.SetBool(currentFurnitureAnim, true);
            currentOrder.furnitureTarget.OnActionStart(this, currentOrder.type);
        }

        while (currentOrder.furnitureTarget != null && !currentOrder.furnitureTarget.isIdle && currentOrder.alocatedTime > 0) {
            currentOrder.alocatedTime -= Time.deltaTime;
            yield return null;
        }

        anim.SetBool(currentFurnitureAnim, false);
        currentOrder.type = SailorOrderType.NONE;
    }

    IEnumerator MoveAround() {
        if (currentOrder.destination == null) {
            Debug.LogError("MoveAround Action with invalid order. order: " + currentOrder.ToString());
            currentOrder.type = SailorOrderType.NONE;
            yield break;
        }

        yield return StartCoroutine("MoveTowardDestination", (Vector3)currentOrder.destination);

        currentOrder.type = SailorOrderType.NONE;
    }

    IEnumerator PassOut() {
        SoundManager.instance.PlaySound("Coma", false, _transform.position);
        anim.SetBool("Coma", true);
        yield return new WaitForSeconds(Random.Range(minPassOutDuration, maxPassOutDuration));
        anim.SetBool("Coma", false);
        yield return new WaitForSeconds(3);

        currentOrder.type = SailorOrderType.NONE;
    }

    IEnumerator GetMad() {
        Furniture[] furnitures = GameObject.FindObjectsOfType<Furniture>();
        Furniture[] visitedObjects = new Furniture[objectDestroyNb];
        int objectsHitNb = 0;

        SoundManager.instance.PlaySound("Crisis", false, _transform.position);

        while (objectsHitNb < objectDestroyNb && furnitures.Length > 0) {

            do {
                currentOrder.furnitureTarget = furnitures[Random.Range(0, furnitures.Length)];
            } while (furnitures.Length > visitedObjects.Length && System.Array.IndexOf(visitedObjects, currentOrder.furnitureTarget) != -1);

            if (currentOrder.furnitureTarget.sailorTarget != null && currentOrder.furnitureTarget.isBuilt) {
                yield return StartCoroutine("MoveTowardDestination", currentOrder.furnitureTarget.sailorTarget.position);
                if (currentOrder.furnitureTarget.sailorTarget != null)
                    yield return StartCoroutine(LookTowardTarget(currentOrder.furnitureTarget.sailorTarget.rotation));
                if (currentOrder.furnitureTarget.sailorTarget != null) {
                    anim.SetBool("Destroy", true);
                    currentOrder.furnitureTarget.OnActionStart(this, SailorOrderType.DESTROY);
                }

                float destructionTimer = Random.Range(minOjectDestroyDuration, maxOjectDestroyDuration);
                while (currentOrder.furnitureTarget != null && destructionTimer > 0 && currentOrder.furnitureTarget.life > 0) {
                    destructionTimer -= Time.deltaTime;
                    yield return null;
                }

                anim.SetBool("Destroy", false);

                if (currentOrder.furnitureTarget != null)
                    currentOrder.furnitureTarget.OnActionEnd(SailorOrderType.DESTROY);
            }

            visitedObjects[objectsHitNb] = currentOrder.furnitureTarget;
            objectsHitNb++;
        }
        currentOrder.type = SailorOrderType.NONE;
    }

    IEnumerator FightSailor() {
        currentOrder.sailorTarget = GetCloserSailor();
        if (currentOrder.sailorTarget == null) {
            currentOrder.type = SailorOrderType.NONE;
            yield break;
        }

        yield return StartCoroutine("MoveTowardMovingTarget", currentOrder.sailorTarget._transform);
        yield return StartCoroutine(LookTowardTarget(currentOrder.sailorTarget._transform.rotation));

        if (currentOrder.sailorTarget == null) {
            currentOrder.type = SailorOrderType.NONE;
            yield break;
        }

        anim.SetBool("Fight", true);
        fightFX.SetActive(true);
        currentOrder.sailorTarget.GiveOrder(SailorOrderType.FIGHTBACK, null, null, this);

        float timer = Random.Range(minFightDuration, maxFightDuration);
        float soundTimer = fightSoundInterval;
        while (currentOrder.sailorTarget != null && timer > 0 && currentOrder.sailorTarget.life > 0) {
            soundTimer -= Time.deltaTime;
            if (soundTimer < 0) {
                soundTimer = fightSoundInterval;
                SoundManager.instance.PlaySound("Fight", false, _transform.position);
            }

            currentOrder.sailorTarget.life -= fightDamage * Time.deltaTime;
            timer -= Time.deltaTime;
            yield return null;
        }
        
        anim.SetBool("Fight", false);
        fightFX.SetActive(false);
        currentOrder.type = SailorOrderType.NONE;
    }

    IEnumerator FightBack() {
        if (currentOrder.sailorTarget == null) {
            Debug.LogError("FightBack Action with invalid order. order: " + currentOrder.ToString());
            currentOrder.type = SailorOrderType.NONE;
            yield break;
        }

        yield return StartCoroutine("MoveTowardMovingTarget", currentOrder.sailorTarget._transform);
        StartCoroutine(LookTowardTarget(currentOrder.sailorTarget._transform.rotation * Quaternion.Euler(0, 180, 0)));
        anim.SetBool("Fight", true);

        while (currentOrder.sailorTarget != null && currentOrder.sailorTarget.life > 0 && currentOrder.sailorTarget.currentOrder.type == SailorOrderType.FIGHT) {
            currentOrder.sailorTarget.life -= fightBackDamage * Time.deltaTime;
            yield return null;
        }

        anim.SetBool("Fight", false);
        currentOrder.type = SailorOrderType.NONE;
    }

    IEnumerator GoKillSailor() {
        screwDriver.SetActive(true);
        currentOrder.sailorTarget = GetCloserSailor();
        if (currentOrder.sailorTarget != null) {
            yield return StartCoroutine("MoveTowardMovingTarget", currentOrder.sailorTarget._transform);

            anim.SetBool("Stab", true);
            currentOrder.sailorTarget.GiveOrder(SailorOrderType.DIE);
            yield return new WaitForSeconds(1);
        }
        anim.SetBool("Stab", false);
        currentOrder.type = SailorOrderType.NONE;
    }

    IEnumerator Quit() {
        anim.SetBool("Ignore", true);
        yield return new WaitForSeconds(4);

        InfoMessagesList.instance.AddMessage("SailorQuit");
        SoundManager.instance.PlaySound("Death");
        SailorManager.instance.RemoveSailor(this);
    }

    IEnumerator Die() {
        life = 0;
        anim.SetBool("Death", true);
        yield return new WaitForSeconds(3.5f);
        InfoMessagesList.instance.AddMessage("SailorDied");
        SoundManager.instance.PlaySound("Death", false, _transform.position);
        SailorManager.instance.RemoveSailor(this);
    }

    IEnumerator IgnorePlayerOrder() {
        SoundManager.instance.PlaySound("Ignore Orders", false, _transform.position);
        anim.SetBool("Ignore", true);
        yield return new WaitForSeconds(4);
        anim.SetBool("Ignore", false);

        currentOrder.type = SailorOrderType.NONE;
        GiveOrder(SailorOrderType.DRINK);
    }
}