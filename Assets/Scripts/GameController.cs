using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public GameObject camera;

    public FollowBehaviour follow;

    private int totalPlayers = 0;


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
        if (players.Count != totalPlayers)
        {
            int nextPlayer = Random.Range(0, players.Count);
            follow.player = players[nextPlayer];

            totalPlayers = players.Count;
        }
    }
}
