using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL;

public class TasksRepository(AppDbContext _context) : ITasksRepository
{
    public async Task<IEnumerable<Tasks>> GetAll()
    {
        var result = _context.Tasks.AsAsyncEnumerable();
        
        return (IEnumerable<Tasks>)result;
    }

    public async Task<Tasks> GetById(int id)
    {
        var result = await _context.Tasks.FindAsync(id);
        return result; 
    }

    public async Task Add(Tasks task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Tasks task)
    {
        var toEdit = await _context.Tasks.FindAsync(id);

        toEdit.Comment = task.Comment;
        toEdit.DateOfCompletion = task.DateOfCompletion;
        toEdit.BranchId = task.BranchId;
        toEdit.DateOfCreation = task.DateOfCreation;
        toEdit.Description = task.Description;
        toEdit.IsCompleted = task.IsCompleted;
        toEdit.TaskName = task.TaskName;
        toEdit.Priority = task.Priority;
        
        _context.Entry(toEdit).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Tasks task)
    {
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}