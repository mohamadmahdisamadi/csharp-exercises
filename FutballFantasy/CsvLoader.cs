using System;
using static Constants;
using static Utilities;

public class CsvLoader
{

    public List<List<string>> LoadFile(string filePath)
    {
        List<string> lines = ReadLines(filePath);
        return lines.Select(line => line.Split(',').Select(s => s.Trim()).ToList()).ToList();
    }

    public List<string> ReadLines(string filePath)
    {
        if (!File.Exists(filePath))
        {
            WE($"file {filePath} does not exist.");
            return [];
        }

        try
        {
            string[] allLines = File.ReadAllLines(filePath);

            if (allLines.Length < 2)
            {
                WL("File is either empty or includes only headers.");
                return [];
            }

            return allLines.Skip(1).ToList();
        }
        catch (Exception e)
        {
            WE($"An error occured when reading file {filePath}.");
            WL(e.Message);
        }

        return [];
    }
}
