﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPipeBehaviour : MonoBehaviour
{
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IndividualGameController.action == 1)
        {
            particles.SetActive(true);
        }
        else 
        {
            particles.SetActive(false);
        }
    }
}
