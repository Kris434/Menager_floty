using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Menager_floty.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarInspectionController(ICarInspectionService repo) : ControllerBase
{
    private readonly ICarInspectionService _repo = repo;

    [HttpGet("isValid/{id}")]
    public async Task<IActionResult> IsValid(int id)
    {
        var result = await _repo.IsValid(id);
        
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllByCarId(int id)
    {
        var result = await _repo.GetAllByCarId(id);
        
        return Ok(result);
    }
}