using System.ComponentModel.DataAnnotations;
using ShoppingSystem.Domain.Shared.Enums;
using ShoppingSystem.Domain.Shared.Validation;
namespace ShoppingSystem.Domain.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StandardName]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [StandardAge]
    public int Age { get; set; }

    [Required]
    [ComplexPassword]
    public string Password { get; set; } = string.Empty;

    [Required]
    public RoleType Role { get; set; } = RoleType.User;
}