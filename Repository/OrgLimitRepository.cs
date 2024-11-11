namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class OrgLimitRepository : IOrgLimitRepository
{
    private readonly AppDbContext _context;

    public OrgLimitRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<OrgLimit>> GetAllAsync()
    {
        return await _context.OrgLimit.ToListAsync();
    }

    public async Task<OrgLimit?> GetByIdAsync(Guid id)
    {
        return await _context.OrgLimit.SingleOrDefaultAsync(x =>x.id == id);
    }

    public async Task<OrgLimit?> CreateAsync(OrgLimit listModel)
    {
        await _context.OrgLimit.AddAsync(listModel);
        await _context.SaveChangesAsync();
        return listModel;
    }

    public async Task<OrgLimit?> UpdateAsync(Guid id, OrgLimit listModel)
    {
        var orgLimit = await GetByIdAsync(id);
        
        if (orgLimit is null)
            return null;
        
        orgLimit.count = listModel.count;
        orgLimit.updatedAt = listModel.updatedAt;
        await _context.SaveChangesAsync();
        return orgLimit;
    }

    public async Task<OrgLimit?> DeleteAsync(Guid id)
    {
        var orgLimit = await GetByIdAsync(id);
        if (orgLimit is null)
            return null;
        
        _context.OrgLimit.Remove(orgLimit);
        await _context.SaveChangesAsync();
        return orgLimit;
    }

    public Task<bool> ExistAsync(Guid id)
    {
        return _context.OrgLimit.AnyAsync(x => x.id == id);
    }
}