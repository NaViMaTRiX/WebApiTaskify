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

    public async Task<List<OrgLimit>> GetAllAsync(CancellationToken token)
    {
        return await _context.OrgLimit.ToListAsync(token);
    }

    public async Task<OrgLimit?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _context.OrgLimit.SingleOrDefaultAsync(x =>x.id == id, token);
    }

    public async Task<OrgLimit?> CreateAsync(OrgLimit listModel, CancellationToken token)
    {
        await _context.OrgLimit.AddAsync(listModel, token);
        await _context.SaveChangesAsync(token);
        return listModel;
    }

    public async Task<OrgLimit?> UpdateAsync(Guid id, OrgLimit listModel, CancellationToken token)
    {
        var orgLimit = await GetByIdAsync(id, token);
        
        if (orgLimit is null)
            return null;
        
        orgLimit.count = listModel.count;
        orgLimit.updatedAt = listModel.updatedAt;
        await _context.SaveChangesAsync(token);
        return orgLimit;
    }

    public async Task<OrgLimit?> DeleteAsync(Guid id, CancellationToken token)
    {
        var orgLimit = await GetByIdAsync(id, token);
        if (orgLimit is null)
            return null;
        
        _context.OrgLimit.Remove(orgLimit);
        await _context.SaveChangesAsync(token);
        return orgLimit;
    }

    public Task<bool> ExistAsync(Guid id, CancellationToken token)
    {
        return _context.OrgLimit.AnyAsync(x => x.id == id, token);
    }
}