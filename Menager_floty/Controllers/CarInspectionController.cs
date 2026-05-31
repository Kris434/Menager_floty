using BLL.Interfaces;
using DAL.Dto;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Menager_floty.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarInspectionController(ICarInspectionService _repo) : ControllerBase
{
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

    [HttpGet("inspection/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = _repo.GetInspectionById(id);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddInspection([FromBody] CarInspectionDto inspectionDto)
    {
        CarInspection newInspection = new()
        {
            Mileage = inspectionDto.Mileage,
            ValidUntil = DateTime.SpecifyKind(inspectionDto.ValidUntil, DateTimeKind.Utc),
            CarId = inspectionDto.CarId,
            DateOfInspection = DateTime.SpecifyKind(inspectionDto.DateOfInspection, DateTimeKind.Utc)
        };

        await _repo.AddInspection(newInspection);

        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateInspection(int id, CarInspectionDto inspectionDto)
    {
        await _repo.UpdateInspection(id, inspectionDto);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInspection(int id)
    {
        await _repo.DeleteInspection(id);
        
        return NoContent();  
    }
    
}