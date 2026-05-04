using BLL.Interfaces;
using DAL.Dto;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Menager_floty.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carsService;
    
    public CarsController(ICarService carsService)
    {
        _carsService = carsService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _carsService.GetById(id);

        return Ok(result);
    }

    [HttpGet("{id}/cars")]
    public async Task<IActionResult> GetByUser(int id)
    {
        var result = await _carsService.GetByBranch(id);
        
        if(result != null)
            return Ok(result);
        else
            return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CarDto dto)
    {
        Car car = new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Plate = dto.Plate,
            BranchId = dto.BranchId
        };
        
        await _carsService.Add(car);
        
        return Created($"api/cars/{car.Id}", car);
    }
}