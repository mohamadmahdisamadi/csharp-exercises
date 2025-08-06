global using static System.Console;

/*
    This program asks some questions from the user and calculates shipping cost based on them.
*/
class ShippingCostCalculator
{
    static void Main()
    {

        Write("Enter the package weight in kg: ");
        double weight = double.Parse(ReadLine());
        Write("Enter the destination zone (domestic/international): ");
        string destination = ReadLine();
        Write("Determine if you are a premium member: ");
        bool isPremium = bool.Parse(ReadLine());

        double cost = (weight < 2) ? 5 : (weight < 10) ? 10 : 25;
        cost += (destination == "international") ? 50 : 0;
        cost *= (isPremium) ? 0.8 : 1;
        WriteLine((isPremium && weight < 2 && destination == "domestic") ? 0 : cost);
    }
}