using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandController : MonoBehaviour
{

    private RagdollController ragdollController;
    IndividualGameController individualGameController;

    private DistanceJoint2D joint;
    // Start is called before the first frame update
    void Start()
    {
        ragdollController = this.GetComponentInParent<RagdollController>();
        joint = transform.GetComponent<DistanceJoint2D>();
        individualGameController = GetComponentInParent<IndividualGameController>();

    }

    private void FixedUpdate()
    {
        if(!ragdollController.interacting || !joint.connectedBody)
        {
            joint.enabled = false;
            ragdollController.isGrabbing = false;
        }

        if(ragdollController.isGrabbing && joint.enabled && joint.connectedBody)
        {
            
            Actionable actionable = joint.connectedBody.GetComponent<Actionable>();
            individualGameController.executeActionable(actionable);

        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Water"|| collider.gameObject.tag == "Untagged" || ragdollController.interacting == false) return;

        if (collider.gameObject.tag == "Valve" || collider.gameObject.tag == "waterdrop")
        {
            Debug.Log("DRAGGGG");
            
            joint.connectedBody = collider.gameObject.GetComponent<Rigidbody2D>();
            joint.enabled = true;
            ragdollController.isGrabbing = true;
        }
    }
}
