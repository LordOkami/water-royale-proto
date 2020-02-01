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
        GameManager.RegisterPlayer(this.gameObject);
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
      Debug.Log("OUT!");
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
          transform.position = valve.position;
        }
    }

}
