using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionable : MonoBehaviour
{

    public enum ACTION { DRAIN, FILL, REPAIR, NOTHING };

    public ACTION action = ACTION.NOTHING;
    public float percentagePerSecond = 1;
    public float secondsForRepairing = 2;
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
