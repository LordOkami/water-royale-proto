using System.Text;
using Phoenix;
using HybridWebSocket;

public sealed class WebsocketSharpAdapter : IWebsocket
{

    private readonly WebSocket ws;
    private readonly WebsocketConfiguration config;


    public WebsocketSharpAdapter(WebSocket ws, WebsocketConfiguration config)
    {

        this.ws = ws;
        this.config = config;

        ws.OnOpen += OnWebsocketOpen;
        ws.OnClose += OnWebsocketClose;
        ws.OnError += OnWebsocketError;
        ws.OnMessage += OnWebsocketMessage;
    }


    #region IWebsocket methods

    public void Connect()
    {
        ws.Connect();
    }

    public void Send(string msg)
    {
        ws.Send(Encoding.UTF8.GetBytes(msg));
    }

    public void Close(ushort? code = null, string message = null)
    {
        ws.Close();
    }

    #endregion


    #region websocketsharp callbacks

    public void OnWebsocketOpen()
    {
        config.onOpenCallback(this);
    }

    public void OnWebsocketClose(WebSocketCloseCode code)
    {
        config.onCloseCallback(this, (ushort)code, "");
    }

    public void OnWebsocketError(string message)
    {
        config.onErrorCallback(this, message);
    }

    public void OnWebsocketMessage(string msg)
    {
        config.onMessageCallback(this, msg);
    }

    #endregion
}