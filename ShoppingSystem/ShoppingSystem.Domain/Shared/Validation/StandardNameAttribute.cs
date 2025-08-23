using System.ComponentModel.DataAnnotations;
namespace ShoppingSystem.Domain.Shared.Validation;
public class StandardNameAttribute : StringLengthAttribute
{
    public StandardNameAttribute() : base(100) // Sets the maximum length to 100
    {
        MinimumLength = 5; 
        ErrorMessage = "The Name must be between 5 and 100 characters.";
    }
}