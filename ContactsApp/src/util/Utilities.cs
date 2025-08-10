using System;

public static class Utilities
{
    public static readonly Action<string> WL = (message) => Console.WriteLine(message);
    public static readonly Action<string> W = (message) => Console.Write(message);
    public static readonly Action<string> WE = (message) => Console.WriteLine("[Error]: " + message);
    public static readonly Action NL = () => Console.WriteLine();
    public static readonly Action<int> NLS = (count) => { for (int i = 0; i < count; i++) NL(); };
    public static readonly Func<string> RL = () => Console.ReadLine()!;
}

public enum CommandType
{
    AddContact = 1,
    DeleteContact,
    EditContact,
    ShowContacts,
    ExitProgram,
    
    ShowCommands
}