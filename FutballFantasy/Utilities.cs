using System;

public static class Utilities
{
    public static readonly Action<string> WL = (message) => Console.WriteLine(message);
    public static readonly Action<string> W = (message) => Console.Write(message);
    public static readonly Action NL = () => Console.WriteLine();
}