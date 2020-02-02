using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{
    private float timeFromLastWaterDrop = 0;

    private List<GameObject> waterdrops = new List<GameObject>();

    public GameObject waterdropPrefab;

    public float waterdropSpawnSpeed = 1;

    public List<GameObject> getWaterdrops()
    {
        return this.waterdrops;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        dropWater();
    }

    void dropWater()
    {
        timeFromLastWaterDrop += Time.deltaTime;
        if (timeFromLastWaterDrop >= waterdropSpawnSpeed)
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
}
