using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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
    
    public List<User> Users { get; set; } = new List<User>();
}