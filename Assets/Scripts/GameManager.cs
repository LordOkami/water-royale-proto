
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject camera;

    private static List<GameObject> players = new List<GameObject>();

    public static void RegisterPlayer(GameObject playerObject)
    {
        players.Add(playerObject);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void UpdateGame(Game _game)
    {
    }

    public static void UpdatePlayer(Player _player)
    {
    }

    public static void UpdateCountdown(int count)
    {
    }

}
