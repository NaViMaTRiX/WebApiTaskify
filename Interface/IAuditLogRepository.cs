namespace WebApiTaskify.Interface;

using Models;

public interface IAuditLogRepository
{
    Task<List<AuditLogs>> GetAllAsync(); // TODO: Add pagination
    Task<AuditLogs?> GetByIdAsync(Guid id);
    Task<AuditLogs?> CreateAsync(AuditLogs boardsModel);
    Task<AuditLogs?> DeleteAsync(Guid id);
    //Task<bool> ExistAsync(Guid id);
}