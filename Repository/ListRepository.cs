namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class ListRepository(AppDbContext context) : IListRepository
{
    public async Task<List<List>> GetAllAsync(CancellationToken token)
    {
        return await context.List.Include(p => p.cards).ToListAsync(token);
    }

    public async Task<List?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await context.List
            .Include(x => x.cards)
            .FirstOrDefaultAsync(x => x.id == id, token);
    }

    public async Task<List?> CreateAsync(List listModel, CancellationToken token)
    {
        await context.List.AddAsync(listModel, token);
        await context.SaveChangesAsync(token);
        return listModel;
    }

    public async Task<List?> UpdateAsync(Guid id, List listModel, CancellationToken token)
    {
        var list = await GetByIdAsync(id, token);
        
        if (list is null) 
            return null;
        
        list.title = listModel.title;
        list.order = listModel.order;
        list.updatedAt = listModel.updatedAt;
        
        await context.SaveChangesAsync(token);
        
        return list;
    }

    public async Task<List?> DeleteAsync(Guid id, CancellationToken token)
    {
        var list = await GetByIdAsync(id, token);
        if (list is null)
            return null;
        
        context.List.Remove(list);
        await context.SaveChangesAsync(token);
        return list;
    }

    public async Task<bool> ExistAsync(Guid id, CancellationToken token)
    {
        return await context.List.AnyAsync(x => x.id == id, token);
    }
}