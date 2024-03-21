namespace WebApiTaskify.Repository;

using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public class AuditLogRepository : IAuditLogRepository
{
    private readonly AppDBContext _context;

    public AuditLogRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<List<AuditLogs>> GetAllAsync()
    {
        return await _context.AuditLogs.ToListAsync();
    }

    public async Task<AuditLogs?> GetByIdAsync(Guid id)
    {
        return await _context.AuditLogs.FindAsync(id);
    }

    public async Task<AuditLogs?> CreateAsync(AuditLogs boardsModel)
    {
        await _context.AuditLogs.AddAsync(boardsModel);
        await _context.SaveChangesAsync();
        return boardsModel;
    }

    public async Task<AuditLogs?> DeleteAsync(Guid id)
    {
        var audit = await _context.AuditLogs.FindAsync(id);

        if (audit is null)
            return null;
        
        _context.AuditLogs.Remove(audit);
        await _context.SaveChangesAsync();
        return audit;
    }

    public async Task<bool> ExistAsync(Guid id)
    {
        return await _context.AuditLogs.AnyAsync(x => x.Id == id);
    }
}