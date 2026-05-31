using Model;

namespace DAL.Interfaces;

public interface IBranchRepository
{
    Task<IEnumerable<Branch>> GetAll();
    Task<Branch> GetById(int id);
    Task Add(Branch branch);
    Task Update(Branch branch);
    Task Delete(Branch branch);
    Task DeleteUserFromBranch(int userId, int branchId);
}