using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathColliderBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "torso" || collision.gameObject.name == "rightHand" || collision.gameObject.name == "leftHand")
        {
            Destroy(collision.gameObject);
            
        }
    }
}
