using System.ComponentModel.DataAnnotations;
namespace ShoppingSystem.Application.DTOs;

public class EditPasswordDto
{
    [Required]
    // [StringLength(100, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;
}