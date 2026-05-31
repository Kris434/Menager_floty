namespace DAL.Dto;

public class TrailerRefrigeratorInspectionDto
{
    public DateTime DateOfInspection { get; set; }
    public DateTime ValidUntil { get; set; }
    public int MotoHours { get; set; }
    public int TrailerId { get; set; }
}