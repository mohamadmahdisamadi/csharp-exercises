using System;
using static Utilities;
using static Constants;

public class AddContactScreen : BaseScreen {

    public AddContactScreen(List<ContactInfo> newContactInfos) {
        ContactInfos = newContactInfos;
        Init();
    }

    public override void Start() {
        this.ExecuteCommand();
        this.DetermineNextScreen();
    }

    protected override void ShowScreen () {}

    protected override void ExecuteCommand() {
        ContactInfo newContactInfo = this.InputGetter.GetAddContactInput();

        if (InputChecker.ValidateContactInfo(newContactInfo)) {
            ContactInfos.Add(newContactInfo);
        } else {
            WE("Did not add contact duo to invalid input.");
        }
    }
}