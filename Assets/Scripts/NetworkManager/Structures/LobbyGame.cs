using System.Collections.Generic;
public class LobbyGame
{
    public string id { get; set; }
    public string name { get; set; }
    public List<LobbyPlayer> players { get; set; }
    public bool all_ready { get; set; }
}
