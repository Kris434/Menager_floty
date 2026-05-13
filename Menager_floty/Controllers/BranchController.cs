using BLL.Interfaces;
using DAL.Dto;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Menager_floty.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchController(IBranchService service) : ControllerBase
{
    private readonly IBranchService _service = service;
    
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
    
    [HttpPost]
    public async Task<ActionResult<Branch>> Add([FromBody] BranchDto branch)
    {
        Branch newBranch = new()
        {
            UserId = branch.userId,
            BranchName = branch.BranchName
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

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        
        return NoContent();
    }
}