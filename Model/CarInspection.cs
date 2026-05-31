using System.ComponentModel.DataAnnotations;

namespace Model;

public class CarInspection
{
    [Key]
    public int Id { get; set; }
    public int Mileage { get; set; }
    public DateTime DateOfInspection { get; set; }
    public DateTime ValidUntil { get; set; }
    public int CarId { get; set; }
}