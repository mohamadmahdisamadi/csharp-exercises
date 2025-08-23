using ShoppingSystem.Domain.Entities;
namespace ShoppingSystem.Domain.Interfaces;

public interface IUserRepository
{
    Task<UserEntity> AddUserAsync(UserEntity user);
    Task EditUserAsync(UserEntity user);
    Task DeleteUserAsync(int id);
    Task<IEnumerable<UserEntity>> GetAllUersAsync();
    Task<UserEntity?> GetUserByIdAsync(int id);
    Task<UserEntity?> GetUserByEmailAsync(string email);
}