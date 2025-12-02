using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> User { get; set; }
    
    public DbSet<Car> Car { get; set; }
    
    public DbSet<CarInspection> CarInspections { get; set; }
    
}