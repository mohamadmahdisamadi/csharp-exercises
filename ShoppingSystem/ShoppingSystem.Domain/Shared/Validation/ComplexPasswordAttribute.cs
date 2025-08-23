using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace ShoppingSystem.Domain.Shared.Validation;

public class ComplexPasswordAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var password = value as string;

        if (string.IsNullOrWhiteSpace(password))
        {
            return ValidationResult.Success;
        }

        if (password.Length < 8)
        {
            return new ValidationResult("Password must be at least 8 characters long.");
        }

        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            return new ValidationResult("Password must contain at least one uppercase letter.");
        }

        if (!Regex.IsMatch(password, @"[a-z]"))
        {
            return new ValidationResult("Password must contain at least one lowercase letter.");
        }

        if (!Regex.IsMatch(password, @"[0-9]"))
        {
            return new ValidationResult("Password must contain at least one number.");
        }

        return ValidationResult.Success;
    }
}
