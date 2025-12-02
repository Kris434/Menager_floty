using Model;

namespace DAL.Interfaces;

public interface ICarsRepository
{
    Task<IQueryable<Car>> GetAll();
    Task<Car> GetCarById(int id);
    Task AddCar(Car car);
}