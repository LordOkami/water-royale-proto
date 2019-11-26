using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody))]
public class GravityBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsTrue(GetComponent<Rigidbody2D>());
    }

    private void FixedUpdate()
    {
        foreach (Attractor att in Attractor.attractors)
        {
            att.Attract(gameObject);
        }
    }
}
