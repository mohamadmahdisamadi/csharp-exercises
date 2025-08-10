using System;
using static Utilities;
using static Constants;

public class CommandsScreen : BaseScreen { 
    public CommandsScreen(List<ContactInfo> newContactInfos) {
        ContactInfos = newContactInfos;
        Init();
    }

    public override void Start() {
        this.ShowScreen();
        this.ExecuteCommand();
    }

    protected override void ShowScreen()
    {
        WL(horzLine('-'));
        string[] commands = {
                            "~ List of commands ~",
                            "Add Contact    (1)",
                            "Delete Contact (2)",
                            "Edit Contact   (3)",
                            "Show Contacts  (4)",
                            "Exit           (5)"
        };

        for (int i=0; i<commands.Length; i++) {
            int emptySpaceLength = 3 * numofSpaces - commands[i].Length;
            commands[i] = AddSpaces((int)(emptySpaceLength / 2)) + commands[i];
        }

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

    protected override void ExecuteCommand() {
        int commandNumber = InputGetter.GetCommandInput();
        if (!InputChecker.ValidateInputCommand(commandNumber)) {
            this.NextScreen = new CommandsScreen(ContactInfos);
            WE("Command number does not exist.");
            return;
        } else {
            this.DetermineNextScreen(((CommandType)commandNumber));
        }
    }
}