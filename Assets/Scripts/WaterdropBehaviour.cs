using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterdropBehaviour : MonoBehaviour
{
    public float pixelsPerFrame = 0.1f;
    public int height = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = this.transform.position - new Vector3(0, pixelsPerFrame);
        if (this.transform.position.y < -((height / 2) + this.transform.lossyScale.y))
        {
            Destroy(this.gameObject);
        }
    }
}
