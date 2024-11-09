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


    public async Task<List<OrgSubscription>> GetAllAsync()
    {
        return await _context.OrgSubscription.ToListAsync();
    }

    public async Task<OrgSubscription?> GetByIdAsync(string id)
    {
        return await _context.OrgSubscription.SingleOrDefaultAsync(x => x.id == id);
    }

    public async Task<OrgSubscription?> CreateAsync(OrgSubscription listModel)
    {
        await _context.OrgSubscription.AddAsync(listModel);
        await _context.SaveChangesAsync();
        return listModel;
    }

    public async Task<OrgSubscription?> DeleteAsync(string id)
    {
        var listModel = await GetByIdAsync(id);

        if (listModel is null)
            return null;
        
        _context.OrgSubscription.Remove(listModel);
        await _context.SaveChangesAsync();
        return listModel;
    }

    public async Task<bool> ExistAsync(string id)
    {
        return await _context.OrgSubscription.AnyAsync(x => x.id == id);
    }
}