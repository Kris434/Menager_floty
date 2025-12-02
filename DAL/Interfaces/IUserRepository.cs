using Model;

namespace DAL.Interfaces;

public interface IUserRepository
{
    Task<User>  GetUser(string email);
    Task AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(User user);
}