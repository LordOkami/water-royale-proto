using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuServerLobby : MonoBehaviour
{
    public static List<LobbyGame> games = new List<LobbyGame>();
    public static LobbyGame game;
    public static bool updateGames;
    public static bool joinedGame;

    public GameObject list;
    public Button joinButton;
    public Button createButton;

    private GameObject selectedGame;
    private string selectedGameId;
    private ListCreator listCreator;

    public GameObject gameLobby;


    // Start is called before the first frame update
    void Start()
    {
        listCreator = list.GetComponent<ListCreator>();

        createButton.onClick.AddListener(() => {
            LobbyChannel.SendCreateGame();
        });
        joinButton.onClick.AddListener(() => {
            LobbyChannel.SendJoinGame(selectedGameId);
        });
    }

    void Update()
    {
        if (updateGames)
        {
            updateGames = false;
            listCreator.UpdateGameList(games, this);
        }
        if (joinedGame)
        {
            joinedGame = false;
            gameObject.SetActive(false);
            gameLobby.SetActive(true);
        }
    }

    public void SetSelectedGame(GameObject game, string game_id)
    {
        if( selectedGame == game)
        {
            joinButton.interactable = false;
            selectedGame.GetComponent<Image>().color = new Color32(255, 255, 255, 145);
            selectedGame = null;
            selectedGameId = null;
            return;
        }
        if (selectedGame != null)
        {
            selectedGame.GetComponent<Image>().color = new Color32(255, 255, 255, 145);
        }
        selectedGame = game;
        selectedGameId = game_id;
        selectedGame.GetComponent<Image>().color = new Color32(240, 240, 80, 145);
        joinButton.interactable = true;
    }

    public static void SetGames(List<LobbyGame> _games)
    {
        games = _games;
        updateGames = true;
    }

    public static void NewGame(LobbyGame _game)
    {
        games.Add(_game);
        updateGames = true;
    }

    private static int GetGameIndex(string game_id)
    {
        for (int i = 0; i < games.Count; i++)
        {
            if (games[i].id == game_id)
                return i;
        }
        return -1;
    }

    public static void UpdateGame(LobbyGame _game)
    {
        int idx = GetGameIndex(_game.id);
        if(idx >= 0)
        {
            if (_game.players.Count == 0)
            {
                games.RemoveAt(idx);
            }
            else
            {
                games[idx] = _game;
            }
            updateGames = true;
        }
    }

    public static void RemoveGame(string game_id)
    {
        int idx = GetGameIndex(game_id);
        if (idx >= 0)
        {
            games.RemoveAt(idx);
            updateGames = true;
        }
    }

    
}
