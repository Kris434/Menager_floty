using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL;

public class TrailerRepository : ITrailerRepository
{
    private readonly AppDbContext _context;

    public TrailerRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task Add(Trailer trailer)
    {
        _context.Trailer.Add(trailer);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Trailer trailer)
    {
        var existingTrailer = await _context.Trailer.FindAsync(trailer.Id);

        if (existingTrailer == null)
        {
            throw new KeyNotFoundException($"Trailer with ID {trailer.Id} not found.");
        }

        existingTrailer.Capacity = trailer.Capacity;
        existingTrailer.Plate = trailer.Plate;

        await _context.SaveChangesAsync();
    }

    public async Task Delete(Trailer trailer)
    {
        _context.Trailer.Remove(trailer);
        await _context.SaveChangesAsync();
    }

    public async Task<Trailer> GetById(int id)
    {
        var result = await _context.Trailer
            .Include(i => i.InspectionId)
            .Include(i => i.AgregatInspectionId)
            .FirstAsync(t => t.Id == id);
        return result;
    }

    public async Task<IEnumerable<Trailer>> GetAll()
    {
        var result = await _context.Trailer
            .Include(i => i.InspectionId)
            .Include(i => i.AgregatInspectionId)
            .ToListAsync();
        return result;
    }

    public async Task<TrailerInspection> GetInspectionById(int id)
    {
        var result = await _context.TrailerInspection.FindAsync(id);
        return result;
    }

    public async Task Add(TrailerInspection trailerInspection)
    {
        _context.TrailerInspection.Add(trailerInspection);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TrailerInspection trailerInspection)
    {
        var existingInspection = await _context.TrailerInspection.FindAsync(trailerInspection.Id);

        if (existingInspection == null)
        {
            throw new KeyNotFoundException($"Trailer with ID {trailerInspection.Id} not found.");
        }

        existingInspection.TrailerId = trailerInspection.TrailerId;
        existingInspection.DateOfInspection = trailerInspection.DateOfInspection;
        existingInspection.ValidUntil = trailerInspection.ValidUntil;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteInspection(TrailerInspection trailerInspection)
    {
        _context.TrailerInspection.Remove(trailerInspection);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TrailerInspection>> GetAllInspections()
    {
        List<TrailerInspection> result = await _context.TrailerInspection.ToListAsync();
        return result;
    }

    public async Task<TrailerRefrigeratorInspections> GetRefrigeratorInspectionById(int id)
    {
        TrailerRefrigeratorInspections? result = await _context.TrailerAgregatInspections.FindAsync(id);
        
        return result;
    }

    public async Task Add(TrailerRefrigeratorInspections trailerRefrigeratorInspections)
    {
        _context.TrailerAgregatInspections.Add(trailerRefrigeratorInspections);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TrailerRefrigeratorInspections trailerRefrigeratorInspections)
    {
        TrailerRefrigeratorInspections existing = await _context.TrailerAgregatInspections.FindAsync(trailerRefrigeratorInspections.Id);
        
        if(existing == null)
            throw new KeyNotFoundException($"Trailer with ID {trailerRefrigeratorInspections.Id} not found.");

        existing.DateOfInspection = trailerRefrigeratorInspections.DateOfInspection;
        existing.ValidUntil = trailerRefrigeratorInspections.ValidUntil;
        existing.TrailerId = trailerRefrigeratorInspections.TrailerId;
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAgregatInspection(TrailerRefrigeratorInspections trailerRefrigeratorInspections)
    {
        _context.TrailerAgregatInspections.Remove(trailerRefrigeratorInspections);
        await _context.SaveChangesAsync();
    }

    public Task<IEnumerable<TrailerRefrigeratorInspections>> GetAllAgregatInspections()
    {
        try
        {
            var result = _context.TrailerAgregatInspections;
            return Task.FromResult<IEnumerable<TrailerRefrigeratorInspections>>(result);
        }
        catch (Exception exception)
        {
            return Task.FromException<IEnumerable<TrailerRefrigeratorInspections>>(exception);
        }
    }
}