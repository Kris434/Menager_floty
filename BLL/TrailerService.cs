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

    public Task AddInspection(TrailerInspection trailerInspection)
    {
        throw new NotImplementedException();
    }

    public Task UpdateInspection(TrailerInspection trailerInspection)
    {
        throw new NotImplementedException();
    }

    public Task DeleteInspection(TrailerInspection trailerInspection)
    {
        throw new NotImplementedException();
    }
}