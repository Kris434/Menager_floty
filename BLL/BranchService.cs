using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL;

public class BranchService(IBranchRepository repository) : IBranchService
{
    private readonly IBranchRepository _repository = repository;
    
    public async Task<List<Branch>> GetAll()
    {
        var result = await _repository.GetAll();
        
        return result.ToList();
    }

    public async Task<Branch> GetById(int id)
    {
        var result = await _repository.GetById(id);
        
        return result;
    }

    public async Task Add(Branch branch)
    {
        await _repository.Add(branch);
    }

    public async Task Update(Branch branch, int id)
    {
        Branch toUpdate = _repository.GetById(id).Result;
        
        toUpdate.BranchName = branch.BranchName;
        toUpdate.Tasks = branch.Tasks;
        toUpdate.Trailers = branch.Trailers;
        toUpdate.Cars = branch.Cars;
        toUpdate.UserId = branch.UserId;
        
        await _repository.Update(toUpdate);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(await _repository.GetById(id));
    }
}