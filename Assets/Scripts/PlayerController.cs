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

    private void OnEnable()
    {
        controls = new Controls();
        controls.PlayerControls.Move.performed += ctx => {
            Debug.Log("INPUT RECEIVED");
            movementInput = ctx.ReadValue<Vector2>();
        };
        controls.PlayerControls.Fire.performed += ctx =>
        {
            Debug.Log("Fire");
        };
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void OnMove()
    {
        Debug.Log("Moving");
    }

    private void handleMove()
    {

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
