using System;
using Phoenix;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    public static Socket socket;
    public static string my_id;
    public static string my_username;
    public static string game_id;
    public static string my_target;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static void Connect(string host, string username, bool toggleWss)
    {
        print(string.Format("Connecting to server: {0} ...", host));

        WebsocketSharpFactory socketFactory = new WebsocketSharpFactory();
        socket = new Socket(socketFactory, new Socket.Options
        {
            channelRejoinInterval = TimeSpan.FromMilliseconds(200),
            //logger = new BasicLogger()
        });

        socket.OnOpen = () => {
            LobbyChannel.JoinLobby(username);
        };
        socket.OnError = (x) => {
            MenuServerConnect.joinError = "error_connecting";
            MenuServerConnect.connectedSuccessfully = false;
            MenuServerConnect.connectionDone = true;
        };
        string socketUrlBase = "ws://{0}/socket";
        
        if(toggleWss) {
          socketUrlBase = "wss://{0}/socket";
        }
        socket.Connect(string.Format(socketUrlBase, host), null);
    }

}