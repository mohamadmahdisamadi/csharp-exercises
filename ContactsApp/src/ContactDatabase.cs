using System;
using static Utilities;
using static Constants;

public class ContactDatabase
{
    public List<ContactInfo> _contactInfos { get; }
    public ContactDatabase()
    {
        _contactInfos = new List<ContactInfo>();
    }

    public void AddContact()
    {
        W("Enter a name: ");
        string name = RL();
        W("Enter a phone number: ");
        string phoneNumber = RL();
        _contactInfos.Add(new ContactInfo { Name = name, PhoneNumber = phoneNumber });
    }

    public void DeleteContact()
    {

    }

    public void EditContact()
    {

    }

    public void SearchContact()
    {

    }

    public string DisplayContactInfo(int contactIndex)
    {
        return _contactInfos[contactIndex].GetContactInfo();
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
}
