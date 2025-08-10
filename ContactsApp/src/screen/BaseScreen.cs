using System;
using static Utilities;
using static Constants;
 
public abstract class BaseScreen
{
    protected InputGetter InputGetter { get; set; } = new InputGetter();
    protected InputChecker InputChecker { get; set; } = new InputChecker();
    protected List<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();
    public BaseScreen? NextScreen { get; set; }

    public abstract void Start();
    protected abstract void ShowScreen();
    protected abstract void ExecuteCommand();

    protected void Init() {
        InputGetter = new InputGetter();
        InputChecker = new InputChecker();
    }

    protected void DetermineNextScreen(CommandType command = CommandType.ShowCommands) {
        switch (command) {
            case CommandType.ShowCommands:
                this.NextScreen = new CommandsScreen(ContactInfos);
                break;
                
            case CommandType.AddContact:
                this.NextScreen = new AddContactScreen(ContactInfos);
                break;

            case CommandType.DeleteContact:
                this.NextScreen = new DeleteContactScreen(ContactInfos);
                break;
    
            case CommandType.EditContact:
                this.NextScreen = new EditContactScreen(ContactInfos);
                break;

            case CommandType.ExitProgram:
                this.NextScreen = new ExitScreen();
                break;
    
            case CommandType.ShowContacts:
                this.NextScreen = new ContactsScreen(ContactInfos);
                break;
        }
    }

}