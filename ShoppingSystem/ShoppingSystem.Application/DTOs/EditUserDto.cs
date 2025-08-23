using System.ComponentModel.DataAnnotations;
using ShoppingSystem.Domain.Shared.Validation;
namespace ShoppingSystem.Application.DTOs;

public class EditUserDto
{
    [StandardName]
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [StandardAge]
    public int? Age { get; set; }
}
