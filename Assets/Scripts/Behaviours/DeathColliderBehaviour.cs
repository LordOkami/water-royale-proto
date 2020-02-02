using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathColliderBehaviour : MonoBehaviour
{
    public GameObject deathScreenPrefab;

    private bool deathScreenShown = false;

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
        if (collision.gameObject.name == "torso")
        {
            Destroy(collision.gameObject.transform.parent.Find("leftHand").gameObject);
            Destroy(collision.gameObject.transform.parent.Find("rightHand").gameObject);
            Destroy(collision.gameObject);
            GameObject deathScreen = Instantiate(deathScreenPrefab);
            deathScreen.transform.position = new Vector2(0, 0);
        }
    }
}
