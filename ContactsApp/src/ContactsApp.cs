using System;
using static Utilities;
using static Constants;
using System.Threading;
using System.Collections.Generic;

public class ContactsApp
{
    private Stack<BaseScreen> Screens { get; set; }

    public ContactsApp()
    {
        Screens = new Stack<BaseScreen>();
    }
    
    public void StartApp()
    {
        List<ContactInfo> contactInfos = new List<ContactInfo> { new ContactInfo { Name="A", PhoneNumber="1" }, new ContactInfo  { Name="B", PhoneNumber="2" } };
        CommandsScreen commandsScreen = new CommandsScreen(contactInfos);
        Screens.Push(commandsScreen);
        while (Screens.Count > 0)
        {
            BaseScreen currentScreen = Screens.Pop();
            currentScreen.Start();
            if (currentScreen.NextScreen != null) {
                Screens.Push(currentScreen.NextScreen);
            }
            Thread.Sleep(sleepTime);
            Console.Clear();
        }

        WL("\nClosing the program...\n");
        Thread.Sleep(sleepTime);
    }

}