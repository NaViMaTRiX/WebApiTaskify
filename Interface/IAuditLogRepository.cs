namespace WebApiTaskify.Interface;

using Models;

public interface IAuditLogRepository
{
    Task<List<AuditLog>> GetAllAsync(CancellationToken token); // TODO: Add pagination
    Task<AuditLog?> GetByIdAsync(Guid id, CancellationToken token);
    Task<AuditLog?> CreateAsync(AuditLog boardsModel, CancellationToken token);
    Task<AuditLog?> DeleteAsync(Guid id, CancellationToken token);
    Task<bool> ExistAsync(Guid id, CancellationToken token);
}