using System;
using static Constants;

public class ContactInfo
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string GetContactInfo()
    {
        return Name + AddSpaces(numofSpaces - Name!.Length) + this.PhoneNumber + AddSpaces(numofSpaces - PhoneNumber!.Length);
    }
}