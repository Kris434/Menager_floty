namespace Model;

public class TrailerRefrigeratorInspections
{
    public int Id { get; set; }
    public DateTime DateOfIncpection { get; set; }
    public DateTime ValidUntil { get; set; }
    public int MotoHours { get; set; }
    public int TrailerId { get; set; }
}