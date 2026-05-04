using System.ComponentModel.DataAnnotations;

namespace Model;

public class TrailerInspection
{
    [Key]
    public int Id { get; set; }
    
    public DateTime DateOfInpection { get; set; }
    public DateTime ValidUntil { get; set; }
    
    public int TrailerId { get; set; }
}