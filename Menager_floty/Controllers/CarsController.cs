using BLL.Interfaces;
using DAL.Dto;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Menager_floty.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController(ICarService carsService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await carsService.GetById(id);

        return Ok(result);
    }

    [HttpGet("{id}/cars")]
    public async Task<IActionResult> GetByBranch(int id)
    {
        var result = await carsService.GetByBranch(id);
        
        return Ok(result);
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
        
        await carsService.Add(car);
        
        return Created($"api/cars/{car.Id}", car);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
    {
        await carsService.Update(car, id);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        await carsService.Delete(id);
        
        return NoContent();
    }
}