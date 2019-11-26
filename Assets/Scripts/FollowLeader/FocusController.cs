using UnityEngine;

public class FocusController : MonoBehaviour
{

    public Vector3 angularSpeed = new Vector3(0,0,0.05f);

    private void FixedUpdate()
    {
        transform.eulerAngles += angularSpeed * 1 / Time.deltaTime;
    }
}
