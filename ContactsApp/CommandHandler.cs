using System;
using static Utilities;
using static Constants;

public delegate void CommandHandlerDelegate();

public class CommandHandler
{
    private List<ContactInfo> _contactInfos;
    private Dictionary<CommandType, CommandHandlerDelegate> _commandMap;
    public CommandHandler()
    {
        _contactInfos = new List<ContactInfo>();

        _commandMap = new Dictionary<CommandType, CommandHandlerDelegate>
        {
            { CommandType.AddContact,    HandleAddContact },
            { CommandType.DeleteContact, HandleDeleteContact },
            { CommandType.EditContact,   HandleEditContact },
            { CommandType.SearchContact, HandleSearchContact }
        };
    }
    public void ReadCommand(List<ContactInfo> contactInfos, int commandNumber)
    {
        _contactInfos = contactInfos;
        CommandType commandType = (CommandType)commandNumber;

        // Check if the command exists in our map
        if (_commandMap.TryGetValue(commandType, out CommandHandlerDelegate? handler))
        {
            handler();
        }
        else
        {
            WE("Enter a valid command number.");
        }
    }

    private void HandleAddContact()
    {
        W("Enter a name: ");
        string name = RL();
        W("Enter a phone number: ");
        string phoneNumber = RL();
        _contactInfos.Add(new ContactInfo { Name = name, PhoneNumber = phoneNumber });
    }

    private int FindIndex(string name)
    {
        if (int.TryParse(name, out int contactNumber))
        {
            if (contactNumber < 0 || contactNumber > _contactInfos.Count)
            {
                WE("Index out of range");
                return -1;
            }
            return contactNumber - 1;
        }
        else
        {
            return _contactInfos.FindIndex(ci => ci.Name == name);
        }
    }

    private void HandleDeleteContact()
    {
        W("Enter contact's name or number you want to delete: ");
        string contactName = RL();
        int index = FindIndex(contactName);

        if (index == -1)
        {
            WE("Contact doesn't exist.");
            return;
        }

        _contactInfos.RemoveAt(index);
    }

    private void HandleEditContact()
    {
        W("Enter contact's name or number you want to edit: ");
        string contactName = RL();
        int index = FindIndex(contactName);

        if (index == -1)
        {
            WE("Contact doesn't exist.");
            return;
        }

        W("Enter a new name: ");
        string name = RL();
        _contactInfos[index].Name = name;
        W("Enter a new phone number: ");
        string phoneNumber = RL();
        _contactInfos[index].PhoneNumber = phoneNumber;
    }

    private void HandleSearchContact()
    {
        W("Enter contact's name or number you want to search for: ");
        string contactName = RL();
        int index = FindIndex(contactName);

        if (index == -1)
        {
            WE("Contact doesn't exist.");
            return;
        }

        WL("The contact's number you were looking for is " + _contactInfos[index].PhoneNumber);
    }
}