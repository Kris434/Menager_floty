using System.ComponentModel.DataAnnotations;

namespace Model;

public class Car
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Plate { get; set; }
    
    public List<CarInspection>? InspectionId { get; set; }

    public int BranchId { get; set; }
}