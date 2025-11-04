using System.ComponentModel.DataAnnotations;

namespace Model;

public class Cars
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Plate { get; set; }
}