using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualGameController : MonoBehaviour
{

    public int valveSpawnsPerSeconds = 3;
    public int pixelsPerFrame = 10;
    
    public int width = 480;
    public int height = 720;

    private List<GameObject> actionables;
        
    private int step = 0;
    private int currentOffset = 0;

    void Awake()
    {
        // Uncommenting this will cause framerate to drop to 10 frames per second.
        // This will mean that FixedUpdate is called more often than Update.
        Application.targetFrameRate = 60;
      
    }


    // Start is called before the first frame update
    void Start()
    {

        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = new Vector3(0, 0, 0);
        plane.transform.localScale = new Vector3(width,0, height);
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Increase the number of calls to FixedUpdate.
    void FixedUpdate()
    {
        currentOffset = step * pixelsPerFrame;
        step++;
        Debug.Log(step);
    }


}
