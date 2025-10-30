using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Users> GetUser(string email)
    {
        var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        
        return result;
    }

    public async Task AddUser(Users user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public Task UpdateUser(Users user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(Users user)
    {
        throw new NotImplementedException();
    }
}