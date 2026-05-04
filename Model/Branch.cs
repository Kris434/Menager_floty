using System.ComponentModel.DataAnnotations;

namespace Model;

public class Branch
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string BranchName { get; set; }
    
    public List<Car>? Cars { get; set; }
    
    public List<Trailer>? Trailers { get; set; }
    
    public int UserId { get; set; }
}