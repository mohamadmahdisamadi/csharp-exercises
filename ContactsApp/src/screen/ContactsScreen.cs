using System;
using static Utilities;
using static Constants;

public class ContactsScreen : BaseScreen {

    public ContactsScreen(List<ContactInfo> newContactInfos) {
        ContactInfos = newContactInfos;
        Init();
    }

    protected override void ExecuteCommand() {}
    

    public override void Start() {
        this.ShowScreen();
        this.DetermineNextScreen();
    }

    protected override void ShowScreen() {
        ShowHeader();
        ShowContacts();
    }

    private void ShowContacts()
    {
        for (int i = 0; i < ContactInfos.Count; i++)
        {
            int index = i + 1;
            string contactInfo = vertLine + $"{index}." + AddSpaces(numofSpaces - (i.ToString().Length + 1));
            contactInfo += ContactInfos[i].GetContactInfo();
            contactInfo += vertLine;
            WL(contactInfo);
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
}