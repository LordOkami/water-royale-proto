using System.Collections.Generic;
public class Game
{
    public string id { get; set; }
    public List<LobbyPlayer> lobby_players { get; set; }
    public List<Player> players { get; set; }
}
