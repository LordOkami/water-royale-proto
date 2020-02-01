using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float mass;
    public float G;
    public float D;

    public static List<Attractor> attractors;

    private void OnEnable()
    {
        if(attractors == null)
        {
            attractors = new List<Attractor>();
        }

        attractors.Add(this);

    }


    public void Attract(GameObject obj)
    {
        Vector2 dir = transform.position - obj.transform.position;
        float distance = dir.magnitude;

        float forceMagnitude = G * mass / Mathf.Pow(distance * D, 2);
        Vector2 force = dir.normalized * forceMagnitude;

        obj.GetComponent<Rigidbody2D>().AddForce(force);
    }
}
