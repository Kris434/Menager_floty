using BLL.Interfaces;
using DAL.Dto;
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
    
    public async Task AddInspection(CarInspection inspection)
    {
        await _repo.AddInspection(inspection);
    }
    
    public async Task UpdateInspection(int id, CarInspectionDto inspection)
    {
        CarInspection existing = _repo.GetInspectionById(id).Result;
        
        existing.CarId = inspection.CarId;
        existing.DateOfInspection = inspection.DateOfInspection;
        existing.ValidUntil = inspection.ValidUntil;
        
        await _repo.UpdateInspection(existing);
    }
    
    public async Task DeleteInspection(int id)
    {
        await _repo.DeleteInspection(await _repo.GetInspectionById(id));
    }

    public async Task<CarInspection> GetInspectionById(int id)
    {
        var result = await _repo.GetInspectionById(id);
        
        return result;
    }
}