using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Menager_floty.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarsRepository _carsRepository;
    
    public CarsController(ICarsRepository carsRepository)
    {
        _carsRepository = carsRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _carsRepository.GetCarById(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Cars car)
    {
        await _carsRepository.AddCar(car);
        
        return Created($"api/cars/{car.Id}", car);
    }
}