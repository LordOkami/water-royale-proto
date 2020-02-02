using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class RagdollController : MonoBehaviour
{

    public static GameObject cameraMan;
    public float force = 100;

    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject torso;

    public bool interacting = false;
    private Transform valve;


    private Rigidbody2D leftHandRb;
    private Rigidbody2D rightHandRb;

    public bool isGrabbing = false;
    Vector2 leftAxis;

    private void OnEnable()
    {
        transform.parent = GameObject.FindGameObjectWithTag("Game").transform;
    }

    private void OnMove(InputValue value)
    {
        leftAxis = value.Get<Vector2>();
    }


    private void OnInteract(InputValue value)
    {
        interacting = value.isPressed;
    }

    void Start()
    {
        leftHandRb = leftHand.GetComponent<Rigidbody2D>();
        rightHandRb = rightHand.GetComponent<Rigidbody2D>();

    }


    private void FixedUpdate()
    {
        leftHandRb.AddForce(leftAxis * force);
        rightHandRb.AddForce(leftAxis * force);

        string transformation =  torso.transform.position.x +
        ";"
         + torso.transform.position.y + ";"
         + torso.transform.rotation.z
         ;
        GameChannel.SendUpdate(transformation, 0);
    }

    public bool GetInteracting()
    {
        return interacting;
    }

}
