using System;

public static class Constants
{
    public static string DataFolder = "data";
    public static string PremierLeagueFile = "premier_league.csv";
    public static string WeeksStatsFolder = "weeks_stats";
    public static string WeekStatFile(int weekNumber) { return $"week_{weekNumber}.csv"; }
}