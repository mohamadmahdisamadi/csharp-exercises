using System;
using System.Dynamic;
using System.Security;
using static Utilities;

public abstract class Team
{
    public List<Player> Players { get; set; } = new List<Player>();
    public string? TeamName { get; init; } = string.Empty;
    // public List<Player> Players { get; set; }

    public void DisplayTeamInfo()
    {
        WL($"Name of the team: {TeamName}");
        foreach (Player p in Players)
        {
            WL(p.DisplayPlayerInfo());
        }
        NL();
    }
}
