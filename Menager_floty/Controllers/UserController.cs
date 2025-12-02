using BLL.Interfaces;
using DAL.Dto;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Menager_floty.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private IUserService _users;
    
    public UserController(IUserService users)
    {
        _users = users;
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> getUser(string email)
    {
        var result = await _users.GetUserByEmail(email);

        if (result == null)
            return NotFound(result);
        
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
            LastName = dto.LastName
        };
        
        await _users.AddUser(user);
        
        return CreatedAtAction(nameof(getUser), new { email = user.Email }, user);
    }
}