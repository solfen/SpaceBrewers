using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class MapEditor : MonoBehaviour
{
    public static MapEditor instance;
    public float floorHeight = -0.25f;
    void Awake()
    {
        instance = this;
    }

    [System.Serializable]
    private class MyRect
    {
        public MyRect()
        {
        }

        public MyRect(MyRect rect)
        {
            x = rect.x;
            y = rect.y;
            width = rect.width;
            height = rect.height;
            widthInWorld = rect.widthInWorld;
            heightInWorld = rect.heightInWorld;
        }

        public static bool operator==(MyRect A, MyRect B)
        {
            if (A.x == B.x &&
                A.y == B.y &&
                A.width == B.width &&
                A.height == B.height)
            {
                return true;
            }
            return false;
        }

        public static bool operator!=(MyRect A, MyRect B)
        {
            if (A.x != B.x ||
                A.y != B.y ||
                A.width != B.width ||
                A.height != B.height)
            {
                return true;
            }
            return false;
        }

        public void Copy(MyRect rect)
        {
            x = rect.x;
            y = rect.y;
            width = rect.width;
            height = rect.height;
            widthInWorld = rect.widthInWorld;
            heightInWorld = rect.heightInWorld;
        }

        public void SetRect(int xValue, int yValue, int widthValue, int heightValue, int widthInWorldValue = 0, int heightInWorldValue = 0)
        {
            x = xValue;
            y = yValue;
            width = widthValue;
            height = heightValue;
            widthInWorld = widthInWorldValue;
            heightInWorld = heightInWorldValue;
        }

        public void DisplayRectInfo()
        {
            Debug.Log("x: " + x + ", y: " + y + ", width: " + width + ", height: " + height);
        }

        public int x;
        public int y;
        public int width;
        public int height;
        private int widthInWorld;
        private int heightInWorld;
    };

    [System.Serializable]
    private class Room
    {
        public Room(GameObject map, int numberOfRoom)
        {
            parent = new GameObject("Room" + numberOfRoom.ToString());
            ground = new GameObject("Ground");
            wall = new GameObject("Wall");
            keyObject = new GameObject("KeyObject");

            parent.transform.SetParent(map.transform);
            ground.transform.SetParent(parent.transform);
            ground.layer = LayerMask.NameToLayer("Walkable");
            wall.transform.SetParent(parent.transform);
            keyObject.transform.SetParent(parent.transform);

            bridgeParent = new GameObject("Bridge");
            bridgeRight = new GameObject("bridgeRight");
            bridgeLeft = new GameObject("bridgeLeft");
            bridgeTop = new GameObject("bridgeTop");
            bridgeBot = new GameObject("bridgeBot");

            bridgeParent.transform.SetParent(parent.transform);
            bridgeRight.transform.SetParent(bridgeParent.transform);
            bridgeLeft.transform.SetParent(bridgeParent.transform);
            bridgeTop.transform.SetParent(bridgeParent.transform);
            bridgeBot.transform.SetParent(bridgeParent.transform);

            rect = new MyRect();
            rectBridgeRight = new List<MyRect>();
            rectBridgeLeft = new List<MyRect>();
            rectBridgeTop = new List<MyRect>();
            rectBridgeBot = new List<MyRect>();

            links = new Link();
            linksType = new List<linkType>();
            isWidthChange = false;
            isHeightChange = false;

            lines = new List<Line>();
        }

        public void CreateLines()
        {
            Line lineA = new Line();
            Line lineB = new Line();
            Line lineC = new Line();
            Line lineD = new Line();

            //Commence en bas a gauche en remontant
            lineA.A = new Vector2(rect.x, rect.y);
            lineA.B = new Vector2(rect.x, rect.y + rect.height);

            lineB.A = new Vector2(rect.x, rect.y + rect.height);
            lineB.B = new Vector2(rect.x + rect.width, rect.y + rect.height);

            lineC.A = new Vector2(rect.x + rect.width, rect.y + rect.height);
            lineC.B = new Vector2(rect.x + rect.width, rect.y);

            lineD.A = new Vector2(rect.x + rect.width, rect.y);
            lineD.B = new Vector2(rect.x, rect.y);

            if (lines.Count > 0)
            {
                lines.RemoveRange(0, lines.Count - 1);
            }

            lines.Add(lineA);
            lines.Add(lineB);
            lines.Add(lineC);
            lines.Add(lineD);
        }

        public void ResetBridgeRect()
        {
            foreach (MyRect rect in rectBridgeRight)
            {
                rect.SetRect(0, 0, 0, 0);
            }

            foreach (MyRect rect in rectBridgeLeft)
            {
                rect.SetRect(0, 0, 0, 0);
            }

            foreach (MyRect rect in rectBridgeTop)
            {
                rect.SetRect(0, 0, 0, 0);
            }

            foreach (MyRect rect in rectBridgeBot)
            {
                rect.SetRect(0, 0, 0, 0);
            }
            //needUpdate = true;
        }
        
        //Parent of mesh
        public GameObject parent;
        public GameObject ground;
        public GameObject wall;
        public GameObject keyObject;

        public GameObject bridgeParent;
        public GameObject bridgeRight;
        public GameObject bridgeLeft;
        public GameObject bridgeTop;
        public GameObject bridgeBot;

        public MyRect rect;

        public Link links;

        public List<Line> lines;

        public List<MyRect> rectBridgeRight;
        public List<MyRect> rectBridgeLeft;
        public List<MyRect> rectBridgeTop;
        public List<MyRect> rectBridgeBot;

        public List<linkType>       linksType;
        public specialisationType   specialisation;
        public state                state;
        public ObjectCategory       objectTypeAllow = ObjectCategory.NONE;
        public bool                 isWidthChange;
        public bool                 isHeightChange;
        public bool                 needUpdate;
    };

    [System.Serializable]
    private class Link
    {
        public Link()
        {
            roomsRight = new List<Room>();
            roomsLeft = new List<Room>();
            roomsTop = new List<Room>();
            roomsBot = new List<Room>();
        }

        [System.NonSerialized]
        public List<Room> roomsRight;
        [System.NonSerialized]
        public List<Room> roomsLeft;
        [System.NonSerialized]
        public List<Room> roomsTop;
        [System.NonSerialized]
        public List<Room> roomsBot;
    };

    private class LinkInfo
    {
        public linkType type;
        public Room     room;
        public int      indexLink;
    };

    private class ModifRoomInfo
    {
        public MyRect       lastFrameRect;
        public MyRect       lastRect;
        public modifSign    signWidth;
        public modifSign    signHeight;
    }

    private class Line
    {
        public Line() {}

        public Line(Vector2 pointA, Vector2 pointB)
        {
            A = pointA;
            B = pointB;
        }

        public string name = "empty";
        public Vector2 A;
        public Vector2 B;
        public Vector2 direction;
    }

    [System.Serializable]
    public class PreconstructRoom
    {
        public bool isBar;
        public GameObject prefab;
    };

    private enum type 
    {
        NONE,
        GROUND,
        BRIDGE,
        WALLGROUND,
        WALLBRIDGE,
        EXTERNALCORNER,
        INTERNALCORNER,
        DOOR,
        COUNT
    };

    private enum axis
    {
        NO_AXIS,
        X,
        Z,
        CORNER,
        COUNT
    };

    private enum linkType
    {
        NONE,
        TOP,
        BOT,
        LEFT,
        RIGHT,
        COUNT
    };

    private enum specialisationType
    {
        NONE,
        COUNT
    };

    private enum mainPhase
    {
        NONE,
        CREATE_ROOM,
        CREATE_WALL,
        CREATE_BRIDGE,
        CREATE_WALLBRIDGE,
        CREATE_CORNER,
        CREATE_INTERNAL_CORNER,
        COUNT
    }

    private enum state
    {
        NONE,
        BUILDING,
        FINISHED,
        COUNT
    }

    private enum modifSign
    {
        NONE,
        POSITIF,
        NEGATIF,
        COUNT
    };

    //Var for Assets
    [Header("Parent Object")]
    public GameObject mapParent;
    public GameObject gridParent;
    public GameObject displayObjectParent;

    [Header("Prefabs Object")]
    public GameObject ground;
    public GameObject wall;
    public GameObject externalCornerWall;
    public GameObject internalCornerWall;
    public GameObject door;
    public GameObject bridge;
    private GameObject grid;

    [Header("Map Specification")]
    public int mapWidth = 10;
    public int mapHeight = 10;
    public int offsetLimitMapX = 1;
    public int offsetLimitMapZ = 1;
    private Vector2 maxPos;
    private Vector2 minPos;

    [Header("Preconstruct room")]
    public List<PreconstructRoom> preconstructRooms;

    [Header("Room Specification")]
    public int widthMin = 4;
    public int heightMin = 4;
    public int widthSampleBridge = 2;
    public int heightSampleBridge = 2;

    [Header("Materials")]
    public Material gridMaterial;
    public Material wireframeMaterial;
    public Material finishedMaterial;

    [Header("Shader")]
    public Shader gridShader;
    public Shader wireframeShader;
    public Shader finishedShader;

    //Var for map
    private List<List<GameObject>>  map;
    private List<List<type>>        mapObjectType;

    //Var for UI
    private bool isInEditor = false;
    private bool isPhaseRoom = false;
    private bool isPhaseBridge = false;
    private bool isPhaseDoor = false;
    private bool isPhaseKeyObject = false;
    private bool isPhaseValidation = false;
    private GameObject preDisplayObjectInstance;
    private type predisplayObjectType = type.NONE;

    //Var for room creation
    private bool    mouseDown = false;
    private Vector2 mousePosition;
    private Vector2 lastMousePosition;
    private Vector3 mousePositionInWorld;
    private Vector2 displayDir = Vector2.zero;
    private Vector3 mousePosFirstClick;
    private ModifRoomInfo modifInfoRoom;

    private Room actualRoom;
    private List<Room> rooms;
    private int nbRoom = 1;
    private mainPhase creationPhase = mainPhase.CREATE_ROOM;

    private GameObject barInstance;
    private List<GameObject> roomsInstance;

    public List<GameObject> furnitures;

    

    //Use this var for pre-instanciate object in poolobject
    [Header("Object Pool setting")]
    public int groundPercent;
    public int bridgePercent;
    public int wallgroundPercent;
    public int wallbridgePercent;
    public int externalCornerPercent;
    public int internalCornerPercent;


    //[HideInInspector]
    public List<GameObject> groundPool;
    //[HideInInspector]
    public List<GameObject> bridgePool;
    //[HideInInspector]
    public List<GameObject> wallgroundPool;
    //[HideInInspector]
    public List<GameObject> wallbridgePool;
    //[HideInInspector]
    public List<GameObject> externalCornerPool;
    //[HideInInspector]
    public List<GameObject> internalCornerPool;

    //Var for debug
    private bool isAccessible = true;
    private bool needUpdate = false;

    //Do bridge block side
    public void BuildPreconstructRoom()
    {
        int addX = (int)(mapWidth * 0.5f);
        int addZ = (int)(mapHeight * 0.5f);

        roomsInstance = new List<GameObject>();
        foreach (PreconstructRoom room in preconstructRooms)
        {
            nbRoom++;
            Room newRoom = new Room(mapParent, nbRoom);

            if (room.prefab != null)
            {
                Vector3 size = GetSizeRoom(room.prefab, newRoom.rect);

                newRoom.rect.width = (int)size.x;
                newRoom.rect.height = (int)size.z;

                Line lineA = new Line();
                Line lineB = new Line();
                Line lineC = new Line();
                Line lineD = new Line();

                //Commence en bas a gauche en remontant
                lineA.A = new Vector2(newRoom.rect.x, newRoom.rect.y);
                lineA.B = new Vector2(newRoom.rect.x, newRoom.rect.y + newRoom.rect.height);

                lineB.A = new Vector2(newRoom.rect.x, newRoom.rect.y + newRoom.rect.height);
                lineB.B = new Vector2(newRoom.rect.x + newRoom.rect.width, newRoom.rect.y + newRoom.rect.height);

                lineC.A = new Vector2(newRoom.rect.x + newRoom.rect.width, newRoom.rect.y + newRoom.rect.height);
                lineC.B = new Vector2(newRoom.rect.x + newRoom.rect.width, newRoom.rect.y);

                lineD.A = new Vector2(newRoom.rect.x + newRoom.rect.width, newRoom.rect.y);
                lineD.B = new Vector2(newRoom.rect.x, newRoom.rect.y);

                newRoom.lines.Add(lineA);
                newRoom.lines.Add(lineB);
                newRoom.lines.Add(lineC);
                newRoom.lines.Add(lineD);

                rooms.Add(newRoom);

                if (room.isBar)
                {
                    barInstance = GameObject.Instantiate(room.prefab, new Vector3(room.prefab.transform.position.x, floorHeight, room.prefab.transform.position.z), room.prefab.transform.rotation) as GameObject;
                    newRoom.objectTypeAllow = ObjectCategory.BAR;
                }
                else
                {
                    roomsInstance.Add(GameObject.Instantiate(room.prefab, new Vector3(room.prefab.transform.position.x, floorHeight, room.prefab.transform.position.z), room.prefab.transform.rotation) as GameObject);
                    newRoom.objectTypeAllow = ObjectCategory.NONE;
                }
            }
        }
    }

    Vector3 GetSizeRoom(GameObject prefab, MyRect rect)
    {
        Transform parentGround = prefab.transform.GetChild(0);

        Vector3 minPos = new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);
        Vector3 maxPos = new Vector3(-Mathf.Infinity, -Mathf.Infinity, -Mathf.Infinity);

        for (int i = 0; i < parentGround.childCount; ++i)
        {
            Transform child = parentGround.GetChild(i);

            if (child.tag != "Bridge")
            {
                if (minPos.x >= child.position.x)
                {
                    minPos = new Vector3(child.position.x, minPos.y, minPos.z);
                }
                if (minPos.z >= child.position.z)
                {
                    minPos = new Vector3(minPos.x, minPos.y, child.position.z);
                }
                if (maxPos.x <= child.position.x)
                {
                    maxPos = new Vector3(child.position.x, maxPos.y, maxPos.z);
                }
                if (maxPos.z <= child.position.z)
                {
                    maxPos = new Vector3(maxPos.x, maxPos.y, child.position.z);
                }
            }
        }

        rect.x = (int)minPos.x;
        rect.y = (int)minPos.z;

        Vector3 size = minPos - maxPos;
        size.x = Mathf.Abs(size.x);
        size.y = Mathf.Abs(size.y);
        size.z = Mathf.Abs(size.z);

        Debug.Log("Name : " + prefab.name + ", size : " + size);
        return size;
    }

    // Use this for initialization
	void Start ()
    {
        //Time.timeScale = 1.0f;
	    if (ground == null)
            isAccessible = false;
        if (wall == null)
            isAccessible = false;
        if (door == null)
            isAccessible = false;
        if (mapParent == null)
        {
            isAccessible = false;
            Debug.Log("Can not found the map object");
        }
        if (gridParent == null)
        {
            isAccessible = false;
            Debug.Log("Can not found the grid object");
        }
        else
        {
            map = new List<List<GameObject>>();
            mapObjectType = new List<List<type>>();
            modifInfoRoom = new ModifRoomInfo();
            modifInfoRoom.lastFrameRect = new MyRect();
            modifInfoRoom.lastRect = new MyRect();

            actualRoom = new Room(mapParent, nbRoom);
            rooms = new List<Room>();

            grid = GameObject.CreatePrimitive(PrimitiveType.Plane);
            BoxCollider box = grid.GetComponent<BoxCollider>();
            if (box == null)
            {
                grid.AddComponent<BoxCollider>();
            }
            grid.transform.localScale = new Vector3(mapWidth / 10, 1, mapHeight / 10);
            if (gridMaterial != null)
            {
                grid.GetComponent<Renderer>().material = gridMaterial;
            }
            if (gridShader != null)
            {
                grid.GetComponent<Renderer>().material.shader = gridShader;
            }
            grid.transform.SetParent(gridParent.transform, false);

            InitializeMap();

            BuildPreconstructRoom();

            /*groundPool = new List<GameObject>();
            bridgePool = new List<GameObject>();
            wallgroundPool = new List<GameObject>();
            wallbridgePool = new List<GameObject>();
            externalCornerPool = new List<GameObject>();
            internalCornerPool = new List<GameObject>();*/

            //CreatePoolObject();

        }
    }
	
	// Update is called once per frame
    void Update()
    {
        if (isInEditor)
        {
            if (map != null)
            {
                if (map.Count != 0)
                {
                    /*if (map[0].Count != 0)
                    {
                        if (isAccessible)
                        {
                            gridParent.SetActive(true);
                            CheckMouseEvent();
                            PreDisplayObject();
                            if (CheckIsInMapLimit(mousePositionInWorld))
                            {
                                if (mouseDown)
                                {
                                    if (isPhaseRoom)
                                    {
                                        if (lastMousePosition != mousePosition)
                                        {
                                            ComputeDisplayDirection();
                                            ComputeRect();
                                            CheckRoomRect();
                                            SetRoomState();
                                        }
                                    }
                                }
                                //actualRoom.rect.DisplayRectInfo();
                                CheckRectDiff();
                                if (isPhaseValidation)
                                {
                                    if (ValidingCreation())
                                    {
                                        SaveRoom();
                                    }
                                    else
                                    {
                                        ResetRoom();
                                    }
                                    isPhaseValidation = false;
                                }
                                if (lastMousePosition != mousePosition)
                                {
                                    lastMousePosition = mousePosition;
                                }

                               ResetMap();

                                if (actualRoom.rect.width != 0 || actualRoom.rect.height != 0 &&
                                    actualRoom.rect.width > 1 || actualRoom.rect.height > 1 || needUpdate)// &&
                                 //   actualRoom.isWidthChange || actualRoom.isHeightChange || needUpdate)
                                {
                                    while (creationPhase != mainPhase.COUNT)
                                    {
                                        //if (actualRoom.isWidthChange || actualRoom.isHeightChange || needUpdate)
                                        {
                                            //Instanciate GameObject
                                            for (int i = offsetLimitMapX; i < map.Count - offsetLimitMapX; ++i)
                                            {
                                                for (int j = offsetLimitMapZ; j < map[i].Count - offsetLimitMapZ; ++j)
                                                {
                                                    if (isPhaseRoom)
                                                    {
                                                        if (CheckDontDestroyOtherRect(i, j, true, false))
                                                        {
                                                            if (creationPhase == mainPhase.CREATE_ROOM)
                                                            {
                                                                if (CheckIndexIsInRectBounces(i, j))
                                                                {
                                                                    AddGround(i, j);
                                                                    DisplayGround(i, j);
                                                                }
                                                                else
                                                                {
                                                                    if (map[i][j] != null)
                                                                    {
                                                                        ResetCase(i, j);
                                                                    }
                                                                }
                                                                needUpdate = true;
                                                            }

                                                            else if (creationPhase == mainPhase.CREATE_WALL)
                                                            {
                                                                if (CheckDontDestroyOtherRect(i, j, true, false))
                                                                {
                                                                    AddWall(i, j, true, creationPhase);
                                                                    DisplayWall(i, j);
                                                                }
                                                            }
                                                            else if (creationPhase == mainPhase.CREATE_CORNER)
                                                            {
                                                                AddExternalCorner(i, j);
                                                                DisplayExternalCorner(i, j);
                                                            }
                                                        }
                                                        if (creationPhase == mainPhase.CREATE_BRIDGE)
                                                        {
                                                            AddBridge();
                                                            DisplayBridge(i, j);
                                                            needUpdate = true;
                                                        }
                                                        if (creationPhase == mainPhase.CREATE_WALLBRIDGE)
                                                        {
                                                            if (CheckDontDestroyOtherRect(i, j, true, false))
                                                            {
                                                                AddWall(i, j, true, creationPhase);
                                                                DisplayWall(i, j);
                                                            }
                                                        }
                                                        if (creationPhase == mainPhase.CREATE_INTERNAL_CORNER)
                                                        {
                                                            AddInternalCorner(i, j);
                                                            DisplayInternalCorner(i, j);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //not phaseRoom
                                                    }
                                                }
                                            }
                                        }
                                        ++creationPhase;
                                    }
                                    creationPhase = mainPhase.CREATE_ROOM;
                                    needUpdate = false;
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("Error all assets was not set in the editor or map parent is invalid");
                        }
                    }
                    else
                    {
                        Debug.Log("Error map height = 0");
                    }*/
                }
                else
                {
                   InitializeMap();
                }
            }
            else
            {
                Debug.Log("Error Map is null");
            }
        }
        else
        {
            gridParent.SetActive(false);
        }
    }

    void InitializeMap()
    {
        int halfWidth = (int)(mapWidth * 0.5f);
        int halfHeight = (int)(mapHeight * 0.5f);

        maxPos = new Vector2(halfWidth - offsetLimitMapX, halfHeight - offsetLimitMapX);
        minPos = new Vector2(-halfWidth + offsetLimitMapX, -halfHeight + offsetLimitMapX);
        if (mapWidth != 0 && mapHeight != 0)
        {
            for (int i = -halfWidth; i <= halfWidth; ++i)
            {
                int indexWidth = i + halfWidth;

                map.Add(new List<GameObject>());
                mapObjectType.Add(new List<type>());
                for (int j = -halfHeight; j <= halfHeight; ++j)
                {
                    map[indexWidth].Add(null);
                    mapObjectType[indexWidth].Add(type.NONE);
                }
            }
        }
        else
        {
            Debug.Log("Error map Width or Height = 0");
        }
    }

    void ResetMap()
    {
        for (int i = offsetLimitMapX; i < map.Count - offsetLimitMapX; ++i)
        {
            for (int j = offsetLimitMapZ; j < map[i].Count - offsetLimitMapZ; ++j)
            {
                ResetCase(i, j);
            }
        }
    }

    void CheckMouseEvent()
    {
        mousePosition = Input.mousePosition;

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition), out hitInfo))
            {
                mousePositionInWorld = new Vector3(hitInfo.point.x, 0.0f, hitInfo.point.z);
                ConvertMouseWorldPositionToTilePosition();
                if (Input.GetMouseButtonDown(0))
                {
                    if (!mouseDown)
                    {
                        if (CheckMouseIsInMapLimit(mousePositionInWorld))
                        {
                            mousePosFirstClick = mousePositionInWorld;
                            if (actualRoom.rect.width != 0 || actualRoom.rect.height != 0)
                            {
                                ResetRoom();
                                needUpdate = true;
                            }
                            mouseDown = true;
                        }
                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    if (mouseDown)
                    {
                        mouseDown = false;
                    }
                }
            }
        }

    }

    void ConvertMouseWorldPositionToTilePosition()
    {
        Vector3 mouseWorldPositionTmp = mousePositionInWorld;
        Vector2 mousePositionCheck = new Vector2(mouseWorldPositionTmp.x % 1, mouseWorldPositionTmp.z % 1);
        int valueX = (int)(mouseWorldPositionTmp.x / 1);
        int valueZ = (int)(mouseWorldPositionTmp.z / 1);

        if (mousePositionCheck.x <= 0.5)
        {
            valueX -= 0;
        }
        else if (mousePositionCheck.x > 0.5)
        {
            valueX += 1;
        }
        if (mousePositionCheck.y <= 0.5)
        {
            valueZ -= 0;
        }
        else if (mousePositionCheck.y > 0.5)
        {
            valueZ += 1;
        }
        mousePositionInWorld = new Vector3(valueX, 0.0f, valueZ);
    }

    void AddObjectToLevel(GameObject objectToInstanciate, Material material, Shader shader, int indexX, int indexZ, type objectType, Vector3 rotationAxis = default(Vector3), float angle = 0)
    {
        if (CheckPoolSize(objectType) > 0)
        {
            Vector2 indexInWorld = GetIndexInWorld(indexX, indexZ);

            map[indexX][indexZ] = PoolObjectRequest(objectType);

            Renderer render = map[indexX][indexZ].GetComponent<Renderer>();

            map[indexX][indexZ].transform.position = new Vector3(indexInWorld.x, floorHeight, indexInWorld.y);
            map[indexX][indexZ].transform.SetParent(mapParent.transform);
            if (render != null)
            {
                render.material = material;
                render.material.shader = shader;
            }
        }
        else
        {
            map[indexX][indexZ] = InstanciateObject(objectToInstanciate, material, shader, indexX, indexZ);
        }
        if (objectType == type.WALLGROUND || objectType == type.WALLBRIDGE || objectType == type.EXTERNALCORNER || objectType == type.INTERNALCORNER)
        {
            map[indexX][indexZ].GetComponent<SelectRandomPrefab>().SelectMesh();
            map[indexX][indexZ].transform.rotation = Quaternion.identity;
            map[indexX][indexZ].transform.Rotate(rotationAxis, angle);

        }
        else if (objectType == type.GROUND)
        {
            map[indexX][indexZ].layer = LayerMask.NameToLayer("Walkable");
        }
        SetParentOfInstanciateObject(objectType, map[indexX][indexZ]);
    }

    GameObject InstanciateObject(GameObject objectToInstanciate, Material material, Shader shader, int indexX, int indexZ)
    {
        GameObject newInstance;
        Vector2 indexInWorld = GetIndexInWorld(indexX, indexZ);

        newInstance = GameObject.Instantiate(objectToInstanciate, new Vector3(indexInWorld.x, floorHeight, indexInWorld.y), Quaternion.identity) as GameObject;
        //Actually door is my creation and don't have a renderer so don't do this stuff
        if (newInstance.GetComponent<Renderer>() != null)
        {
            newInstance.GetComponent<Renderer>().material = material;
            newInstance.GetComponent<Renderer>().material.shader = shader;
            newInstance.transform.SetParent(mapParent.transform);
        }
        return newInstance;
    }

    void SetParentOfInstanciateObject(type objectType, GameObject newObject)
    {
        if (objectType == type.GROUND)
        {
            newObject.transform.SetParent(actualRoom.ground.transform);
        }
        if (objectType == type.WALLGROUND ||
            objectType == type.EXTERNALCORNER)
        {
            newObject.transform.SetParent(actualRoom.wall.transform);
        }
        if (objectType == type.BRIDGE)
        {
            newObject.transform.SetParent(actualRoom.bridgeParent.transform);
        }
    }

    bool ResetCase(int i, int j, bool isConsideringWall = true, bool isConsideringBridge = true)
    {
        if (map[i][j] != null)
        {
            if (CheckDontDestroyOtherRect(i, j, isConsideringWall, isConsideringBridge))
            {
                PoolObjectAddBuffer(mapObjectType[i][j], map[i][j]);
                mapObjectType[i][j] = type.NONE;
                map[i][j] = null;
                return true;
            }
        }
        else
        {
            mapObjectType[i][j] = type.NONE;
        }
        return false;
    }

    void ResetRoom()
    {
        Vector2 index2D = GetIndex2D((int)actualRoom.rect.x, (int)actualRoom.rect.y);

        foreach (Room room in rooms)
        {
            int indexLink = -1;
            int indexRoom = -1;

            indexLink = room.linksType.IndexOf(linkType.BOT);

            if (indexLink != -1)
            {
                indexRoom = room.links.roomsBot.IndexOf(actualRoom);
                if (indexRoom != -1)
                {
                    room.links.roomsBot.RemoveAt(indexRoom);
                    room.linksType.RemoveAt(indexLink);
                    room.rectBridgeBot.RemoveAt(indexRoom);

                    indexLink = actualRoom.linksType.IndexOf(linkType.TOP);
                    indexRoom = actualRoom.links.roomsTop.IndexOf(room);

                    actualRoom.linksType.RemoveAt(indexLink);
                    actualRoom.links.roomsTop.RemoveAt(indexRoom);
                    actualRoom.rectBridgeTop.RemoveAt(indexRoom);
                }
            }
            indexLink = -1;
            indexRoom = -1;
            indexLink = room.linksType.IndexOf(linkType.TOP);

            if (indexLink != -1)
            {
                indexRoom = room.links.roomsTop.IndexOf(actualRoom);
                if (indexRoom != -1)
                {
                    room.links.roomsTop.RemoveAt(indexRoom);
                    room.linksType.RemoveAt(indexLink);
                    room.rectBridgeTop.RemoveAt(indexRoom);

                    indexLink = actualRoom.linksType.IndexOf(linkType.BOT);
                    indexRoom = actualRoom.links.roomsBot.IndexOf(room);

                    actualRoom.linksType.RemoveAt(indexLink);
                    actualRoom.links.roomsBot.RemoveAt(indexRoom);
                    actualRoom.rectBridgeBot.RemoveAt(indexRoom);
                }
            }
            indexLink = -1;
            indexRoom = -1;
            indexLink = room.linksType.IndexOf(linkType.RIGHT);

            if (indexLink != -1)
            {
                indexRoom = room.links.roomsRight.IndexOf(actualRoom);
                if (indexRoom != -1)
                {
                    room.links.roomsRight.RemoveAt(indexRoom);
                    room.linksType.RemoveAt(indexLink);
                    room.rectBridgeRight.RemoveAt(indexRoom);

                    indexLink = actualRoom.linksType.IndexOf(linkType.LEFT);
                    indexRoom = actualRoom.links.roomsLeft.IndexOf(room);

                    actualRoom.linksType.RemoveAt(indexLink);
                    actualRoom.links.roomsLeft.RemoveAt(indexRoom);
                    actualRoom.rectBridgeLeft.RemoveAt(indexRoom);
                }
            }
            indexLink = -1;
            indexRoom = -1;
            indexLink = room.linksType.IndexOf(linkType.LEFT);

            if (indexLink != -1)
            {
                indexRoom = room.links.roomsLeft.IndexOf(actualRoom);
                if (indexRoom != -1)
                {
                    room.links.roomsLeft.RemoveAt(indexRoom);
                    room.linksType.RemoveAt(indexLink);
                    room.rectBridgeLeft.RemoveAt(indexRoom);

                    indexLink = actualRoom.linksType.IndexOf(linkType.RIGHT);
                    indexRoom = actualRoom.links.roomsRight.IndexOf(room);

                    actualRoom.linksType.RemoveAt(indexLink);
                    actualRoom.links.roomsRight.RemoveAt(indexRoom);
                    actualRoom.rectBridgeRight.RemoveAt(indexRoom);
                }
            }
        }

        RemoveAllBridgeFromRoom();
        ResetRoomWithoutDestroy(index2D);

        actualRoom.rect = new MyRect();
        actualRoom.rect.x = -mapWidth - 1;
        actualRoom.rect.y = -mapHeight - 1;
        modifInfoRoom.lastFrameRect = new MyRect();
        modifInfoRoom.lastRect = new MyRect();
    }

    void ResetRoomWithoutDestroy(Vector2 index2D)
    {
        //Reset bridge inside room
        //the brut value -+ 1 is for deleting wall and corner
        for (int i = (int)index2D.x - 1; i <= (int)(index2D.x + actualRoom.rect.width + 1); ++i)
        {
            for (int j = (int)index2D.y - 1; j <= (int)(index2D.y + actualRoom.rect.height + 1); ++j)
            {
                ResetCase(i, j, false, false);
            }
        }

        //Reset wall and corner in room
        foreach (Room room in rooms)
        {
            int phase = 3;

            for (int p = 0; p < phase; ++p)
            {
                index2D = GetIndex2D((int)room.rect.x, (int)room.rect.y);
                //the brut value -+ 1 is for deleting wall and corner
                for (int i = (int)index2D.x - 1; i <= (int)(index2D.x + room.rect.width + 1); ++i)
                {
                    if (p == 0)
                    {
                        for (int j = (int)index2D.y - 1; j <= (int)(index2D.y + room.rect.height + 1); ++j)
                        {
                            ResetCase(i, j, false, false);
                        }
                    }
                    else if (p == 1)
                    {
                        for (int j = (int)index2D.y - 1; j <= (int)(index2D.y + room.rect.height + 1); ++j)
                        {
                            AddWall(i, j, false, mainPhase.CREATE_WALL);
                            DisplayWall(i, j);
                        }
                    }
                    else if (p == 2)
                    {
                        for (int j = (int)index2D.y - 1; j <= (int)(index2D.y + room.rect.height + 1); ++j)
                        {
                            AddExternalCorner(i, j);
                            DisplayExternalCorner(i, j);
                        }
                    }
                }
            }
        }
    }

    Vector2 GetIndexInWorld(int indexX, int indexZ)
    {
        Vector2 indexInWorld = new Vector2(indexX, indexZ);

        indexInWorld.x -= (int)(mapWidth * 0.5);
        indexInWorld.y -= (int)(mapHeight * 0.5);

        return indexInWorld;
    }

    Vector2 GetIndex2D(int indexX, int indexZ)
    {
        Vector2 index2D = new Vector2(indexX, indexZ);

        index2D.x += (int)(mapWidth * 0.5);
        index2D.y += (int)(mapHeight * 0.5);

        return index2D;
    }

    bool ValidingCreation()
    {
        if (actualRoom.rect.width >= widthMin && actualRoom.rect.height >= heightMin)
        {
            return true;
        }
        return false;
    }

    void AddGround(int i, int j)
    {
        if (isPhaseRoom)
        {
            AddGroundByType(i, j, type.GROUND);
        }
    }

    void DisplayGround(int i, int j)
    {
        if (mapObjectType[i][j] == type.GROUND && map[i][j] == null)
        {
            AddObjectToLevel(ground, wireframeMaterial, wireframeShader, i, j, type.GROUND);
        }
    }

    void AddBridge()
    {
        List<LinkInfo> linksInfo = new List<LinkInfo>();

        foreach (Room room in rooms)
        {
            //Check if room is already link to the actual room if not we can try to link it, only one link can be, and perform update only on the links
            linksInfo = isRoomAlreadyLink(room);
            if (linksInfo != null)
            {
                foreach (LinkInfo linkInfo in linksInfo)
                {
                    if (actualRoom.isHeightChange || needUpdate)
                    {
                        if (linkInfo.type == linkType.BOT)
                        {
                            UpdateBridgeBot(linkInfo.room, linkInfo.indexLink);
                        }
                        else if (linkInfo.type == linkType.TOP)
                        {
                            UpdateBridgeTop(linkInfo.room, linkInfo.indexLink);
                        }
                    }
                    if (actualRoom.isWidthChange || needUpdate)
                    {
                        if (linkInfo.type == linkType.RIGHT)
                        {
                            UpdateBridgeRight(linkInfo.room, linkInfo.indexLink);
                        }
                        else if (linkInfo.type == linkType.LEFT)
                        {
                            UpdateBridgeLeft(linkInfo.room, linkInfo.indexLink);
                        }
                    }
                }
            }
            if (linksInfo == null)
            {
                int nbSideOfRoom = 4;

                for (int nbs = 0; nbs < nbSideOfRoom; ++nbs)
                {
                    if (nbs == 0)
                    {
                        AddBridgeBot(room);
                    }
                    else if (nbs == 1)
                    {
                        AddBridgeRight(room);
                    }
                    else if (nbs == 2)
                    {
                        AddBridgeLeft(room);
                    }
                    else
                    {
                        AddBridgeTop(room);
                    }
                }
            }
        }
    }

    void RemoveAllBridgeFromRoom()
    {
        foreach (MyRect rect in actualRoom.rectBridgeBot)
        {
            RemoveBridge(rect, true);
        }

        foreach (MyRect rect in actualRoom.rectBridgeTop)
        {
            RemoveBridge(rect, true);
        }

        foreach (MyRect rect in actualRoom.rectBridgeRight)
        {
            RemoveBridge(rect, false);
        }

        foreach (MyRect rect in actualRoom.rectBridgeLeft)
        {
            RemoveBridge(rect, false);
        }
    }

    void RemoveBridge(MyRect rect, bool isVertical)
    {
        if (isVertical)
        {
            for (int j = rect.y - 1; j < (rect.y + rect.height + 1); ++j)
            {
                for (int i = rect.x - 1; i < (rect.x + widthSampleBridge + 1); ++i)
                {
                    Vector2 index2D = GetIndex2D(i, j);

                    if (map[(int)index2D.x][(int)index2D.y] != null)
                    {
                        ResetCase((int)index2D.x, (int)index2D.y, false, false);
                    }
                }
            }
        }
        else if (!isVertical)
        {
            for (int i = rect.x - 1; i < (rect.x + rect.width + 1); ++i)
            {
                for (int j = rect.y - 1; j < (rect.y + heightSampleBridge + 1); ++j)
                {
                    Vector2 index2D = GetIndex2D(i, j);

                    if (map[(int)index2D.x][(int)index2D.y] != null)
                    {
                        ResetCase((int)index2D.x, (int)index2D.y, false, false);
                    }
                }
            }
        }
    }

    bool CheckCanCreateBridgeBetweenRoom(Vector2 startPos, float addX, float addY)
    {
        Vector2 actualPos = startPos;

        //First inc needed to never check the startPos
        actualPos.x += addX;
        actualPos.y += addY;

        while (actualPos.x < (mapWidth * 0.5f) &&
                actualPos.x > -(mapWidth * 0.5f) &&
                actualPos.y < (mapHeight * 0.5f) &&
                actualPos.y > -(mapHeight * 0.5f))
        {
            Vector2 index2D = GetIndex2D((int)actualPos.x, (int)actualPos.y);
            //Check for other room
            if (CheckIndexIsInRoomRect((int)actualPos.x, (int)actualPos.y))
            {
                return false;
            }
            //Check for actualRoom
            if (CheckIndexIsInRectBounces((int)index2D.x, (int)index2D.y))
            {
                return true;
            }
            actualPos.x += addX;
            actualPos.y += addY;
        }
        return false;
    }

    List<LinkInfo> isRoomAlreadyLink(Room room)
    {
        List<LinkInfo> linksInfo = new List<LinkInfo>();
        LinkInfo newLinkInfo = new LinkInfo();
        int indexLink = -1;

        foreach (Room roombot in room.links.roomsBot)
        {
            indexLink++;
            if (actualRoom.rect == roombot.rect)
            {
                newLinkInfo.room = room;
                newLinkInfo.type = linkType.BOT;
                newLinkInfo.indexLink = indexLink;
                linksInfo.Add(newLinkInfo);
                newLinkInfo = new LinkInfo();
            }
        }
        indexLink = -1;
        foreach (Room roomtop in room.links.roomsTop)
        {
            indexLink++;
            if (actualRoom.rect == roomtop.rect)
            {
                newLinkInfo.room = room;
                newLinkInfo.type = linkType.TOP;
                newLinkInfo.indexLink = indexLink;
                linksInfo.Add(newLinkInfo);
                newLinkInfo = new LinkInfo();
            }
        }
        indexLink = -1;
        foreach (Room roomleft in room.links.roomsLeft)
        {
            indexLink++;
            if (actualRoom.rect == roomleft.rect)
            {
                newLinkInfo.room = room;
                newLinkInfo.type = linkType.LEFT;
                newLinkInfo.indexLink = indexLink;
                linksInfo.Add(newLinkInfo);
                newLinkInfo = new LinkInfo();
            }
        }
        indexLink = -1;
        foreach (Room roomright in room.links.roomsRight)
        {
            indexLink++;
            if (actualRoom.rect == roomright.rect)
            {
                newLinkInfo.room = room;
                newLinkInfo.type = linkType.RIGHT;
                newLinkInfo.indexLink = indexLink;
                linksInfo.Add(newLinkInfo);
                newLinkInfo = new LinkInfo();
            }
        }
        if (linksInfo.Count != 0)
        {
            return linksInfo;
        }
        return null;
    }

    void AddBridgeBot(Room room)
    {
        MyRect newBridgeRect = new MyRect();

        int middleWidth = (int)(room.rect.x + room.rect.width * 0.5f);
        int middleHeight = room.rect.y;

        if (CheckCanCreateBridgeBetweenRoom(new Vector2(middleWidth, middleHeight), 0, -1))
        {
            if (middleHeight > (actualRoom.rect.y + actualRoom.rect.height))
            {
                if (middleWidth > actualRoom.rect.x &&
                    middleWidth < actualRoom.rect.x + actualRoom.rect.width)
                {
                    int bridgeWidth = widthSampleBridge - 1;
                    int bridgeHeight = middleHeight - (actualRoom.rect.y + actualRoom.rect.height - 1);

                    newBridgeRect.width = bridgeWidth;
                    newBridgeRect.height = bridgeHeight;
                    newBridgeRect.x = middleWidth;
                    newBridgeRect.y = middleHeight - newBridgeRect.height;
                   // newBridgeRect.DisplayRectInfo();

                    for (int j = newBridgeRect.y; j < (newBridgeRect.y + newBridgeRect.height + 1); ++j)
                    {
                        for (int i = newBridgeRect.x - 1; i < (newBridgeRect.x + widthSampleBridge + 1); ++i)
                        {
                            Vector2 index2D = GetIndex2D(i, j);

                            if (map[(int)index2D.x][(int)index2D.y] != null &&
                                mapObjectType[(int)index2D.x][(int)index2D.y] != type.BRIDGE)
                            {
                                ResetCase((int)index2D.x, (int)index2D.y, false);
                            }
                            if (i > newBridgeRect.x - 1 && i < (newBridgeRect.x + widthSampleBridge))
                            {
                                AddGroundByType((int)index2D.x, (int)index2D.y, type.BRIDGE);
                            }
                        }
                    }

                    //Set rooms affilied
                    room.linksType.Add(linkType.BOT);
                    room.links.roomsBot.Add(actualRoom);
                    room.rectBridgeBot.Add(newBridgeRect);

                    actualRoom.linksType.Add(linkType.TOP);
                    actualRoom.links.roomsTop.Add(room);
                    actualRoom.rectBridgeTop.Add(newBridgeRect);
                    newBridgeRect = null;
                }
            }
        }
    }

    void UpdateBridgeBot(Room room, int index)
    {
        MyRect rect = room.rectBridgeBot[index];
        int middleWidth = (int)(room.rect.x + room.rect.width * 0.5f);
        int middleHeight = room.rect.y;

        if (middleHeight > (actualRoom.rect.y + actualRoom.rect.height))
        {
            if (middleWidth > actualRoom.rect.x &&
                middleWidth < actualRoom.rect.x + actualRoom.rect.width)
            {
                int lastHeight = rect.height;
                rect.height = Mathf.Abs((room.rect.y - 1) - (actualRoom.rect.y + actualRoom.rect.height));

                rect.y += lastHeight;
                rect.y -= rect.height;
                for (int j = rect.y; j < (rect.y + rect.height + 1); ++j)
                {
                    for (int i = rect.x - 1; i < (rect.x + widthSampleBridge + 1); ++i)
                    {
                        Vector2 index2D = GetIndex2D(i, j);

                        if (map[(int)index2D.x][(int)index2D.y] != null &&
                            mapObjectType[(int)index2D.x][(int)index2D.y] != type.BRIDGE)
                        {
                            ResetCase((int)index2D.x, (int)index2D.y, false, false);
                        }
                        if (i > rect.x - 1 && i < (rect.x + widthSampleBridge))
                        {
                            AddGroundByType((int)index2D.x, (int)index2D.y, type.BRIDGE);
                        }
                    }
                }
            }
            else
            {
                RemoveBridgeBot(room, rect);
            }
        }
    }

    void RemoveBridgeBot(Room room, MyRect bridgeRect)
    {
        MyRect rect = bridgeRect;
        Vector2 index2D;

        actualRoom.links.roomsTop.Remove(room);
        actualRoom.rectBridgeTop.Remove(rect);

        room.rectBridgeBot.Remove(rect);
        room.links.roomsBot.Remove(actualRoom);


        for (int j = rect.y - 1; j < (rect.y + rect.height + 1); ++j)
        {
            for (int i = rect.x - 1; i < (rect.x + widthSampleBridge + 1); ++i)
            {
                index2D = GetIndex2D(i, j);

                ResetCase((int)index2D.x, (int)index2D.y, false);
            }
        }

        index2D = GetIndex2D(room.rect.x, room.rect.y);

        ResetRoomWithoutDestroy(index2D);
        RemoveBridge(rect, true);
    }

    void AddBridgeRight(Room room)
    {
        MyRect newBridgeRect = new MyRect();
        int middleWidth = room.rect.x + room.rect.width;
        int middleHeight = (int)(room.rect.y + room.rect.height * 0.5f);

        if (CheckCanCreateBridgeBetweenRoom(new Vector2(middleWidth, middleHeight), 1, 0))
        {
            if (middleWidth < (actualRoom.rect.x + actualRoom.rect.width))
            {
                if (middleHeight > actualRoom.rect.y &&
                    middleHeight < actualRoom.rect.y + actualRoom.rect.height)
                {
                    int bridgeWidth = actualRoom.rect.x - middleWidth - 1;
                    int bridgeHeight = middleHeight;

                    newBridgeRect.width = bridgeWidth;
                    newBridgeRect.height = heightSampleBridge - 1;
                    newBridgeRect.x = middleWidth;
                    newBridgeRect.y = middleHeight;

                    for (int i = newBridgeRect.x; i < (newBridgeRect.x + newBridgeRect.width - 1); ++i)
                    {
                        for (int j = newBridgeRect.y - 1; j < (newBridgeRect.y + heightSampleBridge + 1); ++j)
                        {
                            Vector2 index2D = GetIndex2D(i, j);

                            if (map[(int)index2D.x][(int)index2D.y] != null &&
                                mapObjectType[(int)index2D.x][(int)index2D.y] != type.BRIDGE)
                            {
                                ResetCase((int)index2D.x, (int)index2D.y, false);
                            }
                            if (j >= newBridgeRect.y  && j < (newBridgeRect.y + heightSampleBridge))
                            {
                                AddGroundByType((int)index2D.x, (int)index2D.y, type.BRIDGE);
                            }
                        }
                    }

                    room.linksType.Add(linkType.RIGHT);
                    room.links.roomsRight.Add(actualRoom);
                    room.rectBridgeRight.Add(newBridgeRect);

                    actualRoom.linksType.Add(linkType.LEFT);
                    actualRoom.links.roomsLeft.Add(room);
                    actualRoom.rectBridgeLeft.Add(newBridgeRect);
                    newBridgeRect = null;
                }
            }
        }
    }

    void UpdateBridgeRight(Room room, int index)
    {
        MyRect rect = room.rectBridgeRight[index];
        rect.width = Mathf.Abs((room.rect.x + room.rect.width - 1) - (actualRoom.rect.x));

        int middleWidth = room.rect.x + room.rect.width;
        int middleHeight = (int)(room.rect.y + room.rect.height * 0.5f);

        if (middleWidth < (actualRoom.rect.x + actualRoom.rect.width))
        {
            if (middleHeight > actualRoom.rect.y &&
                middleHeight < actualRoom.rect.y + actualRoom.rect.height)
            {
                for (int i = rect.x; i < (rect.x + rect.width - 1); ++i)
                {
                    for (int j = rect.y - 1; j < (rect.y + heightSampleBridge + 1); ++j)
                    {
                        Vector2 index2D = GetIndex2D(i, j);

                        if (map[(int)index2D.x][(int)index2D.y] != null &&
                            mapObjectType[(int)index2D.x][(int)index2D.y] != type.BRIDGE)
                        {
                            ResetCase((int)index2D.x, (int)index2D.y, false, false);
                        }
                        if (j >= rect.y && j < (rect.y + heightSampleBridge))
                        {
                            AddGroundByType((int)index2D.x, (int)index2D.y, type.BRIDGE);
                        }
                    }
                }
            }
            else
            {
                RemoveBridgeRight(room, rect);
            }
        }
    }

    void RemoveBridgeRight(Room room, MyRect bridgeRect)
    {
        MyRect rect = bridgeRect;
        Vector2 index2D;

        actualRoom.links.roomsLeft.Remove(room);
        actualRoom.rectBridgeLeft.Remove(rect);

        room.rectBridgeRight.Remove(rect);
        room.links.roomsRight.Remove(actualRoom);


        for (int i = rect.x; i < (rect.x + rect.width - 1); ++i)
        {
            for (int j = rect.y - 1; j < (rect.y + heightSampleBridge + 1); ++j)
            {
                index2D = GetIndex2D(i, j);
                
                ResetCase((int)index2D.x, (int)index2D.y, false);
            }
        }
        index2D = GetIndex2D(room.rect.x, room.rect.y);

        ResetRoomWithoutDestroy(index2D);
        RemoveBridge(rect, false);
    }

    void AddBridgeLeft(Room room)
    {
        MyRect newBridgeRect = new MyRect();
        int middleWidth = room.rect.x;
        int middleHeight = (int)(room.rect.y + room.rect.height * 0.5f);

        if (CheckCanCreateBridgeBetweenRoom(new Vector2(middleWidth, middleHeight), -1, 0))
        {
            if (middleWidth > (actualRoom.rect.x + actualRoom.rect.width))
            {
                if (middleHeight > actualRoom.rect.y &&
                    middleHeight < actualRoom.rect.y + actualRoom.rect.height)
                {
                    int bridgeWidth = middleWidth - (actualRoom.rect.x + actualRoom.rect.width);
                    int bridgeHeight = heightSampleBridge - 1;

                    newBridgeRect.width = bridgeWidth;
                    newBridgeRect.height = bridgeHeight;
                    newBridgeRect.x = middleWidth - newBridgeRect.width;
                    newBridgeRect.y = middleHeight;

                    for (int i = newBridgeRect.x; i < (newBridgeRect.x + newBridgeRect.width + 1); ++i)
                    {
                        for (int j = newBridgeRect.y - 1; j < (newBridgeRect.y + heightSampleBridge + 1); ++j)
                        {
                            Vector2 index2D = GetIndex2D(i, j);
                            if (map[(int)index2D.x][(int)index2D.y] != null &&
                                mapObjectType[(int)index2D.x][(int)index2D.y] != type.BRIDGE)
                            {
                                ResetCase((int)index2D.x, (int)index2D.y, false);
                            }
                            if (j > newBridgeRect.y - 1 && j < (newBridgeRect.y + heightSampleBridge))
                            {
                                AddGroundByType((int)index2D.x, (int)index2D.y, type.BRIDGE);
                            }
                        }
                    }

                    room.linksType.Add(linkType.LEFT);
                    room.links.roomsLeft.Add(actualRoom);
                    room.rectBridgeLeft.Add(newBridgeRect);
                    actualRoom.linksType.Add(linkType.RIGHT);
                    actualRoom.links.roomsRight.Add(room);
                    actualRoom.rectBridgeRight.Add(newBridgeRect);
                    newBridgeRect = null;
                }
            }
        }
    }

    void UpdateBridgeLeft(Room room, int index)
    {
        MyRect rect = room.rectBridgeLeft[index];
        int lastWidth = rect.width;
        rect.width = Mathf.Abs(room.rect.x - (actualRoom.rect.x + actualRoom.rect.width));
        rect.x += lastWidth;
        rect.x -= rect.width;

        for (int i = rect.x; i < (rect.x + rect.width + 1); ++i)
        {
            for (int j = rect.y - 1; j < (rect.y + heightSampleBridge + 1); ++j)
            {
                Vector2 index2D = GetIndex2D(i, j);
                if (map[(int)index2D.x][(int)index2D.y] != null &&
                    mapObjectType[(int)index2D.x][(int)index2D.y] != type.BRIDGE)
                {
                    ResetCase((int)index2D.x, (int)index2D.y, false);
                }
                if (j > rect.y - 1 && j < (rect.y + heightSampleBridge))
                {
                    AddGroundByType((int)index2D.x, (int)index2D.y, type.BRIDGE);
                }
            }
        }
    }

    void AddBridgeTop(Room room)
    {
        MyRect newBridgeRect = new MyRect();
        int middleWidth = (int)(room.rect.x + room.rect.width * 0.5f);
        int middleHeight = room.rect.y + room.rect.height;

        if (CheckCanCreateBridgeBetweenRoom(new Vector2(middleWidth, middleHeight), 0, 1))
        {
            if (middleHeight < (actualRoom.rect.y + actualRoom.rect.height))
            {
                if (middleWidth > actualRoom.rect.x &&
                    middleWidth < actualRoom.rect.x + actualRoom.rect.width)
                {
                    int bridgeWidth = widthSampleBridge - 1;
                    int bridgeHeight = actualRoom.rect.y - middleHeight;

                    newBridgeRect.width = bridgeWidth;
                    newBridgeRect.height = bridgeHeight;
                    newBridgeRect.x = middleWidth;
                    newBridgeRect.y = middleHeight - 1;
                    newBridgeRect.DisplayRectInfo();

                    for (int j = newBridgeRect.y; j < (newBridgeRect.y + newBridgeRect.height + 1); ++j)
                    {
                        for (int i = newBridgeRect.x - 1; i < (newBridgeRect.x + newBridgeRect.width + 1); ++i)
                        {
                            Vector2 index2D = GetIndex2D(i, j);
                            if (map[(int)index2D.x][(int)index2D.y] != null &&
                                mapObjectType[(int)index2D.x][(int)index2D.y] != type.BRIDGE)
                            {
                                ResetCase((int)index2D.x, (int)index2D.y, false);
                            }
                            if (i > newBridgeRect.x - 1 && i < (newBridgeRect.x + newBridgeRect.width + 1))
                            {
                                AddGroundByType((int)index2D.x, (int)index2D.y, type.BRIDGE);
                            }
                        }
                    }

                    room.linksType.Add(linkType.TOP);
                    room.links.roomsTop.Add(actualRoom);
                    room.rectBridgeTop.Add(newBridgeRect);
                    actualRoom.linksType.Add(linkType.BOT);
                    actualRoom.links.roomsBot.Add(room);
                    actualRoom.rectBridgeBot.Add(newBridgeRect);
                    newBridgeRect = null;
                }
            }
        }
    }

    void UpdateBridgeTop(Room room, int index)
    {
        MyRect rect = room.rectBridgeTop[index];
        rect.height = Mathf.Abs((room.rect.y + room.rect.height) - actualRoom.rect.y);

        for (int j = rect.y; j < (rect.y + rect.height + 2); ++j)
        {
            for (int i = rect.x - 1; i < (rect.x + rect.width + 2); ++i)
            {
                Vector2 index2D = GetIndex2D(i, j);
                if (map[(int)index2D.x][(int)index2D.y] != null &&
                    mapObjectType[(int)index2D.x][(int)index2D.y] != type.BRIDGE)
                {
                    ResetCase((int)index2D.x, (int)index2D.y, false);
                }
                if (i > rect.x - 1 && i < (rect.x + rect.width + 1))
                {
                    AddGroundByType((int)index2D.x, (int)index2D.y, type.BRIDGE);
                }
            }
        }
    }

    void DisplayBridge(int i, int j)
    {
        if (mapObjectType[i][j] == type.BRIDGE && map[i][j] == null)
        {
            AddObjectToLevel(bridge, wireframeMaterial, wireframeShader, i, j, type.BRIDGE);
        }
    }

    void AddGroundByType(int i, int j, type objectType)
    {
        if (mapObjectType[i][j] == type.NONE)
        {
            mapObjectType[i][j] = objectType;
        }
        else if (mapObjectType[i][j] != type.NONE && mapObjectType[i][j] != objectType)
        {
            if (ResetCase(i, j, true, false))
            {
                mapObjectType[i][j] = objectType;
            }
        }
    }
    
    void AddWall(int i, int j, bool isConsideringPhase = true, mainPhase phase = mainPhase.CREATE_WALL)
    {
        if (mapObjectType[i][j] == type.NONE)
        {
            if (phase == mainPhase.CREATE_WALL)
            {
                AddWallForGroundType(i, j, isConsideringPhase);
            }
            if (phase == mainPhase.CREATE_WALLBRIDGE)
            {
                AddWallForBridgeType(i, j);
            }
        }
    }

    void AddWallForGroundType(int i, int j, bool isConsideringPhase = true)
    {
        if (isPhaseRoom || !isConsideringPhase)
        {
            if ((mapObjectType[i + 1][j] == type.GROUND && mapObjectType[i - 1][j] != type.WALLGROUND) &&
                (mapObjectType[i + 1][j] == type.GROUND && mapObjectType[i - 1][j] != type.EXTERNALCORNER))
            {
                mapObjectType[i][j] = type.WALLGROUND;
            }
            else if ((mapObjectType[i - 1][j] == type.GROUND && mapObjectType[i + 1][j] != type.WALLGROUND) &&
                     (mapObjectType[i - 1][j] == type.GROUND && mapObjectType[i + 1][j] != type.EXTERNALCORNER))
            {
                mapObjectType[i][j] = type.WALLGROUND;
            }
            else if ((mapObjectType[i][j + 1] == type.GROUND && mapObjectType[i][j - 1] != type.WALLGROUND) &&
                     (mapObjectType[i][j + 1] == type.GROUND && mapObjectType[i][j - 1] != type.EXTERNALCORNER))
            {
                mapObjectType[i][j] = type.WALLGROUND;
            }
            else if ((mapObjectType[i][j - 1] == type.GROUND && mapObjectType[i][j + 1] != type.WALLGROUND) &&
                     (mapObjectType[i][j - 1] == type.GROUND && mapObjectType[i][j + 1] != type.EXTERNALCORNER))
            {
                mapObjectType[i][j] = type.WALLGROUND;
            }
        }
    }

    void AddWallForBridgeType(int i, int j)
    {
    //Haut
        if ((mapObjectType[i][j + 1] == type.BRIDGE && mapObjectType[i][j - 1] != type.WALLBRIDGE) &&
             (mapObjectType[i][j + 1] == type.BRIDGE && mapObjectType[i][j - 1] != type.EXTERNALCORNER))
        {
            mapObjectType[i][j] = type.WALLBRIDGE;
        }
        //Bas
        else if ((mapObjectType[i][j - 1] == type.BRIDGE && mapObjectType[i][j + 1] != type.WALLBRIDGE) &&
                 (mapObjectType[i][j - 1] == type.BRIDGE && mapObjectType[i][j + 1] != type.EXTERNALCORNER))
        {
            mapObjectType[i][j] = type.WALLBRIDGE;
        }

        //Gauche
        if ((mapObjectType[i + 1][j] == type.BRIDGE && mapObjectType[i - 1][j] != type.WALLBRIDGE) &&
            (mapObjectType[i + 1][j] == type.BRIDGE && mapObjectType[i - 1][j] != type.EXTERNALCORNER))
        {
            mapObjectType[i][j] = type.WALLBRIDGE;
        }
        //Droite
        else if ((mapObjectType[i - 1][j] == type.BRIDGE && mapObjectType[i + 1][j] != type.WALLBRIDGE) &&
                 (mapObjectType[i - 1][j] == type.BRIDGE && mapObjectType[i + 1][j] != type.EXTERNALCORNER))
        {
            mapObjectType[i][j] = type.WALLBRIDGE;
        }
    }

    void DisplayWall(int i, int j)
    {
        if ((mapObjectType[i][j] == type.WALLGROUND || mapObjectType[i][j] == type.WALLBRIDGE) &&
            map[i][j] == null)
        {
            type actualType = mapObjectType[i][j];
            //Left
            if (mapObjectType[i + 1][j] == type.GROUND || mapObjectType[i + 1][j] == type.BRIDGE)
            {
                if (mapObjectType[i + 1][j] == type.BRIDGE)
                    AddObjectToLevel(wall, wireframeMaterial, wireframeShader, i, j, actualType, Vector3.up, 0);
                else
                    AddObjectToLevel(wall, finishedMaterial, finishedShader, i, j, actualType, Vector3.up, 0);
            }
            //Right
            else if (mapObjectType[i - 1][j] == type.GROUND || mapObjectType[i - 1][j] == type.BRIDGE)
            {
                if (mapObjectType[i - 1][j] == type.BRIDGE)
                    AddObjectToLevel(wall, wireframeMaterial, wireframeShader, i, j, actualType, Vector3.up, 180);
                else
                    AddObjectToLevel(wall, finishedMaterial, finishedShader, i, j, actualType, Vector3.up, 180);
            }
            //Bot
            else if (mapObjectType[i][j + 1] == type.GROUND || mapObjectType[i][j + 1] == type.BRIDGE)
            {
                if (mapObjectType[i][j + 1] == type.BRIDGE)
                    AddObjectToLevel(wall, wireframeMaterial, wireframeShader, i, j, actualType, Vector3.up, -90);
                else
                    AddObjectToLevel(wall, finishedMaterial, finishedShader, i, j, actualType, Vector3.up, -90);
            }
            //Top
            else if (mapObjectType[i][j - 1] == type.GROUND || mapObjectType[i][j - 1] == type.BRIDGE)
            {
                if (mapObjectType[i][j - 1] == type.BRIDGE)
                    AddObjectToLevel(wall, wireframeMaterial, wireframeShader, i, j, actualType, Vector3.up, 90);
                else
                    AddObjectToLevel(wall, finishedMaterial, finishedShader, i, j, actualType, Vector3.up, 90);
            }
        }
    }

    void AddExternalCorner(int i, int j)
    {
        if (mapObjectType[i][j] == type.NONE ||
            mapObjectType[i][j] == type.WALLGROUND ||
            mapObjectType[i][j] == type.WALLBRIDGE)
        {
            if (mapObjectType[i + 1][j + 1] == type.GROUND &&
                mapObjectType[i + 1][j] == type.WALLGROUND &&
                mapObjectType[i][j + 1] == type.WALLGROUND)
            {
                mapObjectType[i][j] = type.EXTERNALCORNER;
            }
            if (mapObjectType[i + 1][j - 1] == type.GROUND &&
                mapObjectType[i + 1][j] == type.WALLGROUND &&
                mapObjectType[i][j - 1] == type.WALLGROUND)
            {
                mapObjectType[i][j] = type.EXTERNALCORNER;
            }
            if (mapObjectType[i - 1][j + 1] == type.GROUND &&
                mapObjectType[i - 1][j] == type.WALLGROUND &&
                mapObjectType[i][j + 1] == type.WALLGROUND)
            {
                mapObjectType[i][j] = type.EXTERNALCORNER;
            }
            if (mapObjectType[i - 1][j - 1] == type.GROUND &&
                mapObjectType[i - 1][j] == type.WALLGROUND &&
                mapObjectType[i][j - 1] == type.WALLGROUND)
            {
                mapObjectType[i][j] = type.EXTERNALCORNER;
            }
        }
    }

    void AddInternalCorner(int i, int j)
    {
        if (mapObjectType[i][j] == type.NONE ||
            mapObjectType[i][j] == type.WALLGROUND ||
            mapObjectType[i][j] == type.WALLBRIDGE)
        {
            //Left
            if (mapObjectType[i + 1][j] == type.GROUND &&
                mapObjectType[i - 1][j] == type.WALLBRIDGE &&
                mapObjectType[i][j - 1] == type.WALLGROUND)
            {
                mapObjectType[i][j] = type.INTERNALCORNER;
            }
            if (mapObjectType[i + 1][j] == type.GROUND &&
                mapObjectType[i - 1][j] == type.WALLBRIDGE &&
                mapObjectType[i][j + 1] == type.WALLGROUND)
            {
                mapObjectType[i][j] = type.INTERNALCORNER;
            }

            //Right Work
            if (mapObjectType[i - 1][j] == type.GROUND &&
                mapObjectType[i + 1][j] == type.WALLBRIDGE &&
                mapObjectType[i][j - 1] == type.WALLGROUND)
            {
                mapObjectType[i][j] = type.INTERNALCORNER;
            }
            if (mapObjectType[i - 1][j] == type.GROUND &&
                mapObjectType[i + 1][j] == type.WALLBRIDGE &&
                mapObjectType[i][j + 1] == type.WALLGROUND)
            {
                mapObjectType[i][j] = type.INTERNALCORNER;
            }

            //Top Work
            if (mapObjectType[i][j - 1] == type.GROUND &&
                mapObjectType[i][j + 1] == type.WALLBRIDGE &&
                mapObjectType[i + 1][j] == type.WALLGROUND)
            {
                mapObjectType[i][j] = type.INTERNALCORNER;
            }
            if (mapObjectType[i][j - 1] == type.GROUND &&
                mapObjectType[i][j + 1] == type.WALLBRIDGE &&
                mapObjectType[i - 1][j] == type.WALLGROUND)
            {
                mapObjectType[i][j] = type.INTERNALCORNER;
            }

            //Bot Work
            if (mapObjectType[i][j + 1] == type.GROUND &&
                mapObjectType[i][j - 1] == type.WALLBRIDGE &&
                mapObjectType[i + 1][j] == type.WALLGROUND)
            {
                mapObjectType[i][j] = type.INTERNALCORNER;
            }
            if (mapObjectType[i][j + 1] == type.GROUND &&
                mapObjectType[i][j - 1] == type.WALLBRIDGE &&
                mapObjectType[i - 1][j] == type.WALLGROUND)
            {
                mapObjectType[i][j] = type.INTERNALCORNER;
            }
        }
    }

    void DisplayExternalCorner(int i, int j)
    {
        if (mapObjectType[i][j] == type.EXTERNALCORNER && map[i][j] == null)
        {
            //Bot Left
            if (mapObjectType[i + 1][j + 1] == type.GROUND)
            {
                AddObjectToLevel(externalCornerWall, wireframeMaterial, wireframeShader, i, j, type.EXTERNALCORNER, Vector3.up, -90);
            }
            //Top Right
            else if (mapObjectType[i - 1][j - 1] == type.GROUND)
            {
                AddObjectToLevel(externalCornerWall, wireframeMaterial, wireframeShader, i, j, type.EXTERNALCORNER, Vector3.up, 90);
            }
            //Bot Right
            else if (mapObjectType[i - 1][j + 1] == type.GROUND)
            {
                AddObjectToLevel(externalCornerWall, wireframeMaterial, wireframeShader, i, j, type.EXTERNALCORNER, Vector3.up, 180);
            }
            //Top Left
            else if (mapObjectType[i + 1][j - 1] == type.GROUND)
            {
                AddObjectToLevel(externalCornerWall, wireframeMaterial, wireframeShader, i, j, type.EXTERNALCORNER, Vector3.up, 0);
            }
        }
    }

    void DisplayInternalCorner(int i, int j)
    {
        if (map[i][j] != null && mapObjectType[i][j] == type.INTERNALCORNER)
        {
            GameObject.Destroy(map[i][j]);
            map[i][j] = null;
        }
        if (mapObjectType[i][j] == type.INTERNALCORNER && map[i][j] == null)
        {
            //Bot
            if (mapObjectType[i - 1][j - 1] == type.NONE &&
                mapObjectType[i][j + 1] == type.GROUND)
            {
                AddObjectToLevel(internalCornerWall, wireframeMaterial, wireframeShader, i, j, type.INTERNALCORNER, Vector3.up, -90);
            }
            if (mapObjectType[i + 1][j - 1] == type.NONE &&
                mapObjectType[i][j + 1] == type.GROUND)
            {
                AddObjectToLevel(internalCornerWall, wireframeMaterial, wireframeShader, i, j, type.INTERNALCORNER, Vector3.up, 180);
            }
            //Top
            if (mapObjectType[i - 1][j + 1] == type.NONE &&
                mapObjectType[i][j - 1] == type.GROUND)
            {
                AddObjectToLevel(internalCornerWall, wireframeMaterial, wireframeShader, i, j, type.INTERNALCORNER, Vector3.up, 0);
            }
            if (mapObjectType[i + 1][j + 1] == type.NONE &&
                mapObjectType[i][j - 1] == type.GROUND)
            {
                AddObjectToLevel(internalCornerWall, wireframeMaterial, wireframeShader, i, j, type.INTERNALCORNER, Vector3.up, 90);
            }
            //Right
            if (mapObjectType[i + 1][j + 1] == type.NONE &&
                mapObjectType[i - 1][j] == type.GROUND)
            {
                AddObjectToLevel(internalCornerWall, wireframeMaterial, wireframeShader, i, j, type.INTERNALCORNER, Vector3.up, 90);
            }
            if (mapObjectType[i + 1][j - 1] == type.NONE &&
                mapObjectType[i - 1][j] == type.GROUND)
            {
                AddObjectToLevel(internalCornerWall, wireframeMaterial, wireframeShader, i, j, type.INTERNALCORNER, Vector3.up, 180);
            }
            //Left
            if (mapObjectType[i - 1][j + 1] == type.NONE &&
                mapObjectType[i + 1][j] == type.GROUND)
            {
                AddObjectToLevel(internalCornerWall, wireframeMaterial, wireframeShader, i, j, type.INTERNALCORNER, Vector3.up, 0);
            }
            if (mapObjectType[i - 1][j - 1] == type.NONE &&
                mapObjectType[i + 1][j] == type.GROUND)
            {
                AddObjectToLevel(internalCornerWall, wireframeMaterial, wireframeShader, i, j, type.INTERNALCORNER, Vector3.up, 180);
            }
        }
    }

    void AddDoor(int i, int j)
    {
        if (mapObjectType[i][j] == type.WALLGROUND)
        {
            mapObjectType[i][j] = type.DOOR;
        }
    }

    void DisplayDoor(int i, int j)
    {
        if (mapObjectType[i][j] == type.DOOR)
        {
            ResetCase(i, j);
            AddObjectToLevel(door, wireframeMaterial, wireframeShader, i, j, type.DOOR, Vector3.up, -90);
        }
    }

    void SaveRoom()
    {
        rooms.Add(actualRoom);
        nbRoom++;
        actualRoom = new Room(mapParent, nbRoom);
        modifInfoRoom.lastFrameRect = new MyRect();
    }

    void ComputeRect()
    {

        if (mousePositionInWorld.x > minPos.x && mousePositionInWorld.x < maxPos.x &&
            mousePositionInWorld.z > minPos.y && mousePositionInWorld.z < maxPos.y)
        {
            Vector3 size = mousePositionInWorld - mousePosFirstClick;
            Vector3 absSize = new Vector3(Mathf.Abs(size.x), 0.0f, Mathf.Abs(size.z));

            if (displayDir.x < 0 && size.x > 0 &&
                displayDir.x > 0 && size.x < 0)
            {
                size.x *= -1;
            }
            if (displayDir.y < 0 && size.z > 0)
            {
                size.z *= -1;
            }



            //For easy use make X/Y the down left position of the rect
            // x negatif, z negatif draw vers le bas gauche
            if (mousePosFirstClick.x > mousePosFirstClick.x + size.x && mousePosFirstClick.z > mousePosFirstClick.z + size.z)
            {
                actualRoom.rect.SetRect((int)mousePosFirstClick.x + (int)size.x, (int)mousePosFirstClick.z + (int)size.z, (int)absSize.x, (int)absSize.z, (int)size.x, (int)size.z);
            }
            // x negatif, z positif draw vers le haut gauche
            else if (mousePosFirstClick.x > mousePosFirstClick.x + size.x && mousePosFirstClick.z < mousePosFirstClick.z + size.z)
            {
                actualRoom.rect.SetRect((int)mousePosFirstClick.x + (int)size.x, (int)mousePosFirstClick.z, (int)absSize.x, (int)absSize.z, (int)size.x, (int)size.z);
            }
            // x positif, z negatif draw vers le bas droite
            else if (mousePosFirstClick.x < mousePosFirstClick.x + size.x && mousePosFirstClick.z > mousePosFirstClick.z + size.z)
            {
                actualRoom.rect.SetRect((int)mousePosFirstClick.x, (int)mousePosFirstClick.z + (int)size.z, (int)absSize.x, (int)absSize.z, (int)size.x, (int)size.z);
            }
            // x positif, z positif draw vers le haut droite
            else if (mousePosFirstClick.x < mousePosFirstClick.x + size.x && mousePosFirstClick.z < mousePosFirstClick.z + size.z)
            {
                actualRoom.rect.SetRect((int)mousePosFirstClick.x, (int)mousePosFirstClick.z, (int)absSize.x, (int)absSize.z, (int)size.x, (int)size.z);
            }

            //actualRoom.rect.DisplayRectInfo();
            //Debug.Log("Update Rect");
            if (modifInfoRoom.lastFrameRect.width == 0 && modifInfoRoom.lastFrameRect.height == 0)
            {
                modifInfoRoom.lastFrameRect.Copy(actualRoom.rect);
            }

            bool isIntersect = IsRoomIntersect(actualRoom);
            if (isIntersect)
            {
                actualRoom.rect.Copy(modifInfoRoom.lastFrameRect);
            }
        }
    }

    void CheckRoomRect()
    {
        if (!CheckIsInMapLimit(actualRoom.rect))
        {
            actualRoom.rect.Copy(modifInfoRoom.lastFrameRect);
            actualRoom.CreateLines();
        }
        else
        {
            modifInfoRoom.lastFrameRect.Copy(actualRoom.rect);
            actualRoom.CreateLines();
        }
    }

    void CheckRectDiff()
    {
        int diffWidth = modifInfoRoom.lastRect.width - actualRoom.rect.width;
        int diffHeight = modifInfoRoom.lastRect.height - actualRoom.rect.height;

        if (Mathf.Abs(diffWidth) >= 1)
        {
            modifInfoRoom.lastRect.Copy(actualRoom.rect);
            if (diffWidth < 0)
            {
                modifInfoRoom.signWidth = modifSign.NEGATIF;
            }
            else if (diffWidth > 0)
            {
                modifInfoRoom.signWidth = modifSign.POSITIF;
            }
            actualRoom.isWidthChange = true;
        }
        else
        {
            actualRoom.isWidthChange = false;
        }
        if (Mathf.Abs(diffHeight) >= 1)
        {
            modifInfoRoom.lastRect.Copy(actualRoom.rect);
            if (diffHeight < 0)
            {
                modifInfoRoom.signHeight = modifSign.NEGATIF;
            }
            else if (diffHeight > 0)
            {
                modifInfoRoom.signHeight = modifSign.POSITIF;
            }
            actualRoom.isHeightChange = true;
        }
        else
        {
            actualRoom.isHeightChange = false;
        }
    }

    void SetRoomState()
    {
        int nbBlockNeeded = (actualRoom.rect.width + 1) * (actualRoom.rect.height + 1);

        if (nbBlockNeeded == actualRoom.ground.transform.childCount)
        {
            actualRoom.state = state.FINISHED;
        }
        else
        {
            actualRoom.state = state.BUILDING;
        }
    }

    bool CheckIsInMapLimit(MyRect actualRect)
    {
        if ((actualRect.x + actualRect.width) < minPos.x ||
            (actualRect.x + actualRect.width) > maxPos.x ||
            (actualRect.y + actualRect.height) < minPos.y ||
            (actualRect.y + actualRect.height) > maxPos.y)
        {
            return false;
        }
        return true;
    }

    bool CheckIsInMapLimit(Vector3 position)
    {
        if (position.x < minPos.x ||
            position.x > maxPos.x ||
            position.z < minPos.y ||
            position.z > maxPos.y)
        {
            return false;
        }
        return true;
    }

    bool CheckMouseIsInMapLimit(Vector3 position)
    {
        if (position.x < minPos.x + 1 ||
            position.x > maxPos.x - 1 ||
            position.z < minPos.y + 1 ||
            position.z > maxPos.y - 1)
        {
            return false;
        }
        return true;
    }

    bool CheckIndexIsInRectBounces(int indexX, int indexZ)
    {
        Vector2 indexInWorld = GetIndexInWorld(indexX, indexZ);
        if (indexInWorld.x >= actualRoom.rect.x && indexInWorld.x <= actualRoom.rect.x + actualRoom.rect.width &&
            indexInWorld.y >= actualRoom.rect.y && indexInWorld.y <= actualRoom.rect.y + actualRoom.rect.height)
        {
            return true;
        }
        return false;
    }

    bool CheckIndexIsInRoomRect(int indexX, int indexZ)
    {
        Vector2 indexInWorld = new Vector2(indexX, indexZ);

        foreach (Room r in rooms)
        {
            if (indexInWorld.x >= r.rect.x && indexInWorld.x <= r.rect.x + r.rect.width &&
                indexInWorld.y >= r.rect.y && indexInWorld.y <= r.rect.y + r.rect.height)
            {
                return true;
            }
        }
        return false;
    }

    bool CheckDontDestroyOtherRect(int indexX, int indexZ, bool isConsideringWall = true, bool isConsideringBridge = true)
    {
        Vector2 indexInWorld = GetIndexInWorld(indexX, indexZ);
        foreach (Room room in rooms)
        {
            if (isConsideringWall)
            {
                if (indexInWorld.x >= room.rect.x - 1 && indexInWorld.x <= (room.rect.x + room.rect.width + 1) &&
                    indexInWorld.y >= room.rect.y - 1 && indexInWorld.y <= (room.rect.y + room.rect.height + 1))
                {
                    return false;
                }
                if (isConsideringBridge)
                {
                    foreach (MyRect rect in room.rectBridgeRight)
                    {
                        if (indexInWorld.x >= rect.x - 1 && indexInWorld.x <= (rect.x + rect.width + 1) &&
                            indexInWorld.y >= rect.y - 1 && indexInWorld.y <= (rect.y + rect.height + 1))
                        {
                            return false;
                        }
                    }
                    foreach (MyRect rect in room.rectBridgeLeft)
                    {
                        if (indexInWorld.x >= rect.x - 1 && indexInWorld.x <= (rect.x + rect.width + 1) &&
                            indexInWorld.y >= rect.y - 1 && indexInWorld.y <= (rect.y + rect.height + 1))
                        {
                            return false;
                        }
                    }
                    foreach (MyRect rect in room.rectBridgeTop)
                    {
                        if (indexInWorld.x >= rect.x - 1 && indexInWorld.x <= (rect.x + rect.width + 1) &&
                            indexInWorld.y >= rect.y - 1 && indexInWorld.y <= (rect.y + rect.height + 1))
                        {
                            return false;
                        }
                    }
                    foreach (MyRect rect in room.rectBridgeBot)
                    {
                        if (indexInWorld.x >= rect.x - 1 && indexInWorld.x <= (rect.x + rect.width + 1) &&
                            indexInWorld.y >= rect.y - 1 && indexInWorld.y <= (rect.y + rect.height + 1))
                        {
                            return false;
                        }
                    } 
                }
            }
            else
            {
                if (indexInWorld.x >= room.rect.x && indexInWorld.x <= (room.rect.x + room.rect.width) &&
                    indexInWorld.y >= room.rect.y && indexInWorld.y <= (room.rect.y + room.rect.height))
                {
                    return false;
                }
                if (isConsideringBridge)
                {
                    foreach (MyRect rect in room.rectBridgeRight)
                    {
                        if (indexInWorld.x >= rect.x && indexInWorld.x <= (rect.x + rect.width) &&
                            indexInWorld.y >= rect.y && indexInWorld.y <= (rect.y + rect.height))
                        {
                            return false;
                        }
                    }
                    foreach (MyRect rect in room.rectBridgeLeft)
                    {
                        if (indexInWorld.x >= rect.x && indexInWorld.x <= (rect.x + rect.width) &&
                            indexInWorld.y >= rect.y && indexInWorld.y <= (rect.y + rect.height))
                        {
                            return false;
                        }
                    }
                    foreach (MyRect rect in room.rectBridgeTop)
                    {
                        if (indexInWorld.x >= rect.x && indexInWorld.x <= (rect.x + rect.width) &&
                            indexInWorld.y >= rect.y && indexInWorld.y <= (rect.y + rect.height))
                        {
                            return false;
                        }
                    }
                    foreach (MyRect rect in room.rectBridgeBot)
                    {
                        if (indexInWorld.x >= rect.x && indexInWorld.x <= (rect.x + rect.width) &&
                            indexInWorld.y >= rect.y && indexInWorld.y <= (rect.y + rect.height))
                        {
                            return false;
                        }
                    } 
                }
            }
        }
        return true;
    }

    void ComputeDisplayDirection()
    {
        //Cas T L
        if (mousePosFirstClick.x > mousePositionInWorld.x &&
            mousePosFirstClick.z < mousePositionInWorld.z)
        {
            displayDir = new Vector2(-1.0f, 1.0f);
        }
        //Cas T R
        else if (mousePosFirstClick.x < mousePositionInWorld.x &&
                 mousePosFirstClick.z < mousePositionInWorld.z)
        {
            displayDir = new Vector2(1.0f, 1.0f);
        }
        //Cas B L
        else if (mousePosFirstClick.x > mousePositionInWorld.x &&
                 mousePosFirstClick.z > mousePositionInWorld.z)
        {
            displayDir = new Vector2(-1.0f, -1.0f);
        }
        //Cas B R
        else if (mousePosFirstClick.x < mousePositionInWorld.x &&
                 mousePosFirstClick.z > mousePositionInWorld.z)
        {
            displayDir = new Vector2(1.0f, -1.0f);
        }
    }

    void PreDisplayObject()
    {
        if (isPhaseRoom && predisplayObjectType != type.GROUND)
        {
            DestroyPredisplayObject();
            preDisplayObjectInstance = GameObject.Instantiate(ground, mousePositionInWorld, Quaternion.identity) as GameObject;
            preDisplayObjectInstance.transform.SetParent(displayObjectParent.transform);
            predisplayObjectType = type.GROUND;
        }
        if (isPhaseDoor && predisplayObjectType != type.DOOR)
        {
            DestroyPredisplayObject();
            preDisplayObjectInstance = GameObject.Instantiate(door, mousePositionInWorld, Quaternion.identity) as GameObject;
            preDisplayObjectInstance.transform.SetParent(displayObjectParent.transform);
            predisplayObjectType = type.DOOR;
        }
        if (isPhaseBridge && predisplayObjectType != type.BRIDGE)
        {
            DestroyPredisplayObject();
            preDisplayObjectInstance = GameObject.Instantiate(bridge, mousePositionInWorld, Quaternion.identity) as GameObject;
            preDisplayObjectInstance.transform.SetParent(displayObjectParent.transform);
            predisplayObjectType = type.BRIDGE;
        }
        else if (!isPhaseRoom && !isPhaseDoor && !isPhaseBridge && !isPhaseKeyObject)
        {
            if (preDisplayObjectInstance != null)
            {
                Destroy(preDisplayObjectInstance);
                preDisplayObjectInstance = null;
                predisplayObjectType = type.NONE;
            }
        }
        if (preDisplayObjectInstance != null)
        {
            preDisplayObjectInstance.transform.position = new Vector3(mousePositionInWorld.x, floorHeight, mousePositionInWorld.z);
        }
    }

    void DestroyPredisplayObject()
    {
        if (preDisplayObjectInstance != null)
        {
            GameObject.DestroyImmediate(preDisplayObjectInstance);
            preDisplayObjectInstance = null;
            predisplayObjectType = type.NONE;
        }
    }

    //Room Collision function

    bool Collide(Vector2 minA, Vector2 maxA, Vector2 minB, Vector2 maxB)
    {
        float margin = 2.0f;

        minA.x -= margin;
        minA.y -= margin;
        maxA.x += margin;
        maxA.y += margin;

        minB.x -= margin;
        minB.y -= margin;
        maxB.x += margin;
        maxB.y += margin;

        return !(minA.x > maxB.x || minB.x > maxA.x || minA.y > maxB.y || minB.y > maxA.y);
    }

    bool IsRoomIntersect(Room roomCheck)
    {
        List<Vector2> points = new List<Vector2>();


        points.Add(new Vector2(roomCheck.rect.x, roomCheck.rect.y));
        points.Add(new Vector2(roomCheck.rect.x, roomCheck.rect.y + roomCheck.rect.height));
        points.Add(new Vector2(roomCheck.rect.x + roomCheck.rect.width, roomCheck.rect.y + roomCheck.rect.height));
        points.Add(new Vector2(roomCheck.rect.x + roomCheck.rect.width, roomCheck.rect.y));

        Vector2 minA = new Vector2(roomCheck.rect.x, roomCheck.rect.y);
        Vector2 maxA = minA + new Vector2(roomCheck.rect.width, roomCheck.rect.height);

        foreach (Room room in rooms)
        {
            Vector2 minB = new Vector2(room.rect.x, room.rect.y);
            Vector2 maxB = minB + new Vector2(room.rect.width, room.rect.height);

            if (Collide(minA, maxA, minB, maxB))
            {
                return true;
            }
        }
        return false;
    }

    //Function for UI

    public void SetIsInEditor()
    {
        isPhaseRoom = false;
        isPhaseDoor = false;
        isPhaseBridge = false;
        isPhaseKeyObject = false;
        DestroyPredisplayObject();

        isInEditor = !isInEditor;
    }

    public void SetIsPhaseRoom()
    {
        if (isPhaseRoom)
        {
            ResetRoom();
        }
        isPhaseDoor = false;
        isPhaseBridge = false;
        isPhaseKeyObject = false;

        isPhaseRoom = !isPhaseRoom;
    }

    public void SetIsPhaseBridge()
    {
        if (isPhaseRoom)
        {
            ResetRoom();
        }
        isPhaseRoom = false;
        isPhaseDoor = false;
        isPhaseKeyObject = false;
        
        isPhaseBridge = !isPhaseBridge;
    }

    public void SetIsPhaseDoor()
    {

        isPhaseRoom = false;
        isPhaseBridge = false;
        isPhaseKeyObject = false;

        isPhaseDoor = !isPhaseDoor;
    }

    public void SetIsPhaseKeyObject()
    {
        ResetRoom();
        isPhaseRoom = false;
        isPhaseDoor = false;
        isPhaseBridge = false;
        isPhaseKeyObject = !isPhaseKeyObject;
    }

    public void SetIsPhaseValidation()
    {
        isPhaseValidation = !isPhaseValidation;
    }

    private void ResetPhase()
    {
        isPhaseRoom = false;
        isPhaseDoor = false;
        isPhaseBridge = false;
        isPhaseKeyObject = false;
    } 

    //Get Information

    public GameObject GetBarInstance()
    {
        return barInstance;
    }

    public int GetRoomIndex(int x, int z, int width, int height)
    {
        int index = -1;

        foreach (Room room in rooms)
        {
            index++;
            if (x >= room.rect.x && x + width <= (room.rect.x + room.rect.width + 1) &&
                z >= room.rect.y && z + height <= (room.rect.y + room.rect.height + 1))
            {
                return index;
            }
        }
        return -1;
    }

    public void SetRoomCategory(int index, ObjectCategory objectTypeAllow)
    {
       rooms[index].objectTypeAllow = objectTypeAllow;
    }

    public ObjectCategory GetRoomCategory(int index)
    {
        return rooms[index].objectTypeAllow;
    }

    // Furniture function

    public void AddFurniture(GameObject newFurniture)
    {
        furnitures.Add(newFurniture);
    }

    public void RemoveFurniture(GameObject furniture)
    {
        furnitures.Remove(furniture);
    }

    public bool CheckOverFurniture(GameObject actualFurniture)
    {
        foreach (GameObject furniture in furnitures)
        {
            if (furniture != actualFurniture)
            {
                Furniture f = furniture.GetComponent<Furniture>();
                Vector3 actualPos = actualFurniture.transform.position;
                Vector2 dist = new Vector2(Mathf.Abs(actualPos.x - furniture.transform.position.x), Mathf.Abs(actualPos.z - furniture.transform.position.z));

                if (dist.x <= (f.objectSize.x * 0.5f + 1) && dist.y <= (f.objectSize.y * 0.5f + 1))
                {
                    return false;
                }
            }
        }
        return true;
    }

    //Mathematics function

    bool IsPointInRoomRect(Vector2 point, Room room)
    {
        MyRect rect = room.rect;

        if (point.x >= rect.x && 
            point.x <= (rect.x + rect.width) &&
            point.y >= rect.y && 
            point.y <= (rect.y + rect.height))
        {
            return true;
        }
        return false;
    }

 // Pool object function

    void CreatePoolObject()
    {
        int bufferSize = ComputeSizeBufferWithPercentage(groundPercent);

        for (int i = 0; i < bufferSize; ++i)
        {
            groundPool.Add(GameObject.Instantiate(ground));
            groundPool[groundPool.Count - 1].SetActive(false);
            groundPool[groundPool.Count - 1].transform.SetParent(mapParent.transform);
        }

        bufferSize = ComputeSizeBufferWithPercentage(bridgePercent);

         for (int i = 0; i < bufferSize; ++i)
        {
            bridgePool.Add(GameObject.Instantiate(bridge));
            bridgePool[bridgePool.Count - 1].SetActive(false);
            bridgePool[bridgePool.Count - 1].transform.SetParent(mapParent.transform);
        }

        bufferSize = ComputeSizeBufferWithPercentage(wallgroundPercent);

         for (int i = 0; i < bufferSize; ++i)
        {
            wallgroundPool.Add(GameObject.Instantiate(wall));
            wallgroundPool[wallgroundPool.Count - 1].SetActive(false);
            wallgroundPool[wallgroundPool.Count - 1].transform.SetParent(mapParent.transform);
        }

        bufferSize = ComputeSizeBufferWithPercentage(wallbridgePercent);

         for (int i = 0; i < bufferSize; ++i)
        {
            wallbridgePool.Add(GameObject.Instantiate(wall));
            wallbridgePool[wallbridgePool.Count - 1].SetActive(false);
            wallbridgePool[wallbridgePool.Count - 1].transform.SetParent(mapParent.transform);
        }

        bufferSize = ComputeSizeBufferWithPercentage(externalCornerPercent);

         for (int i = 0; i < bufferSize; ++i)
        {
            externalCornerPool.Add(GameObject.Instantiate(externalCornerWall));
            externalCornerPool[externalCornerPool.Count - 1].SetActive(false);
            externalCornerPool[externalCornerPool.Count - 1].transform.SetParent(mapParent.transform);
        }

        bufferSize = ComputeSizeBufferWithPercentage(internalCornerPercent);

         for (int i = 0; i < bufferSize; ++i)
        {
            internalCornerPool.Add(GameObject.Instantiate(internalCornerWall));
            internalCornerPool[internalCornerPool.Count - 1].SetActive(false);
            internalCornerPool[internalCornerPool.Count - 1].transform.SetParent(mapParent.transform);
        }
    }

    int ComputeSizeBufferWithPercentage(int percentage)
    {
        int value = -1;
        int mapSize = mapWidth * mapHeight;

        value = (mapSize * percentage) / 100;

        return value;
    }

    GameObject PoolObjectRequest(type objectType)
    {
        GameObject objectRequested = null;

        if (objectType == type.GROUND)
        {
            objectRequested = groundPool[0];
            groundPool.RemoveAt(0);
            objectRequested.SetActive(true);
        }
        if (objectType == type.BRIDGE)
        {
            objectRequested = bridgePool[0];
            bridgePool.RemoveAt(0);
            objectRequested.SetActive(true);
        }
        if (objectType == type.WALLGROUND)
        {
            objectRequested = wallgroundPool[0];
            wallgroundPool.RemoveAt(0);
            objectRequested.SetActive(true);
        }
        if (objectType == type.WALLBRIDGE)
        {
            objectRequested = wallbridgePool[0];
            wallbridgePool.RemoveAt(0);
            objectRequested.SetActive(true);
        }
        if (objectType == type.INTERNALCORNER)
        {
            objectRequested = internalCornerPool[0];
            internalCornerPool.RemoveAt(0);
            objectRequested.SetActive(true);
        }
        if (objectType == type.EXTERNALCORNER)
        {
            objectRequested = externalCornerPool[0];
            externalCornerPool.RemoveAt(0);
            objectRequested.SetActive(true);
        }

        return objectRequested;
    }

    void PoolObjectAddBuffer(type objectType, GameObject newObject)
    {
        if (objectType == type.GROUND)
        {
            newObject.transform.SetParent(null);
            newObject.transform.rotation = Quaternion.identity;
            groundPool.Add(newObject);
            groundPool[groundPool.Count - 1].SetActive(false);
        }
        if (objectType == type.BRIDGE)
        {
            newObject.transform.SetParent(null);
            newObject.transform.rotation = Quaternion.identity;
            bridgePool.Add(newObject);
            bridgePool[bridgePool.Count - 1].SetActive(false);
        }
        if (objectType == type.WALLGROUND)
        {
            newObject.transform.SetParent(null);
            newObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            if (newObject.transform.GetChild(0) != null)
            {
                newObject.transform.GetChild(0).eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            }
            wallgroundPool.Add(newObject);
            wallgroundPool[wallgroundPool.Count - 1].SetActive(false);
        }
        if (objectType == type.WALLBRIDGE)
        {
            newObject.transform.SetParent(null);
            newObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            newObject.transform.GetChild(0).eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            wallbridgePool.Add(newObject);
            wallbridgePool[wallbridgePool.Count - 1].SetActive(false);
        }
        if (objectType == type.INTERNALCORNER)
        {
            newObject.transform.SetParent(null);
            newObject.transform.rotation = Quaternion.identity;
            internalCornerPool.Add(newObject);
            internalCornerPool[internalCornerPool.Count - 1].SetActive(false);
        }
        if (objectType == type.EXTERNALCORNER)
        {
            newObject.transform.SetParent(null);
            newObject.transform.rotation = Quaternion.identity;
            externalCornerPool.Add(newObject);
            externalCornerPool[externalCornerPool.Count - 1].SetActive(false);
        }
    }

    void PoolObjectRelease(type objectType)
    {
        RemoveBufferGameObject(groundPool);
        groundPool.RemoveRange(0, groundPool.Count - 1);
        RemoveBufferGameObject(bridgePool);
        bridgePool.RemoveRange(0, bridgePool.Count - 1);

        RemoveBufferGameObject(wallgroundPool);
        wallgroundPool.RemoveRange(0, wallgroundPool.Count - 1);
        RemoveBufferGameObject(wallbridgePool);
        wallbridgePool.RemoveRange(0, wallbridgePool.Count - 1);

        RemoveBufferGameObject(internalCornerPool);
        internalCornerPool.RemoveRange(0, internalCornerPool.Count - 1);
        RemoveBufferGameObject(externalCornerPool);
        externalCornerPool.RemoveRange(0, externalCornerPool.Count - 1);
    }

    void RemoveBufferGameObject(List<GameObject> buffer)
    {
        for (int i = 0; i < buffer.Count ; ++i)
        {
            GameObject.Destroy(buffer[i]);
        }
    }

    int CheckPoolSize(type objectType)
    {
        if (objectType == type.GROUND)
        {
            return groundPool.Count;
        }
        if (objectType == type.BRIDGE)
        {
            return bridgePool.Count;
        }
        if (objectType == type.WALLGROUND)
        {
            return wallgroundPool.Count;
        }
        if (objectType == type.WALLBRIDGE)
        {
            return wallbridgePool.Count;
        }
        if (objectType == type.INTERNALCORNER)
        {
            return internalCornerPool.Count;
        }
        if (objectType == type.EXTERNALCORNER)
        {
            return externalCornerPool.Count;
        }

        return 0;
    }
}