using Model;

namespace BLL.Interfaces;

public interface ICarService
{
    Task<Car> GetById(int id);
    Task<List<Car>> GetByBranch(int id);
    Task Add(Car car);
    Task Update(Car car, int id);
    Task Delete(int id);
}