using DAL.Dto;
using Model;

namespace BLL.Interfaces;

public interface ICarInspectionService
{
    Task<bool> IsValid(int carId);
    Task<List<CarInspection>> GetAllByCarId(int carId);
    Task AddInspection(CarInspection inspection);
    Task DeleteInspection(int id);
    Task UpdateInspection(int id, CarInspectionDto inspection);
    Task<CarInspection> GetInspectionById(int id);
}