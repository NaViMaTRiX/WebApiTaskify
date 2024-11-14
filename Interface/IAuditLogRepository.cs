﻿namespace WebApiTaskify.Interface;

using Models;

public interface IAuditLogRepository
{
    Task<List<AuditLogs>> GetAllAsync(CancellationToken token); // TODO: Add pagination
    Task<AuditLogs?> GetByIdAsync(Guid id, CancellationToken token);
    Task<AuditLogs?> CreateAsync(AuditLogs boardsModel, CancellationToken token);
    Task<AuditLogs?> DeleteAsync(Guid id, CancellationToken token);
    Task<bool> ExistAsync(Guid id, CancellationToken token);
}