using System;
using static Utilities;
using static Constants;

public class EditContactScreen : BaseScreen {

    public EditContactScreen(List<ContactInfo> newContactInfos) {
        ContactInfos = newContactInfos;
        Init();
    }

    public override void Start() {
        this.ExecuteCommand();
        this.DetermineNextScreen();
    }

    protected override void ShowScreen () {}

    protected override void ExecuteCommand() {
        string contactName = this.InputGetter.GetEditContactInput();

        int contactIndex = InputChecker.ValidateContactExistance(ContactInfos, contactName);
        if (contactIndex != -1) {
            ContactInfo newContactInfo = this.InputGetter.GetAddContactInput();
            if (InputChecker.ValidateContactInfo(newContactInfo)) {
                ContactInfos[contactIndex] = (newContactInfo);
            } else {
                WE("Did not add contact duo to invalid input.");
            }
        } else {
            WE("User did not found.");
        }
    }
}