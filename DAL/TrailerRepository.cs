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
        var result = await _context.Trailer.FindAsync(id);
        return result;
    }

    public async Task<IEnumerable<Trailer>> GetAll()
    {
        List<Trailer> result = await _context.Trailer.ToListAsync();
        return result;
    }

    public async Task Add(TrailerInspection trailerInspection)
    {
        _context.TrailerInspection.Add(trailerInspection);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TrailerInspection trailerInspection)
    {
        _context.TrailerInspection.Update(trailerInspection);
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

    public Task Add(TrailerRefrigeratorInspections trailerRefrigeratorInspections)
    {
        throw new NotImplementedException();
    }

    public Task Update(TrailerRefrigeratorInspections trailerRefrigeratorInspections)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAgregatInspection(TrailerRefrigeratorInspections trailerRefrigeratorInspections)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<TrailerRefrigeratorInspections>> GetAllAgregatInspections()
    {
        throw new NotImplementedException();
    }
}