using System;

public enum PlayerPosition { GK = 1, DF, MD, FW }

public static class Utilities
{
    public static readonly Action<string> WL = (message) => Console.WriteLine(message);
    public static readonly Action<string> W = (message) => Console.Write(message);
    public static readonly Action<string> WE = (message) => Console.WriteLine("[Error]: " + message);
    public static readonly Action NL = () => Console.WriteLine();
}