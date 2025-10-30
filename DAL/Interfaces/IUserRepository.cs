using Model;

namespace DAL.Interfaces;

public interface IUserRepository
{
    Task<Users>  GetUser(string email);
    Task AddUser(Users user);
    Task UpdateUser(Users user);
    Task DeleteUser(Users user);
}