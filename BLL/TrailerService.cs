using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL;

public class TrailerService : ITrailerService
{
    private readonly ITrailerRepository _repository;

    public TrailerService(ITrailerRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<Trailer>> GetAllTrailers()
    {
        List<Trailer> result = (List<Trailer>)await _repository.GetAll();
        return result;
    }

    public async Task<List<Trailer>> GetTrailersByBranchId(int branchId)
    {
        var result = await _repository.GetAll();
        return result.Where(t => t.BranchId == branchId).ToList();
    }

    public async Task<Trailer> GetTrailerById(int id)
    {
        Trailer trailer = await _repository.GetById(id);
        return trailer;
    }

    public async Task AddTrailer(Trailer trailer)
    {
        await _repository.Add(trailer);
    }

    public async Task UpdateTrailer(Trailer trailer, int id)
    {
        Trailer toUpdate = await _repository.GetById(id);

        toUpdate.Plate = trailer.Plate;
        toUpdate.Capacity = trailer.Capacity;
        toUpdate.InspectionId = trailer.InspectionId;
        toUpdate.AgregatInspectionId = trailer.AgregatInspectionId;
        toUpdate.FuelLevel = trailer.FuelLevel;
        toUpdate.BranchId = trailer.BranchId;
        toUpdate.IsBlocked = trailer.IsBlocked;

        await _repository.Update(toUpdate);
    }

    public async Task DeleteTrailer(int trailerId)
    {
        Trailer trailer = await _repository.GetById(trailerId);
        
        await _repository.Delete(trailer);
    }

    public async Task<IEnumerable<TrailerInspection>> GetAllInspectionsByTrailerId(int trailerId)
    {
        var result = await _repository.GetAllInspections();
        
        return result.Where(i => i.TrailerId == trailerId);
    }

    public async Task AddInspection(TrailerInspection trailerInspection)
    {
        await _repository.Add(trailerInspection);
    }

    public async Task UpdateInspection(TrailerInspection trailerInspection, int id)
    {
        TrailerInspection existingInspection = await _repository.GetInspectionById(id);
        
        existingInspection.DateOfInspection = trailerInspection.DateOfInspection;
        existingInspection.ValidUntil = trailerInspection.ValidUntil;
        existingInspection.TrailerId = trailerInspection.TrailerId;
        
        await _repository.Update(existingInspection);
    }

    public async Task DeleteInspection(int trailerInspection)
    {   
        await _repository.DeleteInspection(await _repository.GetInspectionById(trailerInspection));
    }

    public async Task<List<TrailerRefrigeratorInspections>> GetAllRefrigeratorInspections()
    {
        var result = await _repository.GetAllAgregatInspections();
        return result.ToList();
    }

    public async Task<IEnumerable<TrailerRefrigeratorInspections>> GetAllRefrigeratorInspectionsByTrailerId(int trailerId)
    {
        var result = await _repository.GetAllAgregatInspections();
        return result.Where(i => i.TrailerId == trailerId);
    }

    public async Task<TrailerRefrigeratorInspections> GetRefrigeratorInspectionById(int id)
    {
        var result = await _repository.GetRefrigeratorInspectionById(id);
        return result;
    }

    public async Task AddRefrigeratorInspection(TrailerRefrigeratorInspections trailerRefrigeratorInspections)
    {
        TrailerRefrigeratorInspections newInspection = new TrailerRefrigeratorInspections()
        {
            DateOfInspection = trailerRefrigeratorInspections.DateOfInspection,
            ValidUntil = trailerRefrigeratorInspections.ValidUntil,
            MotoHours = trailerRefrigeratorInspections.MotoHours,
            TrailerId = trailerRefrigeratorInspections.TrailerId
        };

        await _repository.Add(newInspection);
    }

    public async Task UpdateRefrigeratorInspection(TrailerRefrigeratorInspections trailerRefrigeratorInspections, int id)
    {
        TrailerRefrigeratorInspections existingInspection = await _repository.GetRefrigeratorInspectionById(id);
        
        existingInspection.DateOfInspection = trailerRefrigeratorInspections.DateOfInspection;
        existingInspection.ValidUntil = trailerRefrigeratorInspections.ValidUntil;
        existingInspection.TrailerId = trailerRefrigeratorInspections.TrailerId;
        
        await _repository.Update(existingInspection);
    }

    public async Task DeleteRefrigeratorInspection(int trailerRefrigeratorInspections)
    {
        await _repository.DeleteAgregatInspection(await _repository.GetRefrigeratorInspectionById(trailerRefrigeratorInspections));
    }
}