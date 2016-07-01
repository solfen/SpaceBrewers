using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    private Camera      camera;
    private Transform   _transform;

    //Var for Move
    private bool canMove = false;
    [Header("Move")]
    public float speed = 10.0f;
    private float limitminX;
    private float limitmaxX;
    private float limitminZ;
    private float limitmaxZ;

    [Header("Target")]
    public GameObject targetLookAt;
    //Var for zoom perspective
    [Header("Zoom Perspective")]
    public bool useDistance = true;
    public bool useLerp = false;
    public float persp_distance = 60.0f;
    public float persp_sensitivityDistance = 50.0f;
    public float persp_damping = 5.0f;
    private bool  persp_useFOV = false;
    public float persp_minFOV = 40.0f;
    public float persp_maxFOV = 100.0f;
    private bool  persp_useDistance = true;
    public float persp_minDistance = -16.0f;
    public float persp_maxDistance = -60.0f;
    [Header("Limitation")]
    public int minDist = 4;
    public int maxDist = 100;

    //Var for zoom orthographic
    [Header("Zoom Orthogonal")]
    public bool useOrtho = false;
    public float ortho_size = 30.0f;
    public float ortho_sensitivitySize = 50.0f;
    public float ortho_damping = 5.0f;
    public float ortho_minSize = 30.0f;
    public float ortho_maxSize = 60.0f;
    
    //Var for rotateAround
    [Header("Rotate Around")]
    public Transform baseObjectRotation;
    public bool canRotateFreely = false;
    public float fixRotationValue = 45.0f;
    public float rotationSpeed = 3.0f;
    private float newAngle = 0.0f;
    public float rotationTime = 1000.0f;
    private bool positiveAngle = true;

    public GameObject cameraArms;

    public float timeTakenDuringLerp = 1f;

    public float distanceToMove = 10;
    private bool _isLerping;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _timeStartedLerping;

    [Header("AutoMoveOnBounces")]
    public float detectionDistance = 10.0f;
    public float moveSpeedScreenBounces = 10.0f;
    public bool isOnBounces = false;

    void Awake()
    {
        camera = this.GetComponent<Camera>();
        _transform = this.transform;
        newAngle = 0.0f;
    }

	// Use this for initialization
	void Start ()
    {
        if (persp_useFOV)
        {
            persp_distance = persp_minFOV;
        }
        else
        {
            persp_distance = persp_minDistance;
        }
        if (MapEditor.instance != null)
        {
            limitminX = MapEditor.instance.mapWidth * -1f;
            limitmaxX = MapEditor.instance.mapWidth * 1f;
            limitminZ = MapEditor.instance.mapHeight * -1f;
            limitmaxZ = MapEditor.instance.mapHeight * 1f;
	    }
    }

	// Update is called once per frame
	void Update ()
    {
        if (GameData.instance != null)
        {
            if (GameData.instance.isControlsBlocked) {
                return;
            }
        }

        SetCameraControl();
        Zoom(Time.unscaledDeltaTime);
        if (CheckMouseBouncesScreen())
        {
           // MoveBounces();
        }
        else
        {
            Move(Time.unscaledDeltaTime);
        }
        Rotate(Time.unscaledDeltaTime);
	}

    bool CheckMouseBouncesScreen()
    {
        Vector3 mousePos = Input.mousePosition;

        if (mousePos.x >= 0 && mousePos.x <= detectionDistance ||
            mousePos.x <= Screen.width && (mousePos.x >= Screen.width - detectionDistance) ||
            mousePos.y >= 0 && mousePos.y <= detectionDistance ||
            mousePos.y <= Screen.height && mousePos.y >= Screen.height - detectionDistance)    
        {
            return true;
        }
        return false;
    }

    void MoveBounces()
    {
        Vector3 mousePos = Input.mousePosition;

        if (mousePos.x <= 0 + detectionDistance)
        {
            cameraArms.transform.Translate(-moveSpeedScreenBounces, 0, 0, Space.Self);
        }
        else if (mousePos.x >= Screen.width - detectionDistance)
        {
            cameraArms.transform.Translate(moveSpeedScreenBounces, 0, 0, Space.Self);
        }
        if (mousePos.y <=  0 + detectionDistance)
        {
            cameraArms.transform.Translate(0, 0, -moveSpeedScreenBounces, Space.Self);
        }
        else if (mousePos.y >= Screen.height - detectionDistance)
        {
            cameraArms.transform.Translate(0, 0, moveSpeedScreenBounces, Space.Self);
        }
    }

    void SetCameraControl()
    {
        if (useDistance)
        {
            useOrtho = false;
            if (persp_useFOV)
            {
                persp_useDistance = false;
            }
            else
            {
                persp_useDistance = true;
            }
        }
        else
        {
            useDistance = false;
        }
    }

    float percentageComplete;

    void StartLerping()
    {
        if (!_isLerping)
        {
            _timeStartedLerping = Time.time;
            _startPosition = transform.position;
            distanceToMove = persp_distance - _startPosition.z;
            _endPosition = _startPosition + _transform.forward * distanceToMove;
            _isLerping = true;
        }
        else
        {
            distanceToMove += persp_distance;
            _endPosition = _startPosition + _transform.forward * distanceToMove;
        }
    }


    void Zoom(float deltatime)
    {
        float MouseWheelValue = Input.GetAxis("Mouse ScrollWheel");

        if (!camera.orthographic)
        {
            persp_distance += MouseWheelValue * persp_sensitivityDistance;
            persp_distance = Mathf.Clamp(persp_distance, persp_maxDistance, persp_minDistance);

            if (persp_useDistance)
            {
                if (useLerp)
                {
                    if (MouseWheelValue != 0)
                    {
                        StartLerping();
                    }
                    if (_isLerping)
                    {
                        float timeSinceStarted = Time.time - _timeStartedLerping;
                        percentageComplete = timeSinceStarted / timeTakenDuringLerp;

                        _transform.position = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);
                        if (percentageComplete >= 1.0f)
                        {
                            _isLerping = false;
                        }
                    }
                }
                else
                {
                    Transform bar = null;
                    float distance = 0.0f;
                    _transform.Translate(_transform.forward * persp_sensitivityDistance * MouseWheelValue, Space.World);

                    if (MapEditor.instance != null && MapEditor.instance.GetBarInstance() != null)
                    {
                        bar = MapEditor.instance.GetBarInstance().transform;
                        distance = Vector3.Distance(transform.position, bar.position);
                    }
                    else
                    {
                        distance = Vector3.Distance(transform.position, new Vector3(0.0f, -0.25f, 0.0f));
                    }

                    if (distance > maxDist || _transform.position.y < minDist)
                    {
                        _transform.Translate(-_transform.forward * persp_sensitivityDistance * MouseWheelValue, Space.World);
                    }

                    SoundManager.instance.SetSoundParam("Play_AMB", (distance - minDist) / (maxDist - minDist) * 100);
                }
            }

            if (persp_useFOV)
            {
                persp_distance = Mathf.Clamp(persp_distance, persp_minFOV, persp_maxFOV);
                camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, persp_distance, deltatime * persp_damping);
            }
        }
        else 
        {
            ortho_size -= MouseWheelValue * ortho_sensitivitySize;
            ortho_size = Mathf.Clamp(ortho_size, ortho_minSize, ortho_maxSize);
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, ortho_size, deltatime * ortho_damping);
        }
    }

    void Move(float deltatime)
    {

        if (Input.GetMouseButtonDown(1))
        {
            canMove = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            canMove = false;
        }
        if (canMove)
        {
            float addX = -Input.GetAxis("Mouse X") * speed;
            float addY = -Input.GetAxis("Mouse Y") * speed;
            float mouseWheelValue = Input.GetAxis("Mouse ScrollWheel");


            if (mouseWheelValue == 0)
            {
                cameraArms.transform.Translate(addX, 0, 0, Space.Self);
                if (cameraArms.transform.position.x < limitminX || cameraArms.transform.position.x > limitmaxX)
                {
                    cameraArms.transform.Translate(-addX, 0, 0, Space.Self);
                }
                cameraArms.transform.Translate(0, 0, addY, Space.Self);
                if (cameraArms.transform.position.z < limitminZ || cameraArms.transform.position.z > limitmaxZ)
                {
                    cameraArms.transform.Translate(0, 0, -addY, Space.Self);
                }
            }
        }
    }

    void Rotate(float deltatime)
    {
            if (!canRotateFreely)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    newAngle += fixRotationValue;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    newAngle -= fixRotationValue;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    newAngle +=  1.0f;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    newAngle -= 1.0f;
                }
            }
            if (newAngle > 0.0f && !positiveAngle)
            {
                positiveAngle = true;
            }
            if (newAngle < 0.0f && positiveAngle)
            {
                positiveAngle = false;
            }
            float test = newAngle % 360;
            if (test > 0 || (test < 0 && newAngle < 0))
                newAngle = test;
        if ( newAngle > 0.0f && positiveAngle || newAngle < 0.0f && !positiveAngle)
        {
            float frameNeededToCompleteRotation = newAngle / deltatime;
            rotationSpeed = frameNeededToCompleteRotation / (rotationTime * 60);

            //_transform.RotateAround(baseObjectRotation.position, Vector3.up, deltatime * rotationSpeed);
            cameraArms.transform.RotateAround(baseObjectRotation.position, Vector3.up, deltatime * rotationSpeed);
            if (newAngle > 0.0f && positiveAngle)
            {
                newAngle -= deltatime * rotationSpeed;
            }
            else if (newAngle < 0.0f && !positiveAngle)
            {
                newAngle -= deltatime * rotationSpeed;
            }
            if (newAngle < 0.0f && positiveAngle)
            {
                newAngle = 0.0f;
            }
            else if (newAngle > 0.0f && !positiveAngle)
            {
                newAngle = 0.0f;
            }
        }
    }

    public void SetRotationFree()
    {
        canRotateFreely = !canRotateFreely;
    }
}
