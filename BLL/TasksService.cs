using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL;

public class TasksService(ITasksRepository _repository) : ITasksService
{
    public async Task<List<Tasks>> GetAllByBranch(int id)
    {
        var result = await _repository.GetAll();
        result = result.Where(t => t.BranchId == id).ToList();

        return (List<Tasks>)result;
    }

    public async Task<Tasks> GetById(int id)
    {
        var result = await _repository.GetById(id);
        
        return result;
    }

    public async Task Add(Tasks task)
    {
        Tasks newTask = new Tasks()
        {
            TaskName = task.TaskName,
            Priority = task.Priority,
            Description = task.Description,
            DateOfCreation = DateTime.UtcNow,
            IsCompleted = false,
            BranchId = task.BranchId,
        };
        
        await _repository.Add(newTask);
    }

    public async Task Update(Tasks task, int id)
    {
        task.IsCompleted = true;
        task.DateOfCompletion = DateTime.UtcNow;
        
        await _repository.Update(id, task);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(await _repository.GetById(id));
    }

    public async Task CompleteTask(int id)
    {
        Tasks task = await _repository.GetById(id);
        
        if (task == null) throw new Exception("Task not found");
        
        task.IsCompleted = true;
        task.DateOfCompletion = DateTime.UtcNow;
        
        await _repository.Update(id, task);
    }
}