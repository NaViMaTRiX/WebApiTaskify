using WebApiTaskify.Models.Enum;
using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;
public class AuditLogs : BaseModel
{
    public Guid id { get; set; } 
    public string orgId { get; set; }
    public ACTION? action { get; set; }
    public string entityId { get; set; } 
    public string entityTitle { get; set; }
    public ENTITY_TYPE? entityType { get; set; }
    public string userId { get; set; }
    public string userName { get; set; } 
    public string userImage { get; set; }
}