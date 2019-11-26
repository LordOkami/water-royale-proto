
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject camera;

    public GameObject focusStar;

    public FollowBehaviour follow;
    public FollowBehaviour followStar;

    private int totalPlayers = 0;


    private static List<GameObject> players = new List<GameObject>();

    private double lastLeadershipChange;

    private GameObject focusedPlayer;

    public static void RegisterPlayer(GameObject playerObject)
    {
        players.Add(playerObject);
    }

    void Start()
    {
        follow = camera.GetComponent<FollowBehaviour>();

        followStar = focusStar.GetComponent<FollowBehaviour>();


    }

    // Update is called once per frame
    void Update()
    {
        if (players.Count != totalPlayers)
        {
            GameObject nextPlayer = players[Random.Range(0, players.Count)];
            updateFocusedPlayer(nextPlayer);
            totalPlayers = players.Count;
        }
    }

    private void updateFocusedPlayer(GameObject nextPlayer)
    {
        double now = (new System.TimeSpan(System.DateTime.Now.Ticks)).TotalMilliseconds;
        if (focusedPlayer != null && now - lastLeadershipChange < 1000)
        {
            return;
        }
        Debug.Log("PASSING LEADER");

        lastLeadershipChange = now;

        removeLeadership(focusedPlayer);

        focusedPlayer = nextPlayer;
        follow.player = focusedPlayer.transform;
        followStar.player = focusedPlayer.transform;

        addLeadership(focusedPlayer);
    }

    public void addLeadership(GameObject player)
    {

        LeaderBehaviour pb = player.AddComponent<LeaderBehaviour>() as LeaderBehaviour;
        pb.gameManager = this;

    }

    public void removeLeadership(GameObject player)
    {
        if (player != null)
        {
            Destroy(player.GetComponent<LeaderBehaviour>());
        }
    }

    public void OnLeaderCollide(Collision2D collision)
    {
        updateFocusedPlayer(collision.gameObject);
    }
}
