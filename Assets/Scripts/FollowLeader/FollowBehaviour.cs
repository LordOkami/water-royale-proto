using UnityEngine;

public class FollowBehaviour : MonoBehaviour
{
    public Transform player;
    public float zIndex = -6;
    public Vector3 offset = new Vector3(0, 0, 0);
    public float speed = 1.0f;

    void FixedUpdate()
    {
        if (player != null)
        {
            //Rigidbody2D playerRigidBody = player.GetComponent < Rigidbody2D>();
            float distance = (player.position - transform.position).magnitude;
            Vector3 lerp = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * speed * (1 / distance));
            transform.position = new Vector3(lerp.x, lerp.y, zIndex);
        }
    }
}
