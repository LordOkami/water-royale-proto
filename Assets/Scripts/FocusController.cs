using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusController : MonoBehaviour
{

    Rigidbody2D rigidBody;
    public Vector3 angularSpeed = new Vector3(0,0,0.05f);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        // TODO FIX WITH DELTA TIME
        transform.eulerAngles += angularSpeed * 1 / Time.deltaTime;

    }
}
