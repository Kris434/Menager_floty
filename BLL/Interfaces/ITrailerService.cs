using Model;

namespace BLL.Interfaces;

public interface ITrailerService
{
    // Trailer functions
    Task<List<Trailer>> GetAllTrailers();
    Task<Trailer> GetTrailerById(int id);
    Task AddTrailer(Trailer trailer);
    Task UpdateTrailer(Trailer trailer, int id);
    Task DeleteTrailer(int trailerId);
    
    // Trailer inspection functions
    Task AddInspection(TrailerInspection trailerInspection);
    Task UpdateInspection(TrailerInspection trailerInspection);
    Task DeleteInspection(TrailerInspection trailerInspection);
}