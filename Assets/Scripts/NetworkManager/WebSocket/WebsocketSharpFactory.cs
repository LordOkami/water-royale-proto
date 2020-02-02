using Phoenix;
using HybridWebSocket;

public sealed class WebsocketSharpFactory : IWebsocketFactory
{

    public IWebsocket Build(WebsocketConfiguration config)
    {
        var socket = WebSocketFactory.CreateInstance(config.uri.AbsoluteUri);
        return new WebsocketSharpAdapter(socket, config);
    }
}
