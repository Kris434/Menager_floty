namespace Model;

public class TrailerRefrigeratorInspections
{
    public int Id { get; set; }
    public DateTime DateOfInspection { get; set; }
    public DateTime ValidUntil { get; set; }
    public int MotoHours { get; set; }
    public int TrailerId { get; set; }
}