using BLL.Interfaces;
using DAL.Dto;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Menager_floty.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchController(IBranchService _service, IUserService _users) : ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<List<Branch>>> GetAll()
    {
        var result = await _service.GetAll();
        
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetById(id);
        
        return Ok(result);
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetByUserId(int id)
    {
        var result = await _service.GetAll();
        var userBranches = result.Where(b => b.Users.Any(u => u.Id == id));
        
        return Ok(userBranches);
    }
    
    [HttpPost]
    public async Task<ActionResult<Branch>> Add([FromBody] BranchDto branch)
    {
        User user = _users.GetUserById(branch.userId).Result;
        
        Branch newBranch = new()
        {
            BranchName = branch.BranchName,
            Users = new List<User> { user }
        };
        
        await _service.Add(newBranch);
        
        return Ok(newBranch);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Branch branch)
    {
        await _service.Update(branch, id);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        
        return NoContent();
    }
    
    [HttpPost("{branchId}/users")]
    public async Task<IActionResult> AddUserToBranch(int branchId, [FromBody] AddUserToBranchDto request)
    {
        var branch = await _service.GetById(branchId);

        var user = await _users.GetUserById(request.UserId);
        
        if (branch.Users.Any(u => u.Id == user.Id))
            return BadRequest("Ten użytkownik jest już przypisany do tego oddziału.");
        
        branch.Users.Add(user);
        await _service.Update(branch, branchId);

        return Ok();
    }
    
    [HttpDelete("{branchId}/users/{userId}")]
    public async Task<IActionResult> DeleteUserFromBranch(int branchId, int userId)
    {
        await _service.DeleteUserFromBranch(userId, branchId);
        
        return NoContent();
    }

    public class AddUserToBranchDto
    {
        public int UserId { get; set; }
    }
}