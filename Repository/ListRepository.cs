﻿namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class ListRepository(AppDbContext context) : IListRepository
{
    public async Task<List<Lists>> GetAllAsync(CancellationToken token)
    {
        return await context.List.Include(p => p.Cards).ToListAsync(token);
    }

    public async Task<Lists?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await context.List
            .Include(x => x.Cards)
            .FirstOrDefaultAsync(x => x.Id == id, token);
    }

    public async Task<Lists?> CreateAsync(Lists listModel, CancellationToken token)
    {
        await context.List.AddAsync(listModel, token);
        await context.SaveChangesAsync(token);
        return listModel;
    }

    public async Task<Lists?> UpdateAsync(Guid id, Lists listModel, CancellationToken token)
    {
        var list = await GetByIdAsync(id, token);
        
        if (list is null) 
            return null;
        
        list.Title = listModel.Title;
        list.Order = listModel.Order;
        list.LastModifyTime = listModel.LastModifyTime;
        
        await context.SaveChangesAsync(token);
        return list;
    }

    public async Task<Lists?> DeleteAsync(Guid id, CancellationToken token)
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
        return await context.List.AnyAsync(x => x.Id == id, token);
    }
}