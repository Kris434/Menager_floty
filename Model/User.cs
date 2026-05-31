using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Model;

public class User
{
    [Key]
    public int Id { get; set; } 
    
    [Required]
    [MaxLength(50)]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    public string Login { get; set; }
    
    public string Role { get; set; }
    
    [MaxLength(50)]
    public string? FirstName { get; set; }
    
    [MaxLength(50)]
    public string? LastName { get; set; }
    
    public List<Branch> Branches { get; set; } = new List<Branch>();
}