using DAL.Interfaces;
using Model;

namespace DAL;

public class CarInspectionRepository : ICarInspectionRepository
{
    private readonly AppDbContext _context;

    public CarInspectionRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task AddInspection(CarInspection inspection)
    {
        _context.CarInspections.Add(inspection);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteInspection(CarInspection inspection)
    {
        _context.CarInspections.Remove(inspection);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateInspection(CarInspection inspection)
    {
        CarInspection existingInspection = await _context.CarInspections.FindAsync(inspection.Id);
        
        existingInspection.CarId = inspection.CarId;
        existingInspection.DateOfInspection = inspection.DateOfInspection;
        existingInspection.ValidUntil = inspection.ValidUntil;
        
        await _context.SaveChangesAsync();
    }

    public async Task<IQueryable<CarInspection>> GetAllByCarId(int carId)
    {
        var result = _context.CarInspections.Where(i => i.CarId == carId);
        return result;
    }

    public async Task<CarInspection> GetInspectionById(int id)
    {
        var result = await _context.CarInspections.FindAsync(id);
        return result;   
    }
}