using Model;

namespace BLL.Interfaces;

public interface ITasksService
{
    Task<List<Tasks>> GetAllByBranch(int id);
    Task<Tasks> GetById(int id);
    Task Add(Tasks task);
    Task Update(Tasks task, int id);
    Task CompleteTask(int id);
    Task Delete(int id);
}