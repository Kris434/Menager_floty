using Model;

namespace BLL.Interfaces;

public interface ICarInspectionService
{
    Task<bool> IsValid(int carId);
    Task<List<CarInspection>> GetAllByCarId(int carId);
}