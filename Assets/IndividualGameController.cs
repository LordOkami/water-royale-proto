using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualGameController : MonoBehaviour
{

    public float valveSpawnEverySeconds = 1f;
    public float pixelsPerFrame = 0.01f;
    
    public int width = 10;
    public int height = 10;

    public int maxCracksOpen = 10;

    public GameObject[] availableActionables;
    private List<GameObject> currentActionables = new List<GameObject>();
    private GameObject waterObject;
    private int cracksOpen = 0;

    public static float waterLevelPercentage = 50;
    public float crackFillSpeed = 0.2f;
    
    //private int maxActionablesPerIteration = 3;

    private GameObject gameContainer;


        

    void Awake()
    {
        // Uncommenting this will cause framerate to drop to 10 frames per second.
        // This will mean that FixedUpdate is called more often than Update.
        Application.targetFrameRate = 60;
        //availableActionables = Resources.LoadAll("Prefab/Valves", typeof(GameObject));

        
    }
    internal void executeActionable(Actionable actionable)
    {
        switch (actionable.action)
        {
            case Actionable.ACTION.DRAIN:
                waterLevelPercentage -= actionable.percentagePerSecond / Application.targetFrameRate;

                break;
            case Actionable.ACTION.FILL:
                waterLevelPercentage += actionable.percentagePerSecond / Application.targetFrameRate;

                break;
            case Actionable.ACTION.REPAIR:
                CrackBehaviour crack = actionable.gameObject.GetComponent<CrackBehaviour>();

                crack.Repair(actionable, this);

                break;
        }
    }



    // Start is called before the first frame update
    void Start()
    {

        //Create the game container
        gameContainer = transform.Find("GameContainer").gameObject;
        gameContainer.transform.localScale = new Vector3(width, height,1);
        
        //Get the water
        waterObject = transform.Find("Water").gameObject;


        int wallCount = transform.Find("Walls").childCount;
        for(int i = 0; i< wallCount; i++)
        {
            Transform wallTransform = transform.Find("Walls").GetChild(i).transform;
            wallTransform.localScale = new Vector2(wallTransform.localScale.x, height);
        }
    }

    // Update is called once per frame
    void Update()
    {
        waterLevelPercentage += (this.crackFillSpeed * this.cracksOpen) / Application.targetFrameRate;
    }

    // Increase the number of calls to FixedUpdate.
    void FixedUpdate()
    {
        float waterHeight = height * (waterLevelPercentage/100);
        waterObject.transform.localPosition = new Vector2(0, -(height/2)+(waterHeight/2));
        waterObject.transform.localScale = new Vector2(width, waterHeight);

        List<GameObject> elementsToBeDeleted = new List<GameObject>();
        currentActionables.ForEach(go =>
        {
            go.transform.position = go.transform.position - new Vector3(0, pixelsPerFrame);
            if (go.transform.position.y < -((height / 2) + go.transform.lossyScale.y))
            {
                elementsToBeDeleted.Add(go);
            }
            else if (go.CompareTag("waterdrop"))
            {
                List<GameObject> dropsToBeDeleted = new List<GameObject>();
                foreach (GameObject drop in go.GetComponent<CrackBehaviour>().getWaterdrops())
                {
                    if (drop.transform.position.y < (-(height / 2) + waterHeight))
                    {
                        dropsToBeDeleted.Add(drop);
                    }
                }

                dropsToBeDeleted.ForEach(etbd =>
                {
                    Destroy(etbd);
                    go.GetComponent<CrackBehaviour>().getWaterdrops().Remove(etbd);
                });
            }
        });

        //Delete old objects

        elementsToBeDeleted.ForEach(etbd =>
        {
            Destroy(etbd);
            currentActionables.Remove(etbd);
        });
    }

    public void repairCrack(GameObject crack)
    {
        this.cracksOpen--;
        this.currentActionables.Remove(crack);
        Destroy(crack);
    }

    public void spawnValve(ValveSpawn _spawn)
    {
        GameObject newValve = Instantiate(this.availableActionables[_spawn.type]);

        if(newValve.CompareTag("waterdrop") && this.cracksOpen < this.maxCracksOpen)
        {
            cracksOpen++;
        }
        
        newValve.transform.parent = this.gameContainer.transform;

        newValve.transform.localPosition = new Vector3(_spawn.pos_x, 0.5f , 0);
        this.currentActionables.Add(newValve);
    }

}
