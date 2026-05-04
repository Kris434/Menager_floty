using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Model;

public class Trailer
{
    [Key]
    public int Id { get; set; }
    
    public int Capacity { get; set; }
    
    public int FuelLevel { get; set; }
    
    public string Plate { get; set; }
    
    public bool IsBlocked { get; set; }
    
    public List<TrailerInspection>? InspectionId { get; set; }
    
    public List<TrailerRefrigeratorInspections>? AgregatInspectionId { get; set; }
    
    public int BranchId { get; set; }
}