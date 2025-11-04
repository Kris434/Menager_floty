using Model;

namespace DAL.Interfaces;

public interface ICarsRepository
{
    Task<Cars> GetCarById(int id);
    Task AddCar(Cars car);
}