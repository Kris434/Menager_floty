namespace Model;

public class Tasks
{
    public int Id { get; set; }
    public string TaskName { get; set; }
    public int BranchId { get; set; }
    public DateTime DateOfCreation { get; set; }
    public DateTime? DateOfCompletion { get; set; }
    public bool IsCompleted { get; set; }
    public string? Description { get; set; }
    public string? Comment { get; set; }
    public int? Priority { get; set; }
}