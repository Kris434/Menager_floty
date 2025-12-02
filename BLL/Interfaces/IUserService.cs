using Model;

namespace BLL.Interfaces;

public interface IUserService
{
    Task AddUser(User user);
    Task<User> GetUserByEmail(string email);
}