using System.ComponentModel.DataAnnotations;
namespace ShoppingSystem.Application.DTOs;

public class EditUserDto
{
    // [StringLength(100, MinimumLength = 2)]
    public string? Name { get; set; }
    // [EmailAddress]
    public string? Email { get; set; }
    public int? Age { get; set; }
}
