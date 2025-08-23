using System.ComponentModel.DataAnnotations;
namespace ShoppingSystem.Application.DTOs;

public class RegisterUserDto
{
    [Required]
    // [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    // [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public int Age { get; set; }

    [Required]
    // [StringLength(100, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;

    public bool IsValid()
    {
        return true;
    }
}