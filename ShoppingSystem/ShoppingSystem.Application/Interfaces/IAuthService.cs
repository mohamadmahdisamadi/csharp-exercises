using ShoppingSystem.Application.DTOs;
namespace ShoppingSystem.Application.Services;

public interface IAuthService
{
    Task<string?> LoginAsync(LoginDto loginDto);
}