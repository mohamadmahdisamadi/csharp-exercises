using System;
using static Utilities;
using static Constants;
using System.Threading;

public class ContactsApp
{
    private List<ContactInfo> _contactInfos;
    private CommandHandler _commandHandler;
    private bool AppIsOpen { get; set; }
    public ContactsApp()
    {
        AppIsOpen = true;
        _commandHandler = new CommandHandler();
        _contactInfos = new List<ContactInfo> { };
    }
    public void StartApp()
    {
        while (AppIsOpen)
        {
            ShowHeader();
            ShowContacts();
            ShowMenu();
            RecieveCommand();
            NLS(3); WL(horzLine('~')); NLS(3);
            Thread.Sleep(sleepTime);
        }
        WL("\nClosing the program...\n");
    }

    private void RecieveCommand()
    {
        W("Enter a command number: ");
        string? commandNumberString = Console.ReadLine();
        if (int.TryParse(commandNumberString, out int commanNumber))
        {
            if ((CommandType)commanNumber == CommandType.ExitProgram)
            {
                AppIsOpen = false;
            }
            else
            {
                _commandHandler.ReadCommand(_contactInfos, commanNumber);
            }
        }
        else
        {
            WE("Please enter a number.");
        }
    }

    private void ShowContacts()
    {
        for (int i = 0; i < this._contactInfos.Count; i++)
        {
            int index = i + 1;
            string message = vertLine + $"{index}." + AddSpaces(numofSpaces - (i.ToString().Length + 1));
            message += _contactInfos[i].DisplayContactInfo();
            message += vertLine;
            WL(message);
        }
        WL(horzLine());
        NL();
    }

    private void ShowHeader()
    {
        WL(horzLine());
        W(vertLine);
        W("#");
        W(AddSpaces(numofSpaces - "#".Length));
        W(Name);
        W(AddSpaces(numofSpaces - Name.Length));
        W(PhoneNumber);
        W(AddSpaces(numofSpaces - PhoneNumber.Length));
        WL(vertLine);
        WL(horzLine());
    }

    private void ShowMenu()
    {
        WL(horzLine('-'));
        string[] commands = {
                            "List of commands:",
                            "Add Contact    (1)",
                            "Delete Contact (2)",
                            "Edit Contact   (3)",
                            "Search Contact (4)",
                            "Exit           (5)"
        };

        foreach (string command in commands)
        {
            W(vertLine);
            W(command);
            W(AddSpaces((numofSpaces * 3) - command.Length));
            WL(vertLine);
        }

        WL(horzLine('-'));
        NL();
    }

}