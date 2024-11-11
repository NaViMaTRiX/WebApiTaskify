using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class OrgLimit : BaseModel
{
    public Guid id { get; set; }
    public string orgId { get; set; }
    public int count { get; set; }
}