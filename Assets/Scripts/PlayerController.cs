using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public float rotationForce;
    public Transform thrust;

    private Vector2 thrustPosition;

    private Rigidbody2D rigidBody;

    [SerializeField] private Controls controls;
    Vector2 movementInput;

    private void OnMove(InputValue value)
    {
        Debug.Log("Moving");
        movementInput = value.Get<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();
        thrustPosition = thrust.position;
        // thrustPosition = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 dirVector = transform.position - thrust.position;
        rigidBody.AddForce(dirVector.normalized * velocity * movementInput.y);
        rigidBody.AddTorque(-movementInput.x * rotationForce);
    }
}
