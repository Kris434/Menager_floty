using BLL.Interfaces;
using DAL.Dto;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Menager_floty.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController(ITasksService _service) : ControllerBase
{
    [HttpGet("branch/{id}")]
    public async Task<IActionResult> GetAll(int id)
    {
        var result = await _service.GetAllByBranch(id);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewTask([FromBody] TaskDto task)
    {
        Tasks newTask = new Tasks()
        {
            TaskName = task.TaskName,
            Description = task.Description,
            Priority = task.Priority,
            BranchId = task.BranchId
        };
        
        await _service.Add(newTask);
        
        return Created($"api/tasks/{newTask.Id}", newTask);
    }

    [HttpPut("completed/{id}")]
    public async Task<IActionResult> EditTask(int id)
    {
        await _service.CompleteTask(id);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await _service.Delete(id);
        
        return NoContent();
    }
}