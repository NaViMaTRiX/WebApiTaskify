namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class AuditLogRepository : IAuditLogRepository
{
    private readonly AppDbContext _context;

    public AuditLogRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AuditLogs>> GetAllAsync(CancellationToken token)
    {
        return await _context.AuditLog.ToListAsync(token);
    }

    public async Task<AuditLogs?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _context.AuditLog.SingleOrDefaultAsync(x => x.id == id, token);
    }

    public async Task<AuditLogs?> CreateAsync(AuditLogs boardsModel, CancellationToken token)
    {
        await _context.AuditLog.AddAsync(boardsModel, token);
        await _context.SaveChangesAsync(token);
        return boardsModel;
    }

    public async Task<AuditLogs?> DeleteAsync(Guid id, CancellationToken token)
    {
        var audit = await _context.AuditLog.SingleOrDefaultAsync(x => x.id == id, token);
        if (audit is null)
            return null;
        
        _context.AuditLog.Remove(audit);
        await _context.SaveChangesAsync(token);
        return audit;
    }

    public async Task<bool> ExistAsync(Guid id, CancellationToken token)
    {
        return await _context.AuditLog.AnyAsync(x => x.id == id, token);
    }
}