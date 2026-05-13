using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace Model;

public class Branch
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string BranchName { get; set; }
    
    public List<Car>? Cars { get; set; }
    
    
    public List<Trailer>? Trailers { get; set; }
    
    public List<Tasks>? Tasks { get; set; }
    
    public int UserId { get; set; }
}