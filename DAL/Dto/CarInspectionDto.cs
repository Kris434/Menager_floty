namespace DAL.Dto;

public class CarInspectionDto
{
    public DateTime DateOfInpection { get; set; }
    public DateTime ValidUntil { get; set; }
    public int Mileage { get; set; }
    public int CarId { get; set; }
}