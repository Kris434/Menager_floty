using BLL;
using BLL.Interfaces;
using DAL.Dto;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Menager_floty.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private IUserService _users;
    private JwtTokenService jwtTokenService;
    
    public UserController(IUserService users, JwtTokenService jwt)
    {
        _users = users;
        jwtTokenService = jwt;
    }

    [Authorize]
    [HttpGet("{email}")]
    public async Task<IActionResult> getUser(string email)
    {
        var result = await _users.GetUserByEmail(email);

        if (result == null)
            return NotFound(result);
        
        return Ok(result);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _users.GetAll();
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserDto dto)
    {
        User user = new()
        {
            Id = dto.Id,
            Email = dto.Email,
            Password = dto.Password,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Login = dto.Login,
            Role = "User"
        };
        
        await _users.AddUser(user);
        
        return CreatedAtAction(nameof(getUser), new { email = user.Email }, user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginRequest)
    {
        var user = await _users.GetUserByLogin(loginRequest.Login);

        if (user == null)
            return Unauthorized("Nieprawidłowy login");

        var isPasswordValid = PasswordHash.VerifyPassword(loginRequest.Password, user.Password);

        if (!isPasswordValid)
            return Unauthorized("Hasło jest nieprawidłowe");

        var token = jwtTokenService.GenerateToken(user.Id.ToString(), user.Email, user.Role);

        return Ok(new { Token = token, UserId = user.Id });
    }
}