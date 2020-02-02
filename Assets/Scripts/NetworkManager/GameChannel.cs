
using System.Collections.Generic;
using Phoenix;
using UnityEngine;


public class GameChannel : MonoBehaviour
{
    private static Channel channel;

    public static void JoinGame()
    {
        string gameId = NetworkManager.game_id;
        channel = NetworkManager.socket.MakeChannel("game:" + gameId);

        channel.On("updated_game", UpdatedGame);
        channel.On("updated_countdown", UpdatedCountdown);
        channel.On("updated_player", UpdatedPlayer);
        channel.On("spawn_valve", SpawnValve);
        

        print("Joining game channel");
        Dictionary<string, object> param = new Dictionary<string, object> { { "id", NetworkManager.my_id } };
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


    private static void UpdatedGame(Message m)
    {
        Game g = m.payload.ToObject<Game>();
        GameManager.UpdateGame(g);
    }

    private static void UpdatedCountdown(Message m)
    {
        int count = (int)m.payload["count"];
        GameManager.UpdateCountdown(count);
    }

    private static void UpdatedPlayer(Message m)
    {
        Player p = m.payload.ToObject<Player>();
        GameManager.UpdatePlayer(p);
    }

    private static void SpawnValve(Message m)
    {
      Debug.Log("RECEIVED SPAWN");
      Debug.Log(m);
        ValveSpawn s = m.payload.ToObject<ValveSpawn>();
        IndividualGameController.spawnValve(s);
    }

    public static void SendUpdate(string transformation, int water_level)
    {
        channel.Push("update", new Dictionary<string, object> {
          { "transformation", transformation },
          { "water_level", water_level }
        });
    }

    public static void SendHittingValve(int type)
    {
        channel.Push("hitting_valve", new Dictionary<string, object> {{ "type", type }});
    }

    public static void SendReleaseValve(int type)
    {
        channel.Push("release_valve", new Dictionary<string, object> {{ "type", type }});
    }
}
