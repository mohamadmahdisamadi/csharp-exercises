using System;
using static Utilities;
using static Constants;

public class DeleteContactScreen : BaseScreen {

    public DeleteContactScreen(List<ContactInfo> newContactInfos) {
        ContactInfos = newContactInfos;
        Init();
    }

    public override void Start() {
        this.ExecuteCommand();
        this.DetermineNextScreen();
    }

    protected override void ShowScreen () {}

    protected override void ExecuteCommand() {
        string contactName = this.InputGetter.GetDeleteContactInput();

        int contactIndex = InputChecker.ValidateContactExistance(ContactInfos, contactName);
        if (contactIndex != -1) {
            ContactInfos.RemoveAt(contactIndex);
        } else {
            WE("User did not found.");
        }
    }
}