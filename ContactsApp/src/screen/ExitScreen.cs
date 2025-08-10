using System;
using static Utilities;
using static Constants;

public class ExitScreen : BaseScreen {

    public override void Start() {
        this.ExecuteCommand();
        this.NextScreen = null;
    }

    protected override void ExecuteCommand() {}

    protected override void ShowScreen () {}
}