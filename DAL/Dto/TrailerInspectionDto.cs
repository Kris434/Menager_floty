namespace DAL.Dto;

public class TrailerInspectionDto
{
    public DateTime DateOfInpection { get; set; }
    public DateTime ValidUntil { get; set; }
    public int TrailerId { get; set; }
}