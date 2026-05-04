using Model;

namespace DAL.Dto;

public class TrailerDto
{
    public string Plate { get; set; }
    public int Capacity { get; set; }
    public int FuelLevel { get; set; }
    public bool IsBlocked { get; set; }
    public List<TrailerInspection>? InspectionId { get; set; }
    public List<TrailerRefrigeratorInspections>? AgregatInspectionsId { get; set; }
    public int BranchId { get; set; }
}