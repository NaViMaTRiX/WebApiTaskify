namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class ListRepository : IListRepository
{
    private readonly AppDbContext _context;

    public ListRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<List>> GetAllAsync()
    {
        return await _context.List.ToListAsync();
    }

    public async Task<List?> GetByIdAsync(Guid id)
    {
        return await _context.List.SingleOrDefaultAsync(x => x.id == id);
    }

    public async Task<List?> CreateAsync(List listModel)
    {
        await _context.List.AddAsync(listModel);
        await _context.SaveChangesAsync();
        return listModel;
    }

    public async Task<List?> UpdateAsync(Guid id, List listModel)
    {
        var list = await GetByIdAsync(id);
        
        if (list is null) 
            return null;
        
        list.title = listModel.title;
        list.order = listModel.order;
        list.updatedAt = listModel.updatedAt;
        
        await _context.SaveChangesAsync();
        
        return list;
    }

    public async Task<List?> DeleteAsync(Guid id)
    {
        var list = await GetByIdAsync(id);
        if (list is null)
            return null;
        
        _context.List.Remove(list);
        await _context.SaveChangesAsync();
        return list;
    }

    public async Task<bool> ExistAsync(Guid id)
    {
        return await _context.List.AnyAsync(x => x.id == id);
    }
}