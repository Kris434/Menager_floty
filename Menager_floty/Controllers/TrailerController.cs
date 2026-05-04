using BLL.Interfaces;
using DAL.Dto;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Menager_floty.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrailerController : ControllerBase
{
    private readonly ITrailerService _service;

    public TrailerController(ITrailerService trailerService)
    {
        _service = trailerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTrailers()
    {
        var trailers = await _service.GetAllTrailers();

        return Ok(trailers);
    }

    [HttpPost]
    public async Task<IActionResult> AddTrailer([FromBody] TrailerDto trailer)
    {
        Trailer newTrailer = new Trailer()
        {
            Plate = trailer.Plate,
            Capacity = trailer.Capacity,
            InspectionId = trailer.InspectionId,
            BranchId = trailer.BranchId,
            IsBlocked = false,
            FuelLevel = trailer.FuelLevel,
            AgregatInspectionId = trailer.AgregatInspectionsId
        };

        await _service.AddTrailer(newTrailer);

        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTrailer(int id, TrailerDto newTrailer)
    {
        Trailer trailer = new Trailer()
        {
            Plate = newTrailer.Plate,
            Capacity = newTrailer.Capacity,
            InspectionId = newTrailer.InspectionId
        };
        
        await _service.UpdateTrailer(trailer, id);

        return Ok();
    }

    [HttpDelete("{trailerId}")]
    public async Task<IActionResult> DeleteTrailer(int trailerId)
    {
        await _service.DeleteTrailer(trailerId);

        return NoContent();
    }
}