using System;

/*
    A calculator with only Division operation that catches DivisionByZero exception.
*/

public class Program {
    public static void Main() {
        Calculator calculator = new Calculator();
        List<ValueTuple<int, int>> i = new List<ValueTuple<int, int>>();
        i.Add((1, 10));
        i.Add((0, 0));
        i.Add((-17, 51));
        foreach ((int a, int b) in i)
        {
            Console.Write($"{a} / {b} = ");
            try {
                double result = calculator.Divide(a, b);
                Console.WriteLine(result);
            } catch (DivisionByZeroException dze) {
                Console.WriteLine(dze.Message);
            } finally {
                Console.WriteLine("done.\n");
            }
        }
    }
}

public class DivisionByZeroException : System.Exception {
    public string Message { get; init; } = "Can't divide a number by zero!";
    public DivisionByZeroException(string message) {
        Message = message;
    }
    public DivisionByZeroException() {}
}

public class Calculator {
    public double Divide(double numerator, double denominator) {
        if (denominator == 0) {
            throw new DivisionByZeroException();
        }
        return numerator / denominator;
    }
}