using ShoppingSystem.Application.DTOs;
using ShoppingSystem.Application.Interfaces;
using ShoppingSystem.Domain.Interfaces;
using ShoppingSystem.Domain.Entities;
namespace ShoppingSystem.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        UserEntity? user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
        {
            return false;
        }

        await _userRepository.DeleteUserAsync(id);
        return true;
    }

    public async Task<bool> EditPasswordAsync(int id, EditPasswordDto passwordDto)
    {
        UserEntity? user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
        {
            return false;
        }

        user.Password = passwordDto.Password;

        await _userRepository.EditUserAsync(user);
        return true;
    }

    public async Task<bool> EditUserAsync(int id, EditUserDto editedUser)
    {
        UserEntity? user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
        {
            return false;
        }

        user.Name = editedUser.Name ?? user.Name;
        user.Email = editedUser.Email ?? user.Email;
        user.Age = editedUser.Age ?? user.Age;

        await _userRepository.EditUserAsync(user);
        return true;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUersAsync();
        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            Age = u.Age
        });
    }

    public async Task<UserDto?> GetUserByIdAsync(int id)
    {
        UserEntity? user = await _userRepository.GetUserByIdAsync(id) ?? throw new Exception("user not found.");
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Age = user.Age
        };
    }

    public async Task<UserDto> AddUserAsync(RegisterUserDto userDto)
    {
        var user = new UserEntity
        {
            Name = userDto.Name,
            Email = userDto.Email,
            Age = userDto.Age,
            Password = userDto.Password
        };

        var newUser = await _userRepository.AddUserAsync(user);
        return new UserDto
        {
            Id = newUser.Id,
            Name = newUser.Name,
            Email = newUser.Email,
            Age = newUser.Age,
        };
    }
}