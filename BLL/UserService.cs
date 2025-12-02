using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task AddUser(User user)
    {
        user.Password = PasswordHash.Hash(user.Password);
        
        await _userRepository.AddUser(user);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var result = await _userRepository.GetUser(email);
        
        return result;
    }
}