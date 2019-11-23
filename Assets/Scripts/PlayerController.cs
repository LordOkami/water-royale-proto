using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float velocity;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce(movementInput * velocity);
    }
}
