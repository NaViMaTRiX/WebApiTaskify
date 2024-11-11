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

    public async Task<List<AuditLog>> GetAllAsync()
    {
        return await _context.AuditLog.ToListAsync();
    }

    public async Task<AuditLog?> GetByIdAsync(Guid id)
    {
        return await _context.AuditLog.SingleOrDefaultAsync(x => x.id == id);
    }

    public async Task<AuditLog?> CreateAsync(AuditLog boardsModel)
    {
        await _context.AuditLog.AddAsync(boardsModel);
        await _context.SaveChangesAsync();
        return boardsModel;
    }

    public async Task<AuditLog?> DeleteAsync(Guid id)
    {
        var audit = await _context.AuditLog.SingleOrDefaultAsync(x => x.id == id);
        if (audit is null)
            return null;
        
        _context.AuditLog.Remove(audit);
        await _context.SaveChangesAsync();
        return audit;
    }

    public async Task<bool> ExistAsync(Guid id)
    {
        return await _context.AuditLog.AnyAsync(x => x.id == id);
    }
}