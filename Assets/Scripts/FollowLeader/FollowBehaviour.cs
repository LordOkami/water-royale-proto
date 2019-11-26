using UnityEngine;

public class FollowBehaviour : MonoBehaviour
{
    public Transform player;
    public float zIndex = -6;
    public Vector3 offset = new Vector3(1, 1, 0);
    public float speed = 1.0f;

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 lerp = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * speed);
            transform.position = new Vector3(lerp.x, lerp.y, zIndex);
        }
    }
}
