using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Data.Data;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Domain.Interfaces;
namespace ShoppingSystem.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) {
        _context = context;
    }

    public async Task<UserEntity> AddUserAsync(UserEntity user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task DeleteUserAsync(int id)
    {
        UserEntity? user = await GetUserByIdAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task EditUserAsync(UserEntity user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserEntity>> GetAllUersAsync()
    {
        return await _context.Users.ToListAsync();
    }
    public async Task<UserEntity?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    public async Task<UserEntity?> GetUserByNameAsync(string name)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
    }
    public async Task<UserEntity?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}