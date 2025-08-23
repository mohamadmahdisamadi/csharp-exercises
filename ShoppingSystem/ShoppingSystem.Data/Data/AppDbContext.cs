using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Domain.Entities;
namespace ShoppingSystem.Data.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<UserEntity> Users { get; set; }
}