using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBehaviour : MonoBehaviour
{
    public float factor = 100;
    public float factorGrabbing = 15;
    public float maxVelocity = 10;

    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update() { 
    
    }

    void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.attachedRigidbody && hit.gameObject.tag == "Player")
        {
            RagdollController ragdollController = hit.transform.GetComponentInParent<RagdollController>();

            float effectiveFactor = factor;

            if (ragdollController.isGrabbing) effectiveFactor = factorGrabbing;

            if (hit.transform.position.y + (hit.transform.localScale.y / 2) < transform.position.y + (transform.localScale.y / 2))
            {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector3.up * rb.mass * effectiveFactor);

                if (rb.velocity.y > maxVelocity) rb.velocity = new Vector2(rb.velocity.x, maxVelocity);
            }
           
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.attachedRigidbody && hit.gameObject.tag == "Player")
        {
            GameObject splash = Instantiate(particle);
            splash.transform.position = hit.transform.position;
        }
    }

    void increaseLevel()
    {

    }

    void decreaseLevel()
    {

    }

}
