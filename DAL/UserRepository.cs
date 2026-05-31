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

    public async Task<User> GetUser(string email)
    {
        var result = await _context.User.FirstOrDefaultAsync(u => u.Email == email);
        
        return result;
    }

    public async Task<User> GetUserByLogin(string login)
    {
        var result = await _context.User.FirstOrDefaultAsync(u => u.Login == login);
        
        return result;   
    }

    public async Task<User> GetUserById(int id)
    {
        var result = await _context.User.FindAsync(id);
        return result;  
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        var result = await _context.User
            .Include(u => u.Branches)
            .ToListAsync();
        return result;
    }

    public async Task AddUser(User user)
    {
        await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(User user)
    {
        throw new NotImplementedException();
    }
}