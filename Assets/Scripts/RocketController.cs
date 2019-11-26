using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketController : MonoBehaviour
{

    public static GameObject cameraMan;
    public float velocity;
    public float rotationForce;
    public Transform thrust;



    private Rigidbody2D rigidBody;

    Vector2 leftInput, rightInput;

    private void OnEnable()
    {
        GameManager.RegisterPlayer(this.gameObject);
    }

    private void OnRocketRight(InputValue value)
    {
        float v = value.Get<float>();
        rightInput = new Vector2(-v, v);
    }
    private void OnRocketLeft(InputValue value)
    {
        float v = value.Get<float>();
        leftInput = new Vector2(v, v);
    }
    private void OnReset()
    {
        if (rigidBody != null)
        {
            transform.position = new Vector2(0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rigidBody.velocity = new Vector2(0, 0);
        }
    }


    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Vector2 movementInput = (rightInput + leftInput) / 2;
        Vector2 dirVector = transform.position - thrust.position;
        rigidBody.AddForce(dirVector.normalized * velocity * movementInput.y);
        rigidBody.AddTorque(-movementInput.x * rotationForce);
    }

}
