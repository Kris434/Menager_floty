using Model;

namespace BLL.Interfaces;

public interface IBranchService
{
    Task<List<Branch>> GetAll();
    Task<Branch> GetById(int id);
    Task Add(Branch branch);
    Task Update(Branch branch, int id);
    Task Delete(int id);
}