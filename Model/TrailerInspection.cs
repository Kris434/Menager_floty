using System.ComponentModel.DataAnnotations;

namespace Model;

public class TrailerInspection
{
    [Key]
    public int Id { get; set; }
    
    public DateTime DateOfInspection { get; set; }
    public DateTime ValidUntil { get; set; }
    
    public int TrailerId { get; set; }
}