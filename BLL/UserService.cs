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
        if(user.Password != null)
            user.Password = PasswordHash.Hash(user.Password);
        
        await _userRepository.AddUser(user);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var result = await _userRepository.GetUser(email);
        
        if(result == null) throw new Exception("User not found");
        
        return result;
    }

    public async Task<User> GetUserByLogin(string login)
    {
        var result = await _userRepository.GetUserByLogin(login);
        return result;  
    }

    public async Task<User> GetUserById(int id)
    {
        var result = await _userRepository.GetUserById(id);
        return result; 
    }

    public async Task<List<User>> GetAll()
    {
        var result = (List<User>)await _userRepository.GetAll();
        return result;
    }
}