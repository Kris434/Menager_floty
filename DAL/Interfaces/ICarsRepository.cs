using Model;

namespace DAL.Interfaces;

public interface ICarsRepository
{
    Task<IEnumerable<Car>> GetAll();
    Task<Car> GetCarById(int id);
    Task AddCar(Car car);
    Task UpdateCar(Car car);
    Task DeleteCar(Car car);
}