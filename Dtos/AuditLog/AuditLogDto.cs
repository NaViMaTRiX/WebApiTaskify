using WebApiTaskify.Models.Enum;

namespace WebApiTaskify.Dtos.AuditLog;

public class AuditLogDto
{
    public string Id { get; set; }
    public string OrgId { get; set; }
    public ACTION Action { get; set; }
    public string EntityId { get; set; }
    public string EntityTitle { get; set; }
    public ENTITY_TYPE EntityType { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string UserImage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}