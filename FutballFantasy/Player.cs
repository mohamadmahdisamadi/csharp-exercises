using System;
using static Utilities;

public class Player
{
    public string? PlayerName { get; init; }
    public PlayerPosition PlayerPosition { get; init; }

    public string DisplayPlayerInfo()
    {
        return $"{PlayerName} ({PlayerPosition})";
    }
}