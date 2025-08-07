using System;

/*
    A system to display user information by carefully checking possible null values.
*/
public class Program
{
    static void Main()
    {
        List<User> users = new List<User>();
        int id = 1;
        users.Add(new User { ID = id++, Profile = null });
        users.Add(new User { ID = id++, Profile = new UserProfile { Bio = null, WebsiteURL = null } });
        users.Add(new User { ID = id++, Profile = new UserProfile { Bio = "Daryl Dixon", WebsiteURL = null } });
        users.Add(new User { ID = id++, Profile = new UserProfile { Bio = null, WebsiteURL = "www.daryldixon.com" } });
        users.Add(new User { ID = id++, Profile = new UserProfile { Bio = "Daryl Dixon", WebsiteURL = "www.daryldixon.com" } });

        foreach (var u in users) { DisplayUserInfo(u); }
    }

    private static void DisplayUserInfo(User user)
    {
        Console.WriteLine($"User's ID: {user.ID}");
        Console.WriteLine($"Bio: {user.Profile?.Bio ?? "Bio not available"}");
        Console.WriteLine($"Website: {user.Profile?.WebsiteURL ?? "Website URL not available"}\n");
    }
}
public class UserProfile
{
    public string? Bio { get; init; }
    public string? WebsiteURL { get; init; }
}

public class User
{
    public UserProfile? Profile { get; init; }
    public int ID { get; init; }
}