using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{

    public static GameObject cameraMan;
    public float velocity;

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

    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        rigidBody.AddForce(new Vector2(horizontalMove, 0) * velocity);
    }

}
