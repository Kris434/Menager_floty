using BLL.Interfaces;
using DAL.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Menager_floty.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TrailerController(ITrailerService trailerService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTrailers()
    {
        var trailers = await trailerService.GetAllTrailers();

        return Ok(trailers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrailerById(int id)
    {
        var result = await trailerService.GetTrailerById(id);

        return Ok(result);
    }

    [HttpGet("branches/{id}")]
    public async Task<IActionResult> GetTrailersByBranchId(int id)
    {
        var trailers = await trailerService.GetTrailersByBranchId(id);
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
            AgregatInspectionId = trailer.AgregatInspectionId
        };

        await trailerService.AddTrailer(newTrailer);

        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTrailer(int id, TrailerDto newTrailer)
    {
        Trailer trailer = new Trailer()
        {
            Plate = newTrailer.Plate,
            Capacity = newTrailer.Capacity,
            InspectionId = newTrailer.InspectionId,
            AgregatInspectionId = newTrailer.AgregatInspectionId,
            BranchId = newTrailer.BranchId,
            IsBlocked = newTrailer.IsBlocked,
            FuelLevel = newTrailer.FuelLevel
        };
        
        await trailerService.UpdateTrailer(trailer, id);

        return Ok();
    }

    [HttpDelete("{trailerId}")]
    public async Task<IActionResult> DeleteTrailer(int trailerId)
    {
        await trailerService.DeleteTrailer(trailerId);

        return NoContent();
    }

    [HttpGet("inspections/{trailerId}")]
    public async Task<IActionResult> GetAllInspectionsByTrailerId(int trailerId)
    {
        var result = await trailerService.GetAllInspectionsByTrailerId(trailerId);
        
        return Ok(result);
    }

    [HttpPost("inspections")]
    public async Task<IActionResult> AddInspection([FromBody] TrailerInspectionDto newInspection)
    {
        TrailerInspection inspection = new()
        {
            DateOfInspection = newInspection.DateOfInpection,
            ValidUntil = newInspection.ValidUntil,
            TrailerId = newInspection.TrailerId
        };

        await trailerService.AddInspection(inspection);
        
        return Created();
    }

    [HttpPut("inspections/{id}")]
    public async Task<IActionResult> UpdateTrailerInspection([FromBody] TrailerInspectionDto inspection, int id)
    {
        TrailerInspection trailerInspection = new()
        {
            DateOfInspection = inspection.DateOfInpection,
            ValidUntil = inspection.ValidUntil,
            TrailerId = inspection.TrailerId
        };
        
        await trailerService.UpdateInspection(trailerInspection, id);
        
        return NoContent();
    }

    [HttpDelete("inspections/{id}")]
    public async Task<IActionResult> DeleteInspection(int id)
    {
        await trailerService.DeleteInspection(id);
        
        return NoContent();   
    }
    
    [HttpGet("refrigeratorInspections/trailer/{trailerId}")]
    public async Task<IActionResult> GetAllRefrigeratorInspectionsByTrailerId(int trailerId)
    {
        var result = await trailerService.GetAllRefrigeratorInspectionsByTrailerId(trailerId);
        
        return Ok(result);
    }

    [HttpGet("refrigeratorInspections")]
    public async Task<IActionResult> GetAllRefrigeratorInspections()
    {
        var result = await trailerService.GetAllRefrigeratorInspections();
        
        return Ok(result);
    }
    
    [HttpGet("refrigeratorInspections/{id}")]
    public async Task<IActionResult> GetRefrigeratorInspectionById(int id)
    {
        var result = await trailerService.GetRefrigeratorInspectionById(id);
        
        return Ok(result);
    }

    [HttpPost("refrigeratorInspections")]
    public async Task<IActionResult> AddRefrigeratorInspection(
        [FromBody] TrailerRefrigeratorInspectionDto inspectionDto)
    {
        TrailerRefrigeratorInspections newInspection = new TrailerRefrigeratorInspections()
        {
            DateOfInspection = inspectionDto.DateOfInspection,
            ValidUntil = inspectionDto.ValidUntil,
            MotoHours = inspectionDto.MotoHours,
            TrailerId = inspectionDto.TrailerId
        };
        
        await trailerService.AddRefrigeratorInspection(newInspection);
        
        return Created();
    }

    [HttpPut("refrigeratorInspections/{id}")]
    public async Task<IActionResult> UpdateRefrigeratorInspection(
        [FromBody] TrailerRefrigeratorInspectionDto inspectionDto, int id)
    {
        TrailerRefrigeratorInspections newInspection = new TrailerRefrigeratorInspections()
        {
            DateOfInspection = inspectionDto.DateOfInspection,
            ValidUntil = inspectionDto.ValidUntil,
            MotoHours = inspectionDto.MotoHours,
            TrailerId = inspectionDto.TrailerId
        };

        await trailerService.UpdateRefrigeratorInspection(newInspection, id);
        
        return NoContent();
    }

    [HttpDelete("refrigeratorInspections/{id}")]
    public async Task<IActionResult> DeleteRefrigeratorInspection(int id)
    {
        await trailerService.DeleteRefrigeratorInspection(id);
        
        return NoContent();  
    }
}