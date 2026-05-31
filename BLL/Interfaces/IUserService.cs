using Model;

namespace BLL.Interfaces;

public interface IUserService
{
    Task AddUser(User user);
    Task<User> GetUserByEmail(string email);
    Task<User> GetUserByLogin(string login);
    Task<User> GetUserById(int id);
    Task<List<User>> GetAll();
}