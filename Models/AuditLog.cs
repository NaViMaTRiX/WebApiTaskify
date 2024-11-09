using WebApiTaskify.Models.Enum;
using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;
public class AuditLog : BaseModel
{
    public string id { get; set; } 
    public string orgId { get; set; }
    public ACTION action { get; set; }
    public string entityId { get; set; } 
    public string entityTitle { get; set; }
    public ENTITY_TYPE entityType { get; set; }
    public string userId { get; set; } 
    public string userName { get; set; } 
    public string userImage { get; set; }
    public DateTime createdAt { get; set; } = DateTime.UtcNow;
    public DateTime updatedAt { get; set; } = DateTime.UtcNow;
}