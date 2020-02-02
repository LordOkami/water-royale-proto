using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class chirridoScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public float oldAngularSpeed;
    void Start()
    {
        audioSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float angularSpeed = this.GetComponent<Rigidbody2D>().angularVelocity;

        if(oldAngularSpeed * angularSpeed < 0)
        {
            audioSource.volume = 0.3f;
            audioSource.Play();
        }

        if (audioSource.volume > 0) audioSource.volume = audioSource.volume - 0.1f;
        oldAngularSpeed = angularSpeed;
    }
}
