using System;
using static Constants;
using static Utilities;

public class FutballFantasyApp
{
    CsvLoader csvLoader = new CsvLoader();
    List<Player> _players;
    List<LeagueTeam> _leagueTeams;
    public FutballFantasyApp()
    {
        _players = new List<Player>();
        _leagueTeams = new List<LeagueTeam>();
    }
    
    public void StartApp()
    {
        Init();
        while (true)
        {
            
        }
    }

    private void Init()
    {
        LoadLeagueInfo();        
    }

    private void LoadLeagueInfo()
    {
        List<List<string>> lines = csvLoader.LoadFile(PremierLeagueFile);

        foreach (List<string> teamInfo in lines)
        {
            _leagueTeams.Add(CreateLeagueTeam(teamInfo));
        }
    }

    private LeagueTeam CreateLeagueTeam(List<string> teamInfo)
    {
        LeagueTeam leagueTeam = new LeagueTeam { TeamName = teamInfo[0] };
        var allPositions = Enum.GetValues(typeof(PlayerPosition));
        foreach (PlayerPosition position in allPositions)
        {
            foreach (string playerName in teamInfo[(int)position].Split(';').ToList())
            {
                leagueTeam.Players.Add(new Player { PlayerName = playerName, PlayerPosition = position });
            }
        }
        return leagueTeam;
    }
}