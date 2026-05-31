using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL;

public class BranchRepository : IBranchRepository
{
    private readonly AppDbContext _context;
    
    public BranchRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Branch>> GetAll()
    {
        var result = _context.Branches
            .Include(b => b.Users)
            .Include(b => b.Cars)!
            .ThenInclude(c => c.InspectionId)
            .Include(b => b.Trailers)!
            .ThenInclude(t => t.InspectionId)
            .Include(b => b.Trailers)!
            .ThenInclude(t => t.AgregatInspectionId)
            .Include(b => b.Tasks)
            .AsSplitQuery();
        
        return result;
    }

    public async Task<Branch> GetById(int id)
    {
        var result = await _context.Branches
            .Include(b => b.Users)
            .Include(b => b.Cars)!
            .ThenInclude(c => c.InspectionId)
            .Include(b => b.Trailers)!
            .ThenInclude(t => t.InspectionId)
            .Include(b => b.Trailers)!
            .ThenInclude(t => t.AgregatInspectionId)
            .Include(b => b.Tasks)
            .AsSplitQuery()
            .FirstOrDefaultAsync(b => b.Id == id);
        return result;
    }

    public async Task Add(Branch branch)
    {
        _context.Branches.Add(branch);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Branch branch)
    {
        Branch existingBranch = await _context.Branches.FindAsync(branch.Id);

        existingBranch.BranchName = branch.BranchName;
        existingBranch.Cars = branch.Cars;
        existingBranch.Trailers = branch.Trailers;
        existingBranch.Users = branch.Users;
        existingBranch.Tasks = branch.Tasks;
        
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Branch branch)
    {
        _context.Branches.Remove(branch);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserFromBranch(int userId, int branchId)
    {
        var branch = await _context.Branches.Include(b => b.Users).FirstOrDefaultAsync(b => b.Id == branchId);

        var user = branch.Users.FirstOrDefault(u => u.Id == userId);
        
        branch.Users.Remove(user);
        
        await _context.SaveChangesAsync();
    }
}