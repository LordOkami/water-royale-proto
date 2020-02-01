using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class RagdollController : MonoBehaviour
{

    public static GameObject cameraMan;
    public float velocity;

    public GameObject leftHand;
    public GameObject rightHand;

    private bool interacting = false;
    private Transform valve;


    private Rigidbody2D leftHandRb;
    private Rigidbody2D rightHandRb;

    float horizontalMove;

    private void OnEnable()
    {
        Debug.Log("ONENABLE");
        transform.parent = GameObject.Find("IndividualGame").transform;
    }

    private void OnMove(InputValue value)
    {
        horizontalMove = value.Get<float>();

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
        leftHandRb.AddForce(new Vector2(horizontalMove, 0) * velocity);
        rightHandRb.AddForce(new Vector2(horizontalMove, 0) * velocity);


        if (interacting && valve)
        {
            Actionable actionable = valve.GetComponent<Actionable>();
            //actionable.unitsPerSecond
            IndividualGameController individualGameController = GetComponentInParent<IndividualGameController>();

            switch (actionable.action)
            {
                case Actionable.ACTION.DRAIN:
                    individualGameController.waterLevelPercentage -= actionable.percentagePerSecond / Application.targetFrameRate;

                    break;
                case Actionable.ACTION.FILL:
                    individualGameController.waterLevelPercentage += actionable.percentagePerSecond / Application.targetFrameRate;

                    break;
            }
            transform.position = valve.position;
        }
    }

}
