/*
    TypeChecker class.
    Its main (and only) functionallity is to recieve an input and determine its type.
*/

class TypeChecker
{
    static void Main()
    {
        bool keepRunning = true;
        while (keepRunning)
        {
            Console.Write("Main: ");
            string? cmd = Console.ReadLine();
            switch (cmd)
            {
                case "exit": { keepRunning = false; break; }
                case "type": { RecognizeType(); break; }
                default: { Console.WriteLine("That's not a pre-defined command"); break; }
            }
        }
    }

    static void RecognizeType()
    {
        while (true)
        {
            Console.Write("    ");
            Console.Write("RecognizeType: ");
            string? inp = Console.ReadLine();
            if (string.IsNullOrEmpty(inp) || inp.Equals("exit")) { break; }
            Console.Write("    ");
            if (int.TryParse(inp, out int i)) { Console.WriteLine("int"); }
            else if (double.TryParse(inp, out double d)) { Console.WriteLine("double"); }
            else if (char.TryParse(inp, out char c)) { Console.WriteLine("char"); }
            else if (bool.TryParse(inp, out bool b)) { Console.WriteLine("bool"); }
            else { Console.WriteLine("string"); }
        }
    }
}