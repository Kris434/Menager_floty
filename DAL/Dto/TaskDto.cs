namespace DAL.Dto;

public class TaskDto
{
    public string TaskName { get; set; }
    public int BranchId { get; set; }
    public int? Priority { get; set; }
    public string? Description { get; set; }
}