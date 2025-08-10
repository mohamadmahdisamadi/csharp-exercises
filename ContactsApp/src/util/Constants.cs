public static class Constants
{
    public static int numofSpaces = 20;
    public static string vertLine = "|";
    public static string PhoneNumber = "PhoneNumber";
    public static string Name = "Name";
    public static int eachLineLength = (2 * vertLine.Length) + (3 * numofSpaces);
    public static string horzLine(char ch = '=') { return new string(ch, eachLineLength); }
    public static string AddSpaces(int count = 10) { return new string(' ', count); }
    public static int sleepTime = 2000;
}