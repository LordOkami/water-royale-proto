using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterdropBehaviour : MonoBehaviour
{
    public float pixelsPerFrame = 0.1f;
    public GameObject splash;
    public float height = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.position.y < -((height / 2) + this.transform.lossyScale.y))
        {
            GameObject sp = Instantiate(splash);
            sp.transform.position = this.gameObject.transform.position;

            Destroy(this.gameObject);

        }
    }
}
