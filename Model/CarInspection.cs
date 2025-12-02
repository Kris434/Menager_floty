namespace Model;

public class CarInspection
{
    public int Id { get; set; }
    public int Mileage { get; set; }
    public DateTime DateOfInpection { get; set; }
    public DateTime ValidUntil { get; set; }
    public int CarId { get; set; }
}