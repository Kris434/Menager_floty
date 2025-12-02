namespace BLL.Interfaces;

public interface ICarInspectionService
{
    Task<bool> IsValid(int carId);
}