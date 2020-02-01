using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandController : MonoBehaviour
{

    private RagdollController ragdollController;
    // Start is called before the first frame update
    void Start()
    {
        ragdollController = transform.GetComponentInParent<RagdollController>();
    }


    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Water"|| collider.gameObject.tag == "Untagged" || ragdollController.interacting == false) return;

        if (collider.gameObject.tag == "Valve" && ragdollController.interacting)
        {
            Debug.Log("DRAGGGG");
        }
    }
}
