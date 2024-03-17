namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class OrgLimisRepository : IOrgLimitRepository
{
    private readonly AppDBContext _context;

    public OrgLimisRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<List<OrgLimits>> GetAllAsync()
    {
        return await _context.OrgLimits.ToListAsync();
    }

    public async Task<OrgLimits?> GetByIdAsync(Guid id)
    {
        return await _context.OrgLimits.FindAsync(id);
    }

    public async Task<OrgLimits?> CreateAsync(OrgLimits listModel)
    {
        await _context.OrgLimits.AddAsync(listModel);
        await _context.SaveChangesAsync();
        return listModel;
    }

    public async Task<OrgLimits?> UpdateAsync(Guid id, OrgLimits listModel)
    {
        var orgLimit = await _context.OrgLimits.FindAsync(id);
        
        if (orgLimit is null)
            return null;
        
        orgLimit.Limit = listModel.Limit;
        orgLimit.UpdatedAt = listModel.UpdatedAt;
        await _context.SaveChangesAsync();
        return orgLimit;
    }

    public async Task<OrgLimits?> DeleteAsync(Guid id)
    {
        var orgLimit = await _context.OrgLimits.FindAsync(id);
        if (orgLimit is null)
            return null;
        _context.OrgLimits.Remove(orgLimit);
        await _context.SaveChangesAsync();
        return orgLimit;
    }

    public Task<bool> ExistAsync(Guid id)
    {
        return _context.OrgLimits.AnyAsync(x => x.Id == id);
    }
}