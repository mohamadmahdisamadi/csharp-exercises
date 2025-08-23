using System.ComponentModel.DataAnnotations;
using ShoppingSystem.Domain.Shared.Validation;

namespace ShoppingSystem.Application.DTOs;

public class LoginDto
{
    [Required]
    [StandardName]
    public string Name { get; set; } = string.Empty;

    [Required]
    [ComplexPassword]
    public string Password { get; set; } = string.Empty;
    
}