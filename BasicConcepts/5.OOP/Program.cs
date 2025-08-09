
using System;

/*
    Designing a "Payment Processing System" using OOP concepts such as inheritance and polymorphism.
    Through this assignment, i learned about properties of a class, abstract classes and interfaces.
*/

// Test Program
List<IPaymentMethod> paymentMethods = new List<IPaymentMethod>();
try { paymentMethods.Add(new CreditCardPayment("111111111111111")); }
catch (ArgumentException ae) { Console.WriteLine(ae.Message); }
try { paymentMethods.Add(new CreditCardPayment("1111111111111111")); }
catch (ArgumentException ae) { Console.WriteLine(ae.Message); }

try { paymentMethods.Add(new PayPalPayment("leaningcsharpgmail.com")); }
catch (ArgumentException ae) { Console.WriteLine(ae.Message); }
try { paymentMethods.Add(new PayPalPayment("leaningcsharp@gmail.com")); }
catch (ArgumentException ae) { Console.WriteLine(ae.Message); }

foreach (var p in paymentMethods)
{
    p.ProcessPayment(100);
}


// Classes
public class PaymentResult
{
    public bool Success { get; init; }
    public string TransactionId { get; init; } = string.Empty;
    public string ErrorMessage { get; init; } = string.Empty;
}

public interface IPaymentMethod
{
    PaymentResult ProcessPayment(double amount);
}

public abstract class PaymentMethod : IPaymentMethod
{
    public abstract string Name { get; }
    public abstract PaymentResult ProcessPayment(double amount);
}

public class CreditCardPayment : PaymentMethod
{
    private readonly string _cardNumber;
    public override string Name => "CreditCard";
    public CreditCardPayment(string cardnumber)
    {
        if (string.IsNullOrWhiteSpace(cardnumber) || cardnumber.Length != 16)
        {
            throw new ArgumentException("Enter exactly 16 digits for card number.");
        }
        _cardNumber = cardnumber;
    }

    public override PaymentResult ProcessPayment(double amount)
    {
        double processingFee = amount * 0.02;
        double totalFee = amount + processingFee;
        Console.WriteLine($"Processing paymenet of credit card ({_cardNumber}) with number {Name} and amount of {totalFee:C}.");
        return new PaymentResult { Success = true, TransactionId = Guid.NewGuid().ToString() };
    }
}

public class PayPalPayment : PaymentMethod
{
    private readonly string _emailAddress;
    public override string Name => "PayPal";
    public PayPalPayment(string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress) || !emailAddress.Contains('@'))
        {
            throw new ArgumentException("Enter a valid email address.");
        }
        _emailAddress = emailAddress;
    }

    public override PaymentResult ProcessPayment(double amount)
    {
        Console.WriteLine($"Redirecting to PayPal for user {_emailAddress}, total cost: {amount:C}.");
        return new PaymentResult
        {
            Success = true,
            TransactionId = Guid.NewGuid().ToString("N")
        };
    }
}