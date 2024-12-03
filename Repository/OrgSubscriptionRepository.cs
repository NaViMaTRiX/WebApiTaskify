namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class OrgSubscriptionRepository : IOrgSubscriptionRepository
{
    private readonly AppDbContext _context;
    
    public OrgSubscriptionRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<OrgSubscriptions>> GetAllAsync(CancellationToken token)
    {
        return await _context.OrgSubscription.ToListAsync(token);
    }

    public async Task<OrgSubscriptions?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _context.OrgSubscription.SingleOrDefaultAsync(x => x.Id == id, token);
    }

    public async Task<OrgSubscriptions?> CreateAsync(OrgSubscriptions listModel, CancellationToken token)
    {
        await _context.OrgSubscription.AddAsync(listModel, token);
        await _context.SaveChangesAsync(token);
        return listModel;
    }

    public async Task<OrgSubscriptions?> DeleteAsync(Guid id, CancellationToken token)
    {
        var listModel = await GetByIdAsync(id, token);

        if (listModel is null)
            return null;
        
        _context.OrgSubscription.Remove(listModel);
        await _context.SaveChangesAsync(token);
        return listModel;
    }

    public async Task<bool> ExistAsync(Guid id, CancellationToken token)
    {
        return await _context.OrgSubscription.AnyAsync(x => x.Id == id, token);
    }
}