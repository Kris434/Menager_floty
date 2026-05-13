using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Model;

namespace BLL;

public class CarService : ICarService
{
    private readonly ICarsRepository _repo;

    public CarService(ICarsRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<Car> GetById(int id)
    {
        var result = await _repo.GetCarById(id);
        
        return result;
    }

    public async Task<List<Car>> GetByBranch(int id)
    {
        var result = await _repo.GetAll();
        result = result.Where(c => c.BranchId == id);
        
        return result.ToList();
    }

    public async Task Add(Car car)
    {
        await _repo.AddCar(car);
    }
    
    public async Task Update(Car car, int id)
    {
        Car toUpdate = await _repo.GetCarById(id);
        
        toUpdate.Name = car.Name;
        toUpdate.BranchId = car.BranchId;
        toUpdate.InspectionId = car.InspectionId;
        toUpdate.Plate = car.Plate;
        
        await _repo.UpdateCar(toUpdate);
    }
    
    public async Task Delete(int id)
    {
        await _repo.DeleteCar(await _repo.GetCarById(id));
    }
}