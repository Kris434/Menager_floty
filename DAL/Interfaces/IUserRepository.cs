using Model;

namespace DAL.Interfaces;

public interface IUserRepository
{
    Task<User>  GetUser(string email);
    Task<User> GetUserByLogin(string login);
    Task<User> GetUserById(int id);
    Task<IEnumerable<User>> GetAll();
    Task AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(User user);
}