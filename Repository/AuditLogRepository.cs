﻿namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class AuditLogRepository(AppDbContext context) : IAuditLogRepository
{
    public async Task<List<AuditLogs>> GetAllAsync(CancellationToken token)
    {
        return await context.AuditLog.ToListAsync(token);
    }

    public async Task<AuditLogs?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await context.AuditLog.SingleOrDefaultAsync(x => x.Id == id, token);
    }

    public async Task<AuditLogs?> CreateAsync(AuditLogs boardsModel, CancellationToken token)
    {
        await context.AuditLog.AddAsync(boardsModel, token);
        await context.SaveChangesAsync(token);
        return boardsModel;
    }

    public async Task<AuditLogs?> DeleteAsync(Guid id, CancellationToken token)
    {
        var audit = await context.AuditLog.SingleOrDefaultAsync(x => x.Id == id, token);
        if (audit is null)
            return null;
        
        context.AuditLog.Remove(audit);
        await context.SaveChangesAsync(token);
        return audit;
    }

    public async Task<bool> ExistAsync(Guid id, CancellationToken token)
    {
        return await context.AuditLog.AnyAsync(x => x.Id == id, token);
    }
}