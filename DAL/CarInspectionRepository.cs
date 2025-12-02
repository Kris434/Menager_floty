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
    
    public Task AddInspection(CarInspection inspection)
    {
        throw new NotImplementedException();
    }

    public Task DeleteInspection(CarInspection inspection)
    {
        throw new NotImplementedException();
    }

    public Task UpdateInspection(CarInspection inspection)
    {
        throw new NotImplementedException();
    }

    public async Task<IQueryable<CarInspection>> GetAllByCarId(int carId)
    {
        var result = _context.CarInspections.Where(i => i.CarId == carId);
        return result;
    }
}