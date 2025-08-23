using System.ComponentModel.DataAnnotations;

namespace ShoppingSystem.Domain.Shared.Validation;

public class StandardAgeAttribute : RangeAttribute
{
    public StandardAgeAttribute() : base(18, 99)
    {
        ErrorMessage = "Age must be between 18 and 99.";
    }
}