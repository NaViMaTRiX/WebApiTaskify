namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class OrgSubscriptionRepository : IOrgSubscriptionRepository
{
    private readonly AppDBContext _context;
    
    public OrgSubscriptionRepository(AppDBContext context)
    {
        _context = context;
    }


    public async Task<List<OrgSubscriptions>> GetAllAsync()
    {
        return await _context.OrgSubscriptions.ToListAsync();
    }

    public async Task<OrgSubscriptions?> GetByIdAsync(Guid id)
    {
        return await _context.OrgSubscriptions.FindAsync(id);
    }

    public async Task<OrgSubscriptions?> CreateAsync(OrgSubscriptions listModel)
    {
        await _context.OrgSubscriptions.AddAsync(listModel);
        await _context.SaveChangesAsync();
        return listModel;
    }

    public async Task<OrgSubscriptions?> DeleteAsync(Guid id)
    {
        var listModel = _context.OrgSubscriptions.Find(id);

        if (listModel is null)
            return null;
        
        _context.OrgSubscriptions.Remove(listModel);
        await _context.SaveChangesAsync();
        return listModel;
    }

    public async Task<bool> ExistAsync(Guid id)
    {
        return await _context.OrgSubscriptions.AnyAsync(x => x.Id == id);
    }
}