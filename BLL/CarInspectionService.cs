using BLL.Interfaces;
using DAL.Interfaces;

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

        return inspection.OrderBy(i => i.ValidUntil).First().ValidUntil > DateTime.Now;
    }
}