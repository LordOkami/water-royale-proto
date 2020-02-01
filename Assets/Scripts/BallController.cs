using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class BallController : MonoBehaviour
{

    public static GameObject cameraMan;
    public float velocity;

    private bool interacting = false;
    private Transform valve;


    private Rigidbody2D rigidBody;
    float horizontalMove;

    private void OnEnable()
    {
        Debug.Log("ONENABLE");
        GameManager.RegisterPlayer(this.gameObject);
        transform.parent = GameObject.Find("IndividualGame").transform;
    }

    private void OnMove(InputValue value)
    {
        horizontalMove = value.Get<float>();

    }


    private void OnInteract(InputValue value)
    {
        interacting=value.isPressed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.name == "Water") return;
      valve = collision.transform;
    }
    void OnTriggerExit2D(Collider2D c) {
      valve= null;
    }
    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        rigidBody.AddForce(new Vector2(horizontalMove, 0) * velocity);
        if(interacting && valve){
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
