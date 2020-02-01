using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuGameLobby : MonoBehaviour
{

    public static LobbyGame game;
    public static bool leftGame;

    public GameObject serverLobby;
    public GameObject gameName;
    public GameObject list;

    public Button startButton;
    public Button readyButton;
    public Button leaveButton;

    private PlayerListCreator listCreator;
    private static bool updateGame;
    public static bool startGame;


    // Start is called before the first frame update
    void Start()
    {
        listCreator = list.GetComponent<PlayerListCreator>();

        leaveButton.onClick.AddListener(() => {
            LobbyChannel.SendLeaveGame(game.id);
        });
        readyButton.onClick.AddListener(() => {
            LobbyChannel.SendReadyGame(game.id);
        });
        startButton.onClick.AddListener(() => {
            LobbyChannel.SendStartGame(game.id);
        });
    }

    private void Update()
    {
        if (updateGame)
        {
            updateGame = false;
            gameName.GetComponent<TextMeshProUGUI>().SetText(game.name);
            listCreator.UpdateList(game.players);
            startButton.interactable = game.all_ready;
        }

        if (leftGame)
        {
            leftGame = false;
            gameObject.SetActive(false);
            serverLobby.SetActive(true);
        }

        if (startGame)
        {
            startGame = false;
            SceneManager.LoadScene(1);
        }
    }

    public static void UpdateGame(LobbyGame _game)
    {
        game = _game;
        updateGame = true;
    }
    public static void UpdateGameIfActive(LobbyGame _game)
    {
        if (game != null && game.id != _game.id) return;

        game = _game;
        updateGame = true;
    }
    

}
