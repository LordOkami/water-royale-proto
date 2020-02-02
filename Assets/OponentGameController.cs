using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentGameController : MonoBehaviour
{

    public float pixelsPerFrame = 0.01f;
    
    public int width = 10;
    public int height = 10;

    public static int maxCracksOpen = 10;

    public static GameObject[] availableActionables;
    private static List<GameObject> currentActionables = new List<GameObject>();
    private GameObject waterObject;
    private static int cracksOpen = 0;

    public float waterLevelPercentage = 50;
    public float crackFillSpeed = 0.2f;

    private GameObject oponentRagdoll;

    //private int maxActionablesPerIteration = 3;

    private GameObject gameContainer;


    // Start is called before the first frame update
    void Start()
    {
        //Create the game container
        gameContainer = transform.Find("GameContainer").gameObject;
        gameContainer.transform.localScale = new Vector2(width, height);

        //Get the water
        waterObject = transform.Find("OponentWater").gameObject;


        int wallCount = transform.Find("Walls").childCount;
        for (int i = 0; i < wallCount; i++)
        {
            Transform wallTransform = transform.Find("Walls").GetChild(i).transform;
            wallTransform.localScale = new Vector2(wallTransform.localScale.x, height);
        }


    }

    // Update is called once per frame
    void Update()
    {
        waterLevelPercentage += (crackFillSpeed * cracksOpen) / Application.targetFrameRate;
    }

    // Increase the number of calls to FixedUpdate.
    void FixedUpdate()
    {
        float waterHeight = height * (waterLevelPercentage / 100);
        waterObject.transform.localPosition = new Vector2(0, -(height / 2) + (waterHeight / 2));
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

    public static void repairCrack(GameObject crack)
    {
        cracksOpen--;
        currentActionables.Remove(crack);
        Destroy(crack);
    }
    public static void spawnValve(ValveSpawn _spawn)
    {
        GameObject newValve = Instantiate(availableActionables[_spawn.type]);

        if(newValve.CompareTag("waterdrop") && cracksOpen < maxCracksOpen)
        {
            cracksOpen++;
        }
        
        newValve.transform.parent = gameContainer.transform;

        newValve.transform.localPosition = new Vector3(_spawn.pos_x, 0.5f , 0);
        currentActionables.Add(newValve);
    }

}
