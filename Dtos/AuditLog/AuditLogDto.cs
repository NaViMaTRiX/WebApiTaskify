namespace WebApiTaskify.Dtos.AuditLog;

public class AuditLogDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string OrgId { get; set; } = String.Empty;
    public string Action { get; set; } = String.Empty;
    public Guid EntityId { get; set; } = Guid.Empty;
    public string EntityTitle { get; set; } = String.Empty;
    public string EntityType { get; set; } = String.Empty;
    public string UserId { get; set; } = String.Empty;
    public string UserName { get; set; } = String.Empty;
    public string UserImage { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}