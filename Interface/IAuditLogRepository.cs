namespace WebApiTaskify.Interface;

using Models;

public interface IAuditLogRepository
{
    Task<List<AuditLog>> GetAllAsync(); // TODO: Add pagination
    Task<AuditLog?> GetByIdAsync(string id);
    Task<AuditLog?> CreateAsync(AuditLog boardsModel);
    Task<AuditLog?> DeleteAsync(string id);
    //Task<bool> ExistAsync(Guid id);
}