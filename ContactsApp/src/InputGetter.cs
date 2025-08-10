using System;
using static Utilities;
using static Constants;

public class InputGetter {
    public ContactInfo GetAddContactInput() {
        W("Enter a name: ");
        string name = RL();
        W("Enter a phone number: ");
        string phoneNumber = RL();
        return new ContactInfo { Name = name, PhoneNumber = phoneNumber };
    }

    public string GetDeleteContactInput() {
        W("Enter contact's name or index you want to delete: ");
        string contactName = RL();
        return contactName;
    }

    public string GetEditContactInput() {
        W("Enter contact's name or number you want to edit: ");
        string contactName = RL();
        return contactName;
    }

    public int GetCommandInput()
    {
        W("Enter a command number: ");
        string? commandNumberString = Console.ReadLine();
        if (int.TryParse(commandNumberString, out int commandNumber))
        {
            return commandNumber;
        }
        else
        {
            WE("Please enter a number.");
            return -1;
        }
    }
}