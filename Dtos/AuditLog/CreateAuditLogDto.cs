using WebApiTaskify.Models.Enum;

namespace WebApiTaskify.Dtos.AuditLog;

using System.ComponentModel.DataAnnotations;

public class CreateAuditLogDto
{
    [Required]
    public string OrgId { get; set; } = String.Empty;
    [Required]
    public ACTION Action { get; set; }
    [Required] 
    public string EntityId { get; set; } = string.Empty;
    [Required]
    public string EntityTitle { get; set; } = String.Empty;
    [Required]
    public ENTITY_TYPE EntityType { get; set; }
    [Required]
    public string UserId { get; set; } = String.Empty;
    [Required]
    public string UserName { get; set; } = String.Empty;
    [Required]
    public string UserImage { get; set; } = String.Empty;
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}