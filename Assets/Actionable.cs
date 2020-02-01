using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionable : MonoBehaviour
{

    public enum ACTION { DRAIN, FILL, NOTHING };

    public ACTION action = ACTION.NOTHING;
    public float unitsPerSecond = 1;
    public int playerId = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
