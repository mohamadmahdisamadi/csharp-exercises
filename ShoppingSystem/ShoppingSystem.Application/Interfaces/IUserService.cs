using ShoppingSystem.Application.DTOs;
namespace ShoppingSystem.Application.Interfaces;

public interface IUserService
{
    // Regular User Sevices
    Task<UserDto> AddUserAsync(RegisterUserDto user);
    Task<UserDto?> GetUserByIdAsync(int id);
    Task<bool> EditUserAsync(int id, EditUserDto user);
    Task<bool> EditPasswordAsync(int id, EditPasswordDto user);

    // Admin User Sevices
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<bool> EditUserByAdminAsync(int id, EditByAdminDto editedUser);
    Task ClearAllAsync();

    // Both Granted
    Task<bool> DeleteUserAsync(int id);
}