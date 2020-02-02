
using System.Collections.Generic;
using Phoenix;
using UnityEngine;


public class LobbyChannel : MonoBehaviour
{
    private static Channel channel;

    public static void JoinLobby(string username)
    {
        channel = NetworkManager.socket.MakeChannel("server:lobby");

        channel.On("after_join_lobby", AfterJoin);
        channel.On("new_game_lobby", NewGame);
        channel.On("joined_game_lobby", JoinedGame);
        channel.On("updated_game_lobby", UpdatedGame);
        channel.On("left_game_lobby", LeftGame);
        channel.On("starting_game", StartingGame);

        print("Joining channel server:lobby");
        Dictionary<string, object> param = new Dictionary<string, object> { { "username", username } };
        channel.Join(param)
            .Receive(Reply.Status.Ok, r => {
                MenuServerConnect.connectedSuccessfully = true;
                MenuServerConnect.connectionDone = true;
            })
            .Receive(Reply.Status.Error, r => {
                MenuServerConnect.joinError = (string)r.response["reason"];
                MenuServerConnect.connectedSuccessfully = false;
                MenuServerConnect.connectionDone = true;
            });
    }

    private static void AfterJoin(Message m)
    {
        print("Received: after_join_lobby");

        MenuServerLobby.SetGames(m.payload["games"].ToObject<List<LobbyGame>>());
        NetworkManager.my_id = (string)m.payload["player"]["id"];
        NetworkManager.my_username = (string)m.payload["player"]["username"];
        MenuServerConnect.serverLobbyLoaded = true;
    }

    private static void NewGame(Message m)
    {
        print("Received: new_game_lobby");

        MenuServerLobby.NewGame(m.payload["game"].ToObject<LobbyGame>());
    }

    private static void JoinedGame(Message m)
    {
        print("Received: joined_game_lobby");

        LobbyGame g = m.payload["game"].ToObject<LobbyGame>();
        MenuServerLobby.UpdateGame(g);
        MenuGameLobby.UpdateGameIfActive(g);

        if (m.payload["player"].ToObject<LobbyPlayer>().id == NetworkManager.my_id)
        {
            NetworkManager.game_id = g.id;
            MenuGameLobby.UpdateGame(g);
            MenuServerLobby.joinedGame = true;
        }
    }

    private static void UpdatedGame(Message m)
    {
        print("Received: updated_game_lobby");

        LobbyGame g = m.payload["game"].ToObject<LobbyGame>();
        MenuServerLobby.UpdateGame(g);
        MenuGameLobby.UpdateGameIfActive(g);
    }

    private static void LeftGame(Message m)
    {
        print("Received: left_game_lobby");

        LobbyGame g = m.payload["game"].ToObject<LobbyGame>();
        MenuServerLobby.UpdateGame(g);
        MenuGameLobby.UpdateGameIfActive(g);

        if (m.payload["player"].ToObject<LobbyPlayer>().id == NetworkManager.my_id)
        {
            MenuGameLobby.leftGame = true;
        }
    }

    private static void StartingGame(Message m)
    {
        print("Received: starting_game");

        string game_id = (string)m.payload["game_id"];
        MenuServerLobby.RemoveGame(game_id);

        if (game_id == NetworkManager.game_id)
        {
            channel.Leave();
            MenuGameLobby.startGame = true;
            GameChannel.JoinGame();
        }
    }


    public static void SendCreateGame()
    {
        channel.Push("create_game");
    }

    public static void SendJoinGame(string game_id)
    {
        channel.Push("join_game", new Dictionary<string, object> { { "id", game_id } });
    }

    public static void SendLeaveGame(string game_id)
    {
        channel.Push("leave_game", new Dictionary<string, object> { { "id", game_id } });
    }

    public static void SendReadyGame(string game_id)
    {
        channel.Push("ready_game", new Dictionary<string, object> { { "id", game_id } });
    }

    public static void SendStartGame(string game_id)
    {
        channel.Push("start_game", new Dictionary<string, object> { { "id", game_id } });
    }


}
