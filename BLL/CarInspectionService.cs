using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL;

public class CarInspectionService : ICarInspectionService
{
    private readonly ICarInspectionRepository _repo;

    public CarInspectionService(ICarInspectionRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<bool> IsValid(int carId)
    {
        var inspection = await _repo.GetAllByCarId(carId);

        return inspection.OrderBy(i => i.ValidUntil).Last().ValidUntil > DateTime.Now;
    }

    public async Task<List<CarInspection>> GetAllByCarId(int carId)
    {
        var result = await _repo.GetAllByCarId(carId);
        return result.ToList();
    }
}