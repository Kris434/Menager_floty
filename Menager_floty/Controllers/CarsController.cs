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
    private readonly ICarService _carsRepository;
    
    public CarsController(ICarService carsRepository)
    {
        _carsRepository = carsRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _carsRepository.GetById(id);

        return Ok(result);
    }

    [HttpGet("{id}/cars")]
    public async Task<IActionResult> GetByUser(int id)
    {
        var result = await _carsRepository.GetByUser(id);
        
        if(result != null)
            return Ok(result);
        else
            return NotFound();
    }

    [HttpPost] // ToDo: Tutaj trzeba dodać id aktualnie zalogowanego usera. Aktualnie dodanie pojazdu nie przypisuje go do nikogo
    public async Task<IActionResult> Post([FromBody] CarDto dto)
    {
        Car car = new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Plate = dto.Plate,
            UserId = dto.UserId
        };
        
        await _carsRepository.Add(car);
        
        return Created($"api/cars/{car.Id}", car);
    }
}