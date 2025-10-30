using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Menager_floty.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private IUserRepository _users;
    
    public UserController(IUserRepository users)
    {
        _users = users;
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> getUser(string email)
    {
        var result = await _users.GetUser(email);

        if (result == null)
            return NotFound(result);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] Users user)
    {
        await _users.AddUser(user);
        
        return CreatedAtAction(nameof(getUser), new { email = user.Email }, user);
    }
}