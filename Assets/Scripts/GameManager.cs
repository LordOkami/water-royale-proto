
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject camera;

    public GameObject waitingUI;
    public GameObject countdownUI;
    // public TextMeshProUGUI countdownUIText;
    public GameObject gameUI;
    public string gameState = "waiting";

    public GameObject playersList;
    private static List<Player> otherPlayers;
    private static bool updatePlayers;

    private static Queue<Player> playerToUpdate = new Queue<Player>();

    private static int countdown=5;
    private static bool updateCountdown;


    public GameObject loseUI;
    public GameObject winUI;

    private static bool updateLose;
    private static bool updateWin;

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
        if (updateCountdown)
        {
            updateCountdown = false;
            if (countdown == 0)
            {
                // countdownUI.SetActive(false);
                // gameUI.SetActive(true);
            }
            else
            {
                // countdownUIText.text = countdown + "";
                if (gameState == "waiting")
                {
                    gameState = "counting";
                    // waitingUI.SetActive(false);
                    // countdownUI.SetActive(true);
                }
            }
        }
        if (updatePlayers)
        {
            updatePlayers = false;
            // listCreator.UpdateList(otherPlayers);
        }
        // if (playerToUpdate.Count > 0)
        // {
        //     listCreator.UpdatePlayer(playerToUpdate.Dequeue());
        // }

        // if (updateLose)
        // {
        //     updateLose = false;
        //     loseUI.SetActive(true);
        // }
        // if (updateWin)
        // {
        //     updateWin = false;
        //     winUI.SetActive(true);
        // }
    }

    public static void UpdateGame(Game _game)
    {
        //game = _game;
        //updateGame = true;
        otherPlayers = new List<Player>();
        foreach (Player p in _game.players)
        {
            if(p.id == NetworkManager.my_id)
            {
                // UpdateStats.UpdatePlayer(p);
                NetworkManager.my_target = p.target;
                NetworkManager.my_player = p;
            }
            else
            {
                otherPlayers.Add(p);
            }

            if(p.target == NetworkManager.my_id)
            {
                NetworkManager.my_attacker = p.id;
            }
        }
        updatePlayers = true;
    }

    public static void UpdatePlayer(Player _player)
    {
        if (_player.id == NetworkManager.my_id)
        {
            // UpdateStats.UpdatePlayer(_player);
            NetworkManager.my_target = _player.target;
            NetworkManager.my_player = _player;
            // if (_player.life == 0)
            // {
            //     updateLose = true;
            // }
            if (_player.target == NetworkManager.my_id && otherPlayers.Count > 1)
            {
                updateWin = true;
            }
        }
        else
        {
            playerToUpdate.Enqueue(_player);
        }

        if(_player.id == NetworkManager.my_target)
        {
            NetworkManager.my_target_player = _player;
        }

        if (_player.id == NetworkManager.my_attacker)
        {
            NetworkManager.my_attacker_player = _player;
        }
    }

    public static void UpdateCountdown(int count)
    {
        countdown = count;
        updateCountdown = true;
    }

}
