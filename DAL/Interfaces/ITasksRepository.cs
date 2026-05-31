using Model;

namespace DAL.Interfaces;

public interface ITasksRepository
{
    Task<IEnumerable<Tasks>> GetAll();
    Task<Tasks> GetById(int id);
    Task Add(Tasks task);
    Task Update(int id, Tasks task);
    Task Delete(Tasks task);
}