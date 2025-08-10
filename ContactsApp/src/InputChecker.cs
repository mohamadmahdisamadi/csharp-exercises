using System;
using static Utilities;
using static Constants;

public class InputChecker {
    public bool ValidateContactInfo(ContactInfo contactInfo) {
        return true;
    }

    public bool ValidateInputCommand(int commandNumber) {
        return Enum.IsDefined(typeof(CommandType), commandNumber);
    }

    public int ValidateContactExistance(List<ContactInfo> contactInfos, string contactName) {
        return this.FindIndex(contactInfos, contactName);
    }


    private int FindIndex(List<ContactInfo> contactInfos, string name)
    {
        if (int.TryParse(name, out int contactNumber))
        {
            if (contactNumber < 0 || contactNumber > contactInfos.Count)
            {
                WE("Index out of range");
                return -1;
            }
            return contactNumber - 1;
        }
        else
        {
            return contactInfos.FindIndex(ci => ci.Name == name);
        }
    }
}