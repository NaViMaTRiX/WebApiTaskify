﻿namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class OrgLimitRepository(AppDbContext context) : IOrgLimitRepository
{
    public async Task<List<OrgLimits>> GetAllAsync(CancellationToken token)
    {
        return await context.OrgLimit.ToListAsync(token);
    }

    public async Task<OrgLimits?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await context.OrgLimit.SingleOrDefaultAsync(x =>x.Id == id, token);
    }

    public async Task<OrgLimits?> CreateAsync(OrgLimits listModel, CancellationToken token)
    {
        await context.OrgLimit.AddAsync(listModel, token);
        await context.SaveChangesAsync(token);
        return listModel;
    }

    public async Task<OrgLimits?> UpdateAsync(Guid id, OrgLimits listModel, CancellationToken token)
    {
        var orgLimit = await GetByIdAsync(id, token);
        
        if (orgLimit is null)
            return null;
        
        orgLimit.Count = listModel.Count;
        orgLimit.LastModifyTime = listModel.LastModifyTime;
        await context.SaveChangesAsync(token);
        return orgLimit;
    }

    public async Task<OrgLimits?> DeleteAsync(Guid id, CancellationToken token)
    {
        var orgLimit = await GetByIdAsync(id, token);
        if (orgLimit is null)
            return null;
        
        context.OrgLimit.Remove(orgLimit);
        await context.SaveChangesAsync(token);
        return orgLimit;
    }

    public Task<bool> ExistAsync(Guid id, CancellationToken token)
    {
        return context.OrgLimit.AnyAsync(x => x.Id == id, token);
    }
}