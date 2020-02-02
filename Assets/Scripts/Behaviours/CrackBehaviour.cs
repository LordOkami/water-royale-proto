using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackBehaviour : MonoBehaviour
{
    private int level = 1;
    private float timeToLevelUp;
    private float timeFromLevelUp = 0;
    private float timeFromLastWaterDrop = 0;

    private float timeRepairing = 0;

    private List<GameObject> waterdrops = new List<GameObject>();

    public Sprite[] levelSprites;
    public GameObject waterdropPrefab;
    public GameObject sparkPrefab;

    private GameObject spawnedSpark;

    public float waterdropSpawnSpeed = 1;

    public List<GameObject> getWaterdrops()
    {
        return this.waterdrops;
    }

    public void spawnSparks()
    {
        if(!this.spawnedSpark)
        {
            GameObject spark = Instantiate(sparkPrefab);
            spark.transform.parent = this.transform;
            spark.transform.position = this.transform.position;
            this.spawnedSpark = spark;
        }
    }

    public void removeSparks()
    {
        if (this.spawnedSpark)
        {
            Destroy(this.spawnedSpark);
            this.spawnedSpark = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeToLevelUp = UnityEngine.Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        levelUp();
        dropWater();
    }

    void levelUp()
    {
        if(this.level < 3)
        {
            timeFromLevelUp += Time.deltaTime;
            if(timeFromLevelUp >= timeToLevelUp)
            {
                level++;
                timeFromLevelUp = 0;
                updateSprite();
            }
        }
    }

    void updateSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = this.levelSprites[this.level - 1];
    }

    void dropWater()
    {
        timeFromLastWaterDrop += Time.deltaTime;
        if(timeFromLastWaterDrop >= waterdropSpawnSpeed / level)
        {
            spawnWaterDrop();
            timeFromLastWaterDrop = 0;
        }
    }

    void spawnWaterDrop()
    {
        GameObject waterdrop = Instantiate(waterdropPrefab);
        waterdrop.transform.parent = this.transform;
        waterdrop.transform.position = this.transform.position;

        waterdrop.GetComponent<Rigidbody2D>().AddForce(new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, 0));

        waterdrops.Add(waterdrop);
    }

    internal void Repair(Actionable actionable, IndividualGameController individualGameController)
    {
        timeRepairing += Time.deltaTime;
        Debug.Log(Time.deltaTime);
        spawnSparks();
        if (timeRepairing >= actionable.secondsForRepairing)
        {
            individualGameController.repairCrack(this.gameObject);
            timeRepairing = 0;
        }
    }
}
