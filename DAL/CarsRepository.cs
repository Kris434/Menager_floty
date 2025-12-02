using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL;

public class CarsRepository : ICarsRepository
{
    private readonly AppDbContext _context; 

    public CarsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Car>> GetAll()
    {
        var result = _context.Car;
        return result;
    }
    
    public async Task<Car> GetCarById(int id)
    {
        var result = await _context.Car.FindAsync(id);
        return result;
    }

    public async Task AddCar(Car car)
    {
        await _context.Car.AddAsync(car);
        await _context.SaveChangesAsync();
    }
}