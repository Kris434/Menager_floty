using Model;

namespace DAL.Interfaces;

public interface ITrailerRepository
{
    // Trailer functions
    Task Add(Trailer trailer);
    Task Update(Trailer trailer);
    Task Delete(Trailer trailer);
    Task<Trailer> GetById(int id);
    Task<IEnumerable<Trailer>> GetAll();
    
    // Trailer inspections
    Task Add(TrailerInspection trailerInspection);
    Task Update(TrailerInspection trailerInspection);
    Task DeleteInspection(TrailerInspection trailer);
    Task<IEnumerable<TrailerInspection>> GetAllInspections();
    
    // Trailer agregat inspections
    Task Add(TrailerRefrigeratorInspections trailerRefrigeratorInspections);
    Task Update(TrailerRefrigeratorInspections trailerRefrigeratorInspections);
    Task DeleteAgregatInspection(TrailerRefrigeratorInspections trailerRefrigeratorInspections);
    Task<IQueryable<TrailerRefrigeratorInspections>> GetAllAgregatInspections();
}