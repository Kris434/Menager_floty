using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Model;

public class Users
{
    [Key]
    public int Id { get; set; } 
    
    [Required]
    [MaxLength(50)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Password { get; set; }
    
    [MaxLength(50)]
    public string? FirstName { get; set; }
    
    [MaxLength(50)]
    public string? LastName { get; set; }
}