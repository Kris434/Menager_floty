using DAL.Interfaces;
using Model;

namespace DAL;

public class CarsRepository : ICarsRepository
{
    private readonly AppDbContext _context;

    public CarsRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Cars> GetCarById(int id)
    {
        var result = await _context.Cars.FindAsync(id);
        return result;
    }

    public async Task AddCar(Cars car)
    {
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();
    }
}