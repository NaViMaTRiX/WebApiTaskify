using WebApiTaskify.Models.Enum;

namespace WebApiTaskify.Dtos.AuditLog;

using System.ComponentModel.DataAnnotations;

public class CreateAuditLogDto
{
    [Required]
    public string OrgId { get; set; } = string.Empty;
    [Required]
    public ACTION Action { get; set; }
    [Required] 
    public string EntityId { get; set; } = string.Empty;
    [Required]
    public string EntityTitle { get; set; } = string.Empty;
    [Required]
    public ENTITY_TYPE EntityType { get; set; }
    [Required]
    public string UserId { get; set; } = string.Empty;
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string UserImage { get; set; } = string.Empty;
}