using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject camera;

    public FollowBehaviour follow;


    private static List<Transform> players = new List<Transform>();
    

    public static void RegisterPlayer(Transform t)
    {
        players.Add(t);
    }

    void Start()
    {
        follow = camera.GetComponent<FollowBehaviour>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (follow.player == null && players.Count > 0)
        {
            follow.player = players[0];
        }
    }
}
