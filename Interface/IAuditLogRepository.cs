namespace WebApiTaskify.Interface;

using Models;

public interface IAuditLogRepository
{
    Task<List<AuditLog>> GetAllAsync(); // TODO: Add pagination
    Task<AuditLog?> GetByIdAsync(Guid id);
    Task<AuditLog?> CreateAsync(AuditLog boardsModel);
    Task<AuditLog?> DeleteAsync(Guid id);
    Task<bool> ExistAsync(Guid id);
}