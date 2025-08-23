using ShoppingSystem.Application.DTOs;
namespace ShoppingSystem.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> AddUserAsync(RegisterUserDto user);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto?> GetUserByIdAsync(int id);
    Task<bool> EditUserAsync(int id, EditUserDto user);
    Task<bool> EditPasswordAsync(int id, EditPasswordDto user);
    Task<bool> DeleteUserAsync(int id);
}