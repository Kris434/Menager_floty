using Model;

namespace DAL.Interfaces;

public interface ICarInspectionRepository
{
    Task AddInspection(CarInspection inspection);
    Task DeleteInspection(CarInspection inspection);
    Task UpdateInspection(CarInspection inspection);
    Task<IQueryable<CarInspection>> GetAllByCarId(int carId);
}