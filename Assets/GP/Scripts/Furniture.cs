using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Furniture : MonoBehaviour
{
    [Header("Characteristics")]
    public bool isPreconstructed;
    public ObjectCategory category;
    public string description;
    public string idleSoundName;
    public float moneyCost;
    public float maxLife = 100.0f;
    public float life = 100.0f;
    public float scoreValue = 100;
    public float degradationRate = 0.5f;
    [Range(0,1)]
    public float brokenStateLifePercent = 0.5f;
    public float repairPercentCostMultiplier;
    [HideInInspector]
    public Vector2 objectSize;

    [Header("Upgrade Constraints")]
    public int maxUpgradeNb;
    public float lifeUpgradeMultiplier;
    public float costUpgradeMutiplier;
    [HideInInspector]
    public int currentUpgradeLvl = 0;

    [Header("Timers")]
    public float buildDuration = 5;
    public float completeRepairDuration = 5;
    public float upgradeDuration = 5;
    public float destroyDamagePerSecond = 5;
    public float useDuration = 60;
    private float buildTimer = 0;
    private float upgradeTimer = 0;

    [Header("Childrens")]
    public MeshRenderer sizePlaneRenderer;
    public Transform sizePlaneTransform;
    public Transform sailorTarget;
    public ParticleSystem upgradeFX;
    public ParticleSystem explosionFX;
    public ParticleSystem selectedFX;

    [Header("Meshs")]
    public GameObject wireframeMesh;
    public GameObject normalMesh;
    public GameObject brokenMesh;
    public GameObject destroyedMesh;
    private MeshType currentMeshType;
    private ObjectInterface specializedBehaviour;

    private FMOD_Event_Player buildSound;
    private FMOD_Event_Player repairSound;
    private FMOD_Event_Player upgradeSound;
    private FMOD_Event_Player destroySound;
    private FMOD_Event_Player idleSound;

    [HideInInspector]
    public bool isPlaced = false;
    [HideInInspector]
    public bool isBuilt = false;
    [HideInInspector]
    public bool isIdle = true;
    [HideInInspector]
    public Sailor currentSailor;

    private Dictionary<SailorOrderType, string> actionsRoutines = new Dictionary<SailorOrderType, string>() {
        {SailorOrderType.BUILD, "Build"},
        {SailorOrderType.REPAIR, "Repair"},
        {SailorOrderType.UPGRADE, "Upgrade"},
        {SailorOrderType.DESTROY, "Destroy"},
        {SailorOrderType.USE, "Use"},
    };

    private enum MeshType {
        WIRE,
        NORMAL,
        BROKEN,
        DESTROYED
    }

    private Dictionary<MeshType, GameObject> renderers;
    private Transform _transform;

	void Start () {
        renderers = new Dictionary<MeshType,GameObject>() {
            {MeshType.WIRE, wireframeMesh},
            {MeshType.NORMAL, normalMesh},
            {MeshType.BROKEN, brokenMesh},
            {MeshType.DESTROYED, destroyedMesh}
        };
        objectSize = new Vector2(sizePlaneTransform.localScale.x, sizePlaneTransform.localScale.z);
        specializedBehaviour = GetComponent<ObjectInterface>();

        if(isPreconstructed) {
            ChangeMesh(MeshType.NORMAL);
            StartCoroutine(UpdateLife());
            //StartCoroutine(LateStartToSetRoomCategory());
        }
        else {
            ChangeMesh(MeshType.WIRE);
        }

        _transform = GetComponent<Transform>();
	}

    IEnumerator LateStartToSetRoomCategory() {
        yield return new WaitForSeconds(1);
        SetRoomCategory();
    }

    IEnumerator Build() {
        buildSound = SoundManager.instance.PlaySound("Construct", false, _transform.position);

        buildTimer = buildTimer > 0 ? buildTimer : buildDuration;
        //SetRoomCategory();

        while (buildTimer >= 0) {
            float previsionMaxLife = Mathf.Lerp(1, 0, currentSailor.drunkness / 100) * maxLife;
            life = (int)(Mathf.Lerp(0, previsionMaxLife, 1 - (buildTimer / buildDuration)));
            buildTimer -= Time.deltaTime;
            yield return null;
        }

        GetComponent<BoxCollider>().enabled = true;
        GetComponent<NavMeshObstacle>().enabled = true;
        ChangeMesh(MeshType.NORMAL);

        if (idleSoundName != "")
            idleSound = SoundManager.instance.PlaySound(idleSoundName, false, _transform.position);

        if (specializedBehaviour != null) {
            specializedBehaviour.OnBuilded();
        }

        StartCoroutine(UpdateLife());

        isBuilt = true;
        isIdle = true;

        RessourcesManager.instance.AddScore(scoreValue);

        buildSound.StopSound();
    }

    IEnumerator Repair() {
        repairSound = SoundManager.instance.PlaySound("Repair", false, _transform.position);

        float repairPerSecond = 0;
        
        while (life < maxLife && life > 0 && RessourcesManager.instance.moneyNb > 0) {
            repairPerSecond = Mathf.Lerp(1, -0.35f, currentSailor.drunkness / 100) * (maxLife / completeRepairDuration);
            life += repairPerSecond * Time.deltaTime;
            RessourcesManager.instance.AddMoney(-maxLife / completeRepairDuration * Time.deltaTime / maxLife * moneyCost * repairPercentCostMultiplier);
            yield return null;
        }

        life = life > 0 ? maxLife : 0; // because if the sailor too drunk he can damage the object

        if (specializedBehaviour != null) {
            specializedBehaviour.OnRepaired();
        }

        isIdle = true;

        repairSound.StopSound();
    }

    IEnumerator Upgrade() {
        upgradeSound = SoundManager.instance.PlaySound("Upgrade Objects", false, _transform.position);

        RessourcesManager.instance.AddMoney(-moneyCost * costUpgradeMutiplier);

        upgradeTimer = upgradeTimer > 0 ? upgradeTimer : upgradeDuration;
        while (upgradeTimer >= 0) {
            upgradeTimer -= Time.deltaTime;
            yield return null;
        }

        maxLife *= lifeUpgradeMultiplier;
        moneyCost *= costUpgradeMutiplier;
        life = (int)(Mathf.Lerp(1, 0.25f, currentSailor.drunkness / 100) * maxLife);
        currentUpgradeLvl++;
        upgradeFX.Stop();
        upgradeFX.Play();

        if (specializedBehaviour != null) {
            specializedBehaviour.OnUpgraded();
        }

        isIdle = true;

        upgradeSound.StopSound();
    }

    IEnumerator Destroy() {
        destroySound = SoundManager.instance.PlaySound("Degrade", false, _transform.position);

        if (!isBuilt) {
            RessourcesManager.instance.AddMoney(moneyCost);
            destroySound.StopSound();
            Destroy(gameObject);
            yield break;
        }

        float furnitureStateRatio = (life / maxLife);
        while (life > 0) {
            life -= Time.deltaTime * destroyDamagePerSecond;
            yield return null;
        }

        float moneySalvaged = currentSailor.currentOrder.type == SailorOrderType.MAD ? 0 : RessourcesManager.instance.destructionRecuperationRate * furnitureStateRatio * moneyCost;
        RessourcesManager.instance.AddMoney(moneySalvaged);

        isIdle = true;
        destroySound.StopSound();
    }

    IEnumerator Use() {
        SoundManager.instance.PlaySound("Use Object", false, _transform.position);
        if (specializedBehaviour != null) {
            specializedBehaviour.OnUseBegin(currentSailor);
        }

        yield return new WaitForSeconds(useDuration);
        isIdle = true;

        if (specializedBehaviour != null) {
            specializedBehaviour.OnUseEnd();
        }
    }
    
    IEnumerator UpdateLife() {
        while (true) {
            if (!TutoManager.instance.isHappening)
                life -= degradationRate * Time.deltaTime;

            if (life <= 0 && !(currentSailor != null && currentSailor.currentOrder.type == SailorOrderType.DESTROY)) {
                SoundManager.instance.PlaySound("Destruct", false, _transform.position);
                MapEditor.instance.RemoveFurniture(gameObject);

                if (specializedBehaviour != null) {
                    specializedBehaviour.OnDestroyed();
                }

                ChangeMesh(MeshType.DESTROYED);
                explosionFX.Play();
                yield return new WaitForSeconds(5);
                Destroy(gameObject);
            }
            if (life < brokenStateLifePercent * maxLife && currentMeshType != MeshType.BROKEN) {
                ChangeMesh(MeshType.BROKEN);

                if (idleSound != null)
                    idleSound.StopSound();

                if (specializedBehaviour != null) {
                    specializedBehaviour.OnBroken();
                }
            }
            else if (life > brokenStateLifePercent * maxLife && currentMeshType != MeshType.NORMAL) {
                ChangeMesh(MeshType.NORMAL);
            }

            yield return null;
        }
    }

    public void OnSelected() {
        selectedFX.Stop();
        selectedFX.Play();
    }

    public void OnActionStart(Sailor sailor, SailorOrderType orderType) {
        if (!actionsRoutines.ContainsKey(orderType)) {
            Debug.LogError("Furniture OnActionStart ERROR: order" + orderType + " is not implemented");
            return;
        }

        currentSailor = sailor;
        isIdle = false;
        StartCoroutine(actionsRoutines[orderType]);
    }

    public void OnActionEnd(SailorOrderType orderType) {
        if (!actionsRoutines.ContainsKey(orderType)) {
            return;
        }

        StopCoroutine(actionsRoutines[orderType]);
        currentSailor = null;
        isIdle = true;

        if(buildSound != null)
            buildSound.StopSound();
        if(repairSound != null)
            repairSound.StopSound();
        if(upgradeSound != null)
            upgradeSound.StopSound();
        if (destroySound != null)
            destroySound.StopSound();

        if (orderType == SailorOrderType.USE && specializedBehaviour != null) {
            specializedBehaviour.OnUseEnd();
        }
    }

    private void SetRoomCategory() {
        int roomIndex = MapEditor.instance.GetRoomIndex((int)_transform.position.x, (int)_transform.position.z, 1, 1);
        MapEditor.instance.SetRoomCategory(roomIndex, category);
    }

    private void ChangeMesh(MeshType type) {
        renderers[MeshType.WIRE].SetActive(type == MeshType.WIRE);
        renderers[MeshType.NORMAL].SetActive(type == MeshType.NORMAL);
        renderers[MeshType.BROKEN].SetActive(type == MeshType.BROKEN);
        renderers[MeshType.DESTROYED].SetActive(type == MeshType.DESTROYED);

        currentMeshType = type;
    }
}