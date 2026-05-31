using Model;

namespace BLL.Interfaces;

public interface ITrailerService
{
    // Trailer functions
    Task<List<Trailer>> GetAllTrailers();
    Task<Trailer> GetTrailerById(int id);
    Task<List<Trailer>> GetTrailersByBranchId(int branchId);
    Task AddTrailer(Trailer trailer);
    Task UpdateTrailer(Trailer trailer, int id);
    Task DeleteTrailer(int trailerId);
    
    // Trailer inspection functions
    Task<IEnumerable<TrailerInspection>> GetAllInspectionsByTrailerId(int trailerId);
    Task AddInspection(TrailerInspection trailerInspection);
    Task UpdateInspection(TrailerInspection trailerInspection, int id);
    Task DeleteInspection(int trailerInspection);
    
    // Trailer agregat inspection functions
    Task<List<TrailerRefrigeratorInspections>> GetAllRefrigeratorInspections();
    Task<IEnumerable<TrailerRefrigeratorInspections>> GetAllRefrigeratorInspectionsByTrailerId(int trailerId);
    Task<TrailerRefrigeratorInspections> GetRefrigeratorInspectionById(int id);
    Task AddRefrigeratorInspection(TrailerRefrigeratorInspections trailerRefrigeratorInspections);
    Task UpdateRefrigeratorInspection(TrailerRefrigeratorInspections trailerRefrigeratorInspections, int id);
    Task DeleteRefrigeratorInspection(int trailerRefrigeratorInspections);
    
}