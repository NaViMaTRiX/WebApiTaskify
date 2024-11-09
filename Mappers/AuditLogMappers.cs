using Asp.Versioning;

namespace WebApiTaskify.Mappers;

using Dtos.AuditLog;
using Models;

public static class AuditLogMappers
{
    public static AuditLogDto ToAuditLogDto(this AuditLog auditLog)
    {
        return new AuditLogDto
        {
            Id = auditLog.id,
            OrgId = auditLog.orgId,
            UserId = auditLog.userId,
            UserName = auditLog.userName,
            UserImage = auditLog.userImage,
            Action = auditLog.action,
            EntityId = auditLog.entityId,
            EntityTitle = auditLog.entityTitle,
            EntityType = auditLog.entityType,
            CreatedAt = auditLog.createdAt,
            UpdatedAt = auditLog.updatedAt
        };
    }

    public static AuditLog ToAuditLogsFromCreate(this CreateAuditLogDto createAuditLog)
    {
        return new AuditLog
        {
            id = Guid.NewGuid().ToString(),
            orgId = createAuditLog.OrgId,
            userId = createAuditLog.UserId,
            userName = createAuditLog.UserName,
            userImage = createAuditLog.UserImage,
            action = createAuditLog.Action,
            entityId = createAuditLog.EntityId,
            entityTitle = createAuditLog.EntityTitle,
            entityType = createAuditLog.EntityType,
        };
    }
}