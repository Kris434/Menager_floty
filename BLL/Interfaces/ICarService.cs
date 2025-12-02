using Model;

namespace BLL.Interfaces;

public interface ICarService
{
    Task<Car> GetById(int id);
    Task<List<Car>> GetByUser(int id);
    Task Add(Car car);
}