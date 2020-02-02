using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentGameController : MonoBehaviour
{

    public float pixelsPerFrame = 0.01f;
    
    public int width = 10;
    public int height = 10;

    public int maxCracksOpen = 10;

    public GameObject[] availableActionables;
    private List<GameObject> currentActionables = new List<GameObject>();
    private GameObject waterObject;
    private int cracksOpen = 0;

    public float waterLevelPercentage = 50;
    public float crackFillSpeed = 0.2f;

    public GameObject oponentRagdoll;
    public bool attacker;

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
        this.waterLevelPercentage += (this.crackFillSpeed * this.cracksOpen) / Application.targetFrameRate;
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
        Player p;
        if(attacker){
          p = NetworkManager.my_attacker_player;
        }
        else {
          p = NetworkManager.my_target_player;
        }
        if(p != null && p.transformation != null){
          string [] positions = p.transformation.Split(';');
          float pos_x = float.Parse(positions[0]);
          float pos_y = float.Parse(positions[1]);
          float rot_z = float.Parse(positions[2]);

          oponentRagdoll.transform.position = (
            gameContainer.transform.position + 
            new Vector3(pos_x, pos_y, 0) );
          oponentRagdoll.transform.rotation = new Quaternion(0,0,rot_z,1);
          this.waterLevelPercentage = p.water_level;
        }
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

    public void setWaterLevel(float level)
    {
        this.waterLevelPercentage = level;
    }

}
