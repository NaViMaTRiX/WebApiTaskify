namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class ListRepository : IListRepository
{
    private readonly AppDBContext _context;

    public ListRepository(AppDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<Lists>> GetAllAsync()
    {
        return await _context.Lists.ToListAsync();
    }

    public async Task<Lists?> GetByIdAsync(Guid id)
    {
        return await _context.Lists.FindAsync(id);
    }

    public async Task<Lists?> CreateAsync(Guid boardId, Lists listModel)
    {
        await _context.Lists.AddAsync(listModel);
        await _context.SaveChangesAsync();
        return listModel;
    }

    public async Task<Lists?> UpdateAsync(Guid id, Lists listModel)
    {
        var list = await _context.Lists.FindAsync(id);
        
        if (list is null) 
            return null;
        
        list.Title = listModel.Title;
        list.Order = listModel.Order;
        list.UpdatedAt = listModel.UpdatedAt;
        
        await _context.SaveChangesAsync();
        
        return list;
    }

    public async Task<Lists?> DeleteAsync(Guid id)
    {
        var list = await _context.Lists.FindAsync(id);
        if (list is null)
            return null;
        
        _context.Lists.Remove(list);
        await _context.SaveChangesAsync();
        return list;
    }

    public async Task<bool> ExistAsync(Guid id)
    {
        return await _context.Lists.AnyAsync(x => x.Id == id);
    }
}