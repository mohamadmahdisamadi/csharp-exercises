using System.ComponentModel.DataAnnotations;
using ShoppingSystem.Domain.Shared.Validation;
namespace ShoppingSystem.Application.DTOs;

public class EditPasswordDto
{
    [Required]
    [ComplexPassword]
    public string Password { get; set; } = string.Empty;
}