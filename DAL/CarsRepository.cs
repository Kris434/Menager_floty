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

    public async Task<IEnumerable<Car>> GetAll()
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
    
    public async Task UpdateCar(Car car)
    {
        var existingCar = await _context.Car.FindAsync(car.Id);

        existingCar.Name = car.Name;
        existingCar.BranchId = car.BranchId;
        existingCar.InspectionId = car.InspectionId;
        existingCar.Plate = car.Plate;
        
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteCar(Car car)
    {
        _context.Car.Remove(car);
        await _context.SaveChangesAsync();
    }
}